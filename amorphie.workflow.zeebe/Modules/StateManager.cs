using System.Text.Json.Nodes;
using amorphie.workflow.core.Constants;
using amorphie.workflow.core.Dtos;
using amorphie.workflow.core.Enums;
using amorphie.workflow.core.Helper;
using amorphie.workflow.service.Zeebe;
using Dapr.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;

public static class StateManagerModule
{

    public static void MapStateManagerEndpoints(this WebApplication app)
    {
        app.MapPost("/amorphie-workflow-set-state", postWorkflowCompleted)
            .Produces(StatusCodes.Status200OK)
            .WithOpenApi(operation =>
            {
                operation.Summary = "Maps amorphie-workflow-set-state service worker on Zeebe";
                operation.Tags = new List<OpenApiTag> { new() { Name = "Zeebe" } };
                return operation;
            });
    }

    static async ValueTask<IResult> postWorkflowCompleted(
            [FromBody] JsonObject jsonBody,
            [FromServices] WorkflowDBContext dbContext,
            HttpRequest request,
            HttpContext httpContext,
            [FromServices] DaprClient client,
            [FromServices] IZeebeCommandService zbClient,
             CancellationToken cancellationToken,
             IConfiguration configuration
        )
    {
        WorkerBody body = JsonObjectConverter.JsonToWorkerBody(jsonBody);

        var targetState = request.Headers["TARGET_STATE"].ToString();
        string hubErrorCode = string.Empty;
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


        //Guid instanceId = body.InstanceId;
        // if (!Guid.TryParse(body.InstanceId, out instanceId))
        // {
        //     return Results.Problem("InstanceId not provided or not as a GUID");
        // }

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
        httpContext.Items.Add(ZeebeVariableKeys.InstanceId, body.InstanceId.ToString());
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

            // && (f.WorkflowName == instance.WorkflowName || (instance.State.Type == StateType.SubWorkflow &&
            // instance.State.SubWorkflowName == f.WorkflowName))
            , cancellationToken);
            if (targetStateAsState == null)
            {
                return Results.Problem($"Target state is not provided ");
                //throw new ZeebeBussinesException(errorMessage: $"Target state is not provided ");
            }

            error = true;
            IsTargetState = true;
            transition = await dbContext.Transitions.Include(i => i.ToState).ThenInclude(t => t!.Workflow)
                .ThenInclude(t => t!.Entities).Where(t => t.Name == body.LastTransition
            //    && (instance.WorkflowName == t.ToState!.WorkflowName || (instance.State.Type == StateType.SubWorkflow &&
            //     instance.State.SubWorkflowName == t.ToState.WorkflowName))
            ).FirstOrDefaultAsync(cancellationToken);

        }
        //var transitionData = JsonSerializer.Deserialize<dynamic>(body.GetProperty("LastTransitionData").ToString());
        if (transition is null)
        {
            return Results.Problem($"Transition not found with transition name : {body.LastTransition} ");
            //throw new ZeebeBussinesException(errorMessage: $"Transition not found with transition name : {transitionName} ");
        }

        if (!IsTargetState && transition != null && transition.ToStateName is null)
        {
            return Results.Problem($"Target state is not provided nor defined on transition");
            //throw new ZeebeBussinesException(errorMessage: $"Target state is not provided nor defined on transition");
        }


        InstanceTransition? newInstanceTransition;
        (newInstanceTransition, WorkerBodyTrxDatas? data, string eventInfo) =
        ((InstanceTransition, WorkerBodyTrxDatas, string))await SetInstanceTransition(dbContext, transition, instance, error, body, IsTargetState, targetStateAsState, cancellationToken);

        string hubUrl = configuration["hubUrl"]!.ToString();

        string pageTypeStringBYTransition = string.Empty;
        if (transition.Page != null)
        {

            try
            {

                pageTypeStringBYTransition = EnumHelper.GetDescription<NavigationType>(((NavigationType)transition.Page.Type));
            }
            catch (Exception)
            {
                pageTypeStringBYTransition = string.Empty;
            }
        }
        // var responseSignalR = client.InvokeMethodAsync<PostSignalRData, string>(
        //            HttpMethod.Post,
        //             hubUrl,
        //            "sendMessage",
        //            new PostSignalRData(
        //                newInstanceTransition.CreatedBy,
        //                instance.RecordId,
        //                eventInfo,
        //                instance.Id,
        //                instance.EntityName,
        //              entityDataDynamic, DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), IsTargetState && targetStateAsState != null ?
        //             targetStateAsState.Name : newInstanceTransition.ToStateName, transition.Name, instance.BaseStatus,
        //      !string.IsNullOrEmpty(pageUrl) ? new PostPageSignalRData(pageOperationTypeString, pageTypeString, new amorphie.workflow.core.Dtos.MultilanguageText(pageLanguage, pageUrl), timeout) :
        //       transition.Page == null ? null :
        //       new PostPageSignalRData(transition.Page.Operation.ToString(), pageTypeStringBYTransition, transition.Page.Pages == null || transition.Page.Pages.Count == 0 ? null : new amorphie.workflow.core.Dtos.MultilanguageText(transition.Page.Pages!.FirstOrDefault()!.Language, transition.Page.Pages!.FirstOrDefault()!.Label),
        //       transition.Page.Timeout), hubMessage, hubErrorCode, additionalDataDynamic, instance.WorkflowName, transition.ToState.IsPublicForm == true ? "state" : "transition",
        //       transition.requireData.GetValueOrDefault(false)
        //       , transition.transitionButtonType == 0 ? amorphie.workflow.core.Enums.TransitionButtonType.Forward.ToString() : transition.transitionButtonType.GetValueOrDefault(amorphie.workflow.core.Enums.TransitionButtonType.Forward).ToString()
        //            ), cancellationToken);



        var responseSignalRMFAType = client.CreateInvokeMethodRequest<SignalRRequest>(
                       HttpMethod.Post,
                        hubUrl,
                       "sendMessage/" + transition.ToState.MFAType.GetValueOrDefault(MFATypeEnum.Public).ToString().ToLower(),
                       new SignalRRequest()
                       {
                           data = new PostSignalRData(
                           newInstanceTransition.CreatedBy,
                           instance.RecordId,
                           eventInfo,
                           instance.Id,
                           instance.EntityName,
                         data.Data?.EntityData,
                         DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc),
                         IsTargetState && targetStateAsState != null ? targetStateAsState.Name : newInstanceTransition.ToStateName,
                         transition.Name,
                         instance.BaseStatus,
                         !string.IsNullOrEmpty(pageUrl) ? new PostPageSignalRData(pageOperationTypeString, pageTypeString, new MultilanguageText(pageLanguage, pageUrl), timeout) :
                  transition.Page == null ? null :
                  new PostPageSignalRData(transition.Page.Operation.ToString(), pageTypeStringBYTransition, transition.Page.Pages == null || transition.Page.Pages.Count == 0 ? null : new MultilanguageText(transition.Page.Pages!.FirstOrDefault()!.Language, transition.Page.Pages!.FirstOrDefault()!.Label),
                  transition.Page.Timeout),
                  message: "",
                  errorCode: hubErrorCode,
                  data.Data?.AdditionalData,
                  instance.WorkflowName,
                  transition.ToState.IsPublicForm == true ? "state" : "transition",
                  transition.requireData.GetValueOrDefault(false),
                  transition.transitionButtonType == 0 ? TransitionButtonType.Forward.ToString() : transition.transitionButtonType.GetValueOrDefault(TransitionButtonType.Forward).ToString()
                       ),
                           source = "workflow",
                           type = "workflow",
                           subject = eventInfo,
                           id = instance.Id.ToString()
                       }
                       );
        responseSignalRMFAType.Headers.Add("X-Device-Id", body.Headers.XDeviceId);
        responseSignalRMFAType.Headers.Add("X-Token-Id", body.Headers.XTokenId);
        responseSignalRMFAType.Headers.Add("A-Customer", body.Headers.ACustomer);

        await client.InvokeMethodAsync<string>(responseSignalRMFAType, cancellationToken);
        return Results.Ok(createMessageVariables(newInstanceTransition, body.LastTransition, data));
    }
    private static dynamic createMessageVariables(InstanceTransition instanceTransition, string _transitionName, WorkerBodyTrxDatas _data)
    {
        dynamic variables = new Dictionary<string, dynamic>();

        variables.Add("EntityName", instanceTransition.Instance.EntityName);
        variables.Add("RecordId", instanceTransition.Instance.RecordId);
        variables.Add("InstanceId", instanceTransition.InstanceId);
        variables.Add("LastTransition", _transitionName);
        dynamic targetObject = new System.Dynamic.ExpandoObject();
        targetObject.Data = _data.Data;
        targetObject.TriggeredBy = instanceTransition.CreatedBy;
        targetObject.TriggeredByBehalfOf = instanceTransition.CreatedByBehalfOf;
        string updateName = _transitionName.DeleteUnAllowedCharecters();
        variables.Add($"TRX-{_transitionName}", targetObject);
        variables.Add($"TRX{updateName}", targetObject);
        return variables;
    }
    // private static string deleteUnAllowedCharecters(string transitionName)
    // {
    //     return System.Text.RegularExpressions.Regex.Replace(transitionName, "[^A-Za-z0-9]", "", System.Text.RegularExpressions.RegexOptions.Compiled);
    // }
    private static async Task<(InstanceTransition, WorkerBodyTrxDatas?, string)> SetInstanceTransition(WorkflowDBContext dbContext, Transition transition, Instance instance, bool error, WorkerBody body, bool IsTargetState, State? targetStateAsState, CancellationToken cancellationToken)
    {

        InstanceTransition? newInstanceTransition;
        string updateName = body.LastTransition.DeleteUnAllowedCharecters();
        WorkerBodyTrxDatas? data = body.WorkerBodyTrxDataList?.GetValueOrDefault($"TRX{updateName}");
        if (!error)
        {
            newInstanceTransition = await dbContext.InstanceTransitions.OrderByDescending(o => o.StartedAt)
            .FirstOrDefaultAsync(f => f.InstanceId == instance.Id && f.TransitionName == transition.Name, cancellationToken);
        }
        //TODO : new instace tran null ise forname nesnesi ile birleştir else yi kaldır
        else
        {
            InstanceTransition? newInstanceTransitionForName = await dbContext.InstanceTransitions.Include(s => s.Transition).OrderByDescending(o => o.StartedAt)
              .FirstOrDefaultAsync(f => f.InstanceId == instance.Id && f.Transition!.FromStateName == transition.FromStateName, cancellationToken);
            newInstanceTransition = await dbContext.InstanceTransitions.Include(s => s.Transition).OrderByDescending(o => o.StartedAt)
             .FirstOrDefaultAsync(f => f.InstanceId == instance.Id, cancellationToken);

            if (data == null)
            {
                updateName = newInstanceTransition!.TransitionName.DeleteUnAllowedCharecters();
                data = body.WorkerBodyTrxDataList?.GetValueOrDefault($"TRX{updateName}");
            }
            if (data == null)
            {
                updateName = newInstanceTransitionForName!.TransitionName.DeleteUnAllowedCharecters();
                data = body.WorkerBodyTrxDataList?.GetValueOrDefault($"TRX{updateName}");
            }
        }
        if (data == null)
        {
            throw new ZeebeBussinesException(errorMessage: $"Data cannot fetched from body with the given LastTransitionName {updateName}");
        }
        else
        {
            if (data.Data != null)
            {
                newInstanceTransition!.AdditionalData = data.Data.AdditionalData?.ToString();
                newInstanceTransition!.EntityData = data.Data.EntityData?.ToString() ?? "";
            }

            if (!IsTargetState || targetStateAsState == null)
                newInstanceTransition!.ToStateName = transition.ToStateName;
            if (IsTargetState && targetStateAsState != null)
                newInstanceTransition!.ToStateName = targetStateAsState.Name;

            newInstanceTransition!.CreatedBy = data.TriggeredBy;
            newInstanceTransition!.CreatedByBehalfOf = data.TriggeredByBehalfOf;

            newInstanceTransition!.TransitionName = transition.Name;
            newInstanceTransition!.Transition = transition;

            string eventInfo = "worker-completed";


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
            return (newInstanceTransition, data, eventInfo);
        }
    }

}
