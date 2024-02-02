using System.Dynamic;
using System.Text.Json;
using amorphie.workflow.core.Dtos;
using amorphie.workflow.core.Enums;
using amorphie.workflow.core.Helper;
using amorphie.workflow.service.Zeebe;
using Dapr.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;


public static class ExporterStateManagerModule
{

    public static void MapExporterStateManagerEndpoints(this WebApplication app)
    {
        app.MapPost("/exporter-set-state", postWorkflowCompleted)
            .Produces(StatusCodes.Status200OK)
            .WithOpenApi(operation =>
            {
                operation.Summary = "Maps amorphie-exporter-set-state service worker on Zeebe";
                operation.Tags = new List<OpenApiTag> { new() { Name = "Zeebe" } };
                return operation;
            });
    }


    static async ValueTask<IResult> postWorkflowCompleted(
            [FromBody] WorkerBody body,
            [FromServices] WorkflowDBContext dbContext,
            HttpRequest request,
            HttpContext httpContext,
            [FromServices] DaprClient client,
            [FromServices] IZeebeCommandService zbClient,
            [FromServices] FluentValidation.IValidator<WorkerBody> validator,
             CancellationToken cancellationToken,
             IConfiguration configuration

        )
    {
        FluentValidation.Results.ValidationResult validationResult =
            await validator.ValidateAsync(body);

        if (!validationResult.IsValid)
        {
            return Results.ValidationProblem(validationResult.ToDictionary());
        }


        var targetState = request.Headers["TARGET_STATE"].ToString();
        //var jobKey = Convert.ToInt64(request.Headers["X-Zeebe-Job-Key"].ToString());

        string pageUrl = request.Headers["PAGE_URL"].ToString();
        string pageOperationTypeString = request.Headers["PAGE_OPERATION_TYPE"].ToString();
        string pageTypeString = request.Headers["PAGE_TYPE"].ToString();
        string timeoutString = request.Headers["PAGE_TIMEOUT"].ToString();
        int timeout = 0;
        string pageLanguage = request.Headers["PAGE_LANGUAGE"].ToString();
        if (!string.IsNullOrEmpty(pageUrl) && string.IsNullOrEmpty(pageOperationTypeString))
        {
            pageOperationTypeString = PageOperationType.Open.ToString();
        }
        if (!string.IsNullOrEmpty(pageUrl) && string.IsNullOrEmpty(pageTypeString))
        {
            pageTypeString = EnumHelper.GetDescription<NavigationType>(NavigationType.PushReplacement);
        }
        if (!string.IsNullOrEmpty(pageUrl) && !string.IsNullOrEmpty(timeoutString))
        {
            try
            {
                timeout = Convert.ToInt32(timeoutString);
            }
            catch (Exception)
            {
                timeout = 0;
            }
        }
        if (!string.IsNullOrEmpty(pageUrl) && string.IsNullOrEmpty(pageLanguage))
        {
            pageLanguage = "en-EN";
        }


        Instance? instance = await dbContext.Instances
            .Where(i => i.Id == body.InstanceId)
            .Include(i => i.State)
                .ThenInclude(s => s.Transitions)
                .ThenInclude(t => t.ToState)
                .ThenInclude(t => t!.Workflow)
                .ThenInclude(t => t!.Entities)
            .Include(i => i.State)
                .ThenInclude(s => s.Transitions)
                .ThenInclude(s => s.Page)
                .ThenInclude(s => s!.Pages)
            .FirstOrDefaultAsync(cancellationToken);

        if (instance is null)
        {
            return Results.Problem($"Instance not found with instance id : {body.InstanceId} ");
            //throw new ZeebeBussinesException("500", $"Instance not found with instance id : {instanceId} ");
        }
        bool error = false;
        Transition? transition = null;
        State? targetStateAsState = null;
        bool IsTargetState = false;
        if (targetState is null || targetState.ToLower() == "default")
        {
            transition = instance.State.Transitions.Where(t => t.Name == body.LastTransition).FirstOrDefault();


        }
        else if (targetState.ToLower() == "error")
        {
            transition = await dbContext.Transitions.Include(i => i.ToState).ThenInclude(t => t!.Workflow)
                .ThenInclude(t => t!.Entities).Where(t => t.Name == body.LastTransition
           && instance.WorkflowName == t.ToState!.WorkflowName && t.ToState.Type == StateType.Fail).FirstOrDefaultAsync(cancellationToken);
            error = true;
        }
        else
        {
            targetStateAsState = await dbContext.States.FirstOrDefaultAsync(f => f.Name == targetState
            && f.WorkflowName == instance.WorkflowName
            , cancellationToken);
            if (targetStateAsState == null)
            {
                //return Results.Problem($"Target state is not provided ");
                throw new ZeebeBussinesException(errorMessage: $"Target state is not provided ");
            }

            error = true;
            IsTargetState = true;
            transition = await dbContext.Transitions.Include(i => i.ToState).ThenInclude(t => t!.Workflow)
                .ThenInclude(t => t!.Entities).Where(t => t.Name == body.LastTransition
           && instance.WorkflowName == t.ToState!.WorkflowName).FirstOrDefaultAsync(cancellationToken);

        }

        if (transition is null)
        {
            throw new ZeebeBussinesException(errorMessage: $"Transition not found with transition name : {body.LastTransition} ");
        }

        if (!IsTargetState && transition != null && transition.ToStateName is null)
        {
            throw new ZeebeBussinesException(errorMessage: $"Target state is not provided nor defined on transition");
        }


        InstanceTransition? newInstanceTransition;
        (newInstanceTransition, WorkerBodyTrxDatas? data, string eventInfo, string hubMessage) = ((InstanceTransition, WorkerBodyTrxDatas, string, string))await SetInstanceTransition(dbContext, transition, instance, error, body, IsTargetState, targetStateAsState, cancellationToken);
        string hubUrl = configuration["hubUrl"]!.ToString();
        Console.WriteLine(hubUrl);
        string pageTypeStringBYTransition = string.Empty;
        if (transition.Page != null)
            try
            {

                pageTypeStringBYTransition = EnumHelper.GetDescription<NavigationType>(((NavigationType)transition.Page.Type));
            }
            catch (Exception)
            {
                pageTypeStringBYTransition = string.Empty;
            }

        // var responseSignalRMFAType = client.CreateInvokeMethodRequest<SignalRRequest>(
        //                HttpMethod.Post,
        //                 hubUrl,
        //                "sendMessage/" + transition.ToState.MFAType.GetValueOrDefault(MFATypeEnum.Public).ToString().ToLower(),
        //                new SignalRRequest()
        //                {
        //                    data = new PostSignalRData(
        //                    newInstanceTransition.CreatedBy,
        //                    instance.RecordId,
        //                    eventInfo,
        //                    instance.Id,
        //                    instance.EntityName,
        //                  entityDataDynamic,
        //                  DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc),
        //                  IsTargetState && targetStateAsState != null ? targetStateAsState.Name : newInstanceTransition.ToStateName,
        //                  transition.Name,
        //                  instance.BaseStatus,
        //                  !string.IsNullOrEmpty(pageUrl) ? new PostPageSignalRData(pageOperationTypeString, pageTypeString, new MultilanguageText(pageLanguage, pageUrl), timeout) :
        //           transition.Page == null ? null :
        //           new PostPageSignalRData(transition.Page.Operation.ToString(), pageTypeStringBYTransition, transition.Page.Pages == null || transition.Page.Pages.Count == 0 ? null : new MultilanguageText(transition.Page.Pages!.FirstOrDefault()!.Language, transition.Page.Pages!.FirstOrDefault()!.Label),
        //           transition.Page.Timeout),
        //           body.HubMessage,
        //           body.HubErrorCode,
        //           additionalDataDynamic,
        //           instance.WorkflowName,
        //           transition.ToState.IsPublicForm == true ? "state" : "transition",
        //           transition.requireData.GetValueOrDefault(false),
        //           transition.transitionButtonType == 0 ? TransitionButtonType.Forward.ToString() : transition.transitionButtonType.GetValueOrDefault(TransitionButtonType.Forward).ToString()
        //                ),
        //                    source = "workflow",
        //                    type = "workflow",
        //                    subject = eventInfo,
        //                    id = instance.Id.ToString()
        //                }
        //                );

        // responseSignalRMFAType.Headers.Add("X-Device-Id", body.BodyHeaders.XDeviceId);
        // responseSignalRMFAType.Headers.Add("X-Token-Id", body.BodyHeaders.XTokenId);
        // responseSignalRMFAType.Headers.Add("A-Customer", body.BodyHeaders.ACustomer);

        // await client.InvokeMethodAsync<string>(responseSignalRMFAType, cancellationToken);
        return Results.Ok(createMessageVariables(newInstanceTransition, body.LastTransition, data));
    }
    private static dynamic createMessageVariables(InstanceTransition instanceTransition, string _transitionName, dynamic _data)
    {
        dynamic variables = new Dictionary<string, dynamic>();

        variables.Add("EntityName", instanceTransition.Instance.EntityName);
        variables.Add("RecordId", instanceTransition.Instance.RecordId);
        variables.Add("InstanceId", instanceTransition.InstanceId);
        variables.Add("LastTransition", _transitionName);
        dynamic targetObject = new System.Dynamic.ExpandoObject();
        targetObject.Data = _data;
        targetObject.TriggeredBy = instanceTransition.CreatedBy;
        targetObject.TriggeredByBehalfOf = instanceTransition.CreatedByBehalfOf;
        string updateName = deleteUnAllowedCharecters(_transitionName);
        variables.Add($"TRX-{_transitionName}", targetObject);
        variables.Add($"TRX{updateName}", targetObject);
        return variables;
    }
    private static string deleteUnAllowedCharecters(string transitionName)
    {
        return System.Text.RegularExpressions.Regex.Replace(transitionName, "[^A-Za-z0-9]", "", System.Text.RegularExpressions.RegexOptions.Compiled);
    }
    private static async Task<(InstanceTransition, WorkerBodyTrxDatas?, string, string)> SetInstanceTransition(WorkflowDBContext dbContext, Transition transition, Instance instance, bool error, WorkerBody body, bool IsTargetState, State? targetStateAsState, CancellationToken cancellationToken)
    {

        string hubMessage = string.Empty;
        InstanceTransition? newInstanceTransition;
        string updateName = deleteUnAllowedCharecters(body.LastTransition);

        var data = body.WorkerBodyTrxDataList?.GetValueOrDefault($"TRX{updateName}");

        if (!error)
        {
            newInstanceTransition = await dbContext.InstanceTransitions.OrderByDescending(o => o.StartedAt)
            .FirstOrDefaultAsync(f => f.InstanceId == instance.Id && f.TransitionName == transition.Name, cancellationToken);
        }
        else
        {
            InstanceTransition? newInstanceTransitionForName = await dbContext.InstanceTransitions.Include(s => s.Transition).OrderByDescending(o => o.StartedAt)
              .FirstOrDefaultAsync(f => f.InstanceId == instance.Id && f.Transition!.FromStateName == transition.FromStateName, cancellationToken);
            newInstanceTransition = await dbContext.InstanceTransitions.Include(s => s.Transition).OrderByDescending(o => o.StartedAt)
             .FirstOrDefaultAsync(f => f.InstanceId == instance.Id, cancellationToken);
            //??Buna gerek var mı??
            if (data == null)
            {
                updateName = deleteUnAllowedCharecters(newInstanceTransition!.TransitionName!);
                data = body.WorkerBodyTrxDataList?.GetValueOrDefault($"TRX{updateName}");
                //data halen null ise newInstanceTransitionForName bu obje ile dene
            }

            newInstanceTransition!.AdditionalData = data.Data.AdditionalData.ToString();

            // newInstanceTransition!.EntityData = body.GetProperty($"TRX{updateName}").GetProperty("Data").GetProperty("entityData").ToString();
            newInstanceTransition!.EntityData = data.Data.EntityData.ToString();

            if (!IsTargetState || targetStateAsState == null)
                newInstanceTransition!.ToStateName = transition.ToStateName;
            if (IsTargetState && targetStateAsState != null)
                newInstanceTransition!.ToStateName = targetStateAsState.Name;

            newInstanceTransition!.CreatedBy = Guid.Parse(data.TriggeredBy.ToString());
            newInstanceTransition!.CreatedByBehalfOf = Guid.Parse(data.TriggeredByBehalfOf.ToString());
        }
        newInstanceTransition!.TransitionName = transition.Name;
        newInstanceTransition!.Transition = transition;

        string eventInfo = "state-updated-by-exporter";


        instance.BaseStatus = transition.ToState!.BaseStatus;
        if (IsTargetState && targetStateAsState != null)
        {
            instance.StateName = targetStateAsState.Name;
        }
        if (!IsTargetState || targetStateAsState == null)
        {
            instance.StateName = transition.ToStateName;
        }

        if (instance.WorkflowName != transition.ToState.WorkflowName)
        {
            instance.WorkflowName = transition.ToState!.WorkflowName!;
            if (!transition.ToState.Workflow!.Entities.Any(a => a.Name == instance.EntityName))
            {
                instance.EntityName = transition.ToState.Workflow.Entities.FirstOrDefault()!.Name;
            }
        }

        newInstanceTransition!.FinishedAt = DateTime.Now;
        // dbContext.Add(newInstanceTransition);
        // TODO : Include a parameter for the cancelation token and convert SaveChanges to SaveChangesAsync with the cancelation token.

        await dbContext.SaveChangesAsync(cancellationToken);
        return (newInstanceTransition, data, eventInfo, hubMessage);
    }

}

