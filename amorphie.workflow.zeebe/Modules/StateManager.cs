using System.Dynamic;
using System.Text.Json;
using amorphie.workflow.core.Dtos;
using amorphie.workflow.core.Enums;
using amorphie.workflow.core.Helper;
using amorphie.workflow.service.Zeebe;
using AutoMapper.Configuration.Annotations;
using Dapr.Client;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.VisualBasic;
using Refit;

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
            [FromBody] dynamic body,
            [FromServices] WorkflowDBContext dbContext,
            HttpRequest request,
            HttpContext httpContext,
            [FromServices] DaprClient client,
            [FromServices] IZeebeCommandService zbClient,
             CancellationToken cancellationToken,
             IConfiguration configuration
        )
    {
        // TODO : Include a parameter for the cancelation token and add cancelation token to FirstOrDefault
        dynamic additionalDataDynamic = default!;
        dynamic entityDataDynamic = default!;
        var targetState = request.Headers["TARGET_STATE"].ToString();
        var jobKey = Convert.ToInt64(request.Headers["X-Zeebe-Job-Key"].ToString());
        var transitionName = body.GetProperty("LastTransition").ToString();
        //entityName or Process
        string workFlowName = body.GetProperty("EntityName").ToString();
        string hubMessage = string.Empty;
        string hubErrorCode = string.Empty;
        string tokenid = string.Empty;
        string customerid = string.Empty;
        string deviceid = string.Empty;
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
            pageTypeString =EnumHelper.GetDescription<NavigationType>(NavigationType.PushReplacement);
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
        try
        {
            hubMessage = body.GetProperty("message").ToString();
        }
        catch (Exception ex)
        {
            hubMessage = string.Empty;
        }
          try
        {
            hubErrorCode = body.GetProperty("errorCode").ToString();
        }
        catch (Exception ex)
        {
            hubErrorCode = string.Empty;
        }
        try
        {
            tokenid = body.GetProperty("Headers").GetProperty("xtokenid").ToString();
        }
        catch (Exception ex)
        {
            tokenid = string.Empty;
        }
        try
        {
            customerid = body.GetProperty("Headers").GetProperty("acustomer").ToString();
        }
        catch (Exception ex)
        {
            customerid = string.Empty;
        }
        try
        {
            deviceid = body.GetProperty("Headers").GetProperty("xdeviceid").ToString();
        }
        catch (Exception ex)
        {
            deviceid = string.Empty;
        }

        //For fetching gateway from db
        // ZeebeMessage? zeebeMessage = await dbContext.ZeebeMessages.FirstOrDefaultAsync(p => p.Process == workFlowName);
        // if (zeebeMessage is null)
        // {
        //     return Results.BadRequest("Workflow/Entity Name must be in variable list");
        // }


        var instanceIdAsString = body.GetProperty("InstanceId").ToString();
        Guid instanceId;
        if (!Guid.TryParse(instanceIdAsString, out instanceId))
        {

            return Results.Problem("InstanceId not provided or not as a GUID");
            //throw new ZeebeBussinesException("500", "InstanceId not provided or not as a GUID");
        }

        Instance? instance = await dbContext.Instances
            .Where(i => i.Id == instanceId)
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
            return Results.Problem($"Instance not found with instance id : {instanceId} ");
            //throw new ZeebeBussinesException("500", $"Instance not found with instance id : {instanceId} ");
        }
        bool error = false;
        Transition? transition = null;
        State? targetStateAsState = null;
        bool IsTargetState = false;
        if (targetState is null || targetState.ToLower() == "default")
        {
            transition = instance.State.Transitions.Where(t => t.Name == transitionName).FirstOrDefault();


        }
        else if (targetState.ToLower() == "error")
        {
            string transitionNameAsString = transitionName.ToString();
            transition = await dbContext.Transitions.Include(i => i.ToState).ThenInclude(t => t!.Workflow)
                .ThenInclude(t => t!.Entities).Where(t => t.Name == transitionNameAsString
           && instance.WorkflowName == t.ToState!.WorkflowName && t.ToState.Type == StateType.Fail).FirstOrDefaultAsync(cancellationToken);
            error = true;
        }
        else
        {
            string transitionNameAsString = transitionName.ToString();
            targetStateAsState = await dbContext.States.FirstOrDefaultAsync(f => f.Name == targetState
            && f.WorkflowName == instance.WorkflowName
            , cancellationToken);
            if (targetStateAsState == null)
            {
                return Results.Problem($"Target state is not provided ");
                //throw new ZeebeBussinesException(errorMessage: $"Target state is not provided ");
            }

            error = true;
            IsTargetState = true;
            transition = await dbContext.Transitions.Include(i => i.ToState).ThenInclude(t => t!.Workflow)
                .ThenInclude(t => t!.Entities).Where(t => t.Name == transitionNameAsString
           && instance.WorkflowName == t.ToState!.WorkflowName).FirstOrDefaultAsync(cancellationToken);

        }
        //var transitionData = JsonSerializer.Deserialize<dynamic>(body.GetProperty("LastTransitionData").ToString());
        if (transition is null)
        {
            return Results.Problem($"Transition not found with transition name : {transitionName} ");
            //throw new ZeebeBussinesException(errorMessage: $"Transition not found with transition name : {transitionName} ");
        }

        if (!IsTargetState && transition != null && transition.ToStateName is null)
        {
            return Results.Problem($"Target state is not provided nor defined on transition");
            //throw new ZeebeBussinesException(errorMessage: $"Target state is not provided nor defined on transition");
        }


        InstanceTransition? newInstanceTransition;
        (newInstanceTransition, additionalDataDynamic, entityDataDynamic, hubMessage, dynamic? data, string eventInfo) = ((InstanceTransition, dynamic, dynamic, string, dynamic?, string))await SetInstanceTransition(dbContext, transition, instance, transitionName, error, body, IsTargetState, targetStateAsState, cancellationToken);
        string hubUrl = configuration["hubUrl"]!.ToString();
        Console.WriteLine(hubUrl);
        string pageTypeStringBYTransition=string.Empty;
        if(transition.Page!=null)
        try
        {

            pageTypeStringBYTransition=EnumHelper.GetDescription<NavigationType>(((NavigationType)transition.Page.Type));
        }
        catch(Exception)
        {
            pageTypeStringBYTransition=string.Empty;
        }
        var responseSignalR = client.InvokeMethodAsync<PostSignalRData, string>(
                   HttpMethod.Post,
                    hubUrl,
                   "sendMessage",
                   new PostSignalRData(
                       newInstanceTransition.CreatedBy,
                       instance.RecordId,
                       eventInfo,
                       instance.Id,
                       instance.EntityName,
                     entityDataDynamic, DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), IsTargetState && targetStateAsState != null ?
                    targetStateAsState.Name : newInstanceTransition.ToStateName, transition.Name, instance.BaseStatus,
             !string.IsNullOrEmpty(pageUrl) ? new PostPageSignalRData(pageOperationTypeString, pageTypeString, new amorphie.workflow.core.Dtos.MultilanguageText(pageLanguage, pageUrl), timeout) :
              transition.Page == null ? null :
              new PostPageSignalRData(transition.Page.Operation.ToString(),pageTypeStringBYTransition, transition.Page.Pages == null || transition.Page.Pages.Count == 0 ? null : new amorphie.workflow.core.Dtos.MultilanguageText(transition.Page.Pages!.FirstOrDefault()!.Language, transition.Page.Pages!.FirstOrDefault()!.Label),
              transition.Page.Timeout), hubMessage,hubErrorCode, additionalDataDynamic, instance.WorkflowName, transition.ToState.IsPublicForm == true ? "state" : "transition",
              transition.requireData.GetValueOrDefault(false)
              , transition.transitionButtonType == 0 ? amorphie.workflow.core.Enums.TransitionButtonType.Forward.ToString() : transition.transitionButtonType.GetValueOrDefault(amorphie.workflow.core.Enums.TransitionButtonType.Forward).ToString()
                   ), cancellationToken);



        var responseSignalRMFAType = client.CreateInvokeMethodRequest<SignalRRequest>(
                       HttpMethod.Post,
                        hubUrl,
                       "sendMessage/" + transition.ToState.MFAType.GetValueOrDefault(MFATypeEnum.Public).ToString().ToLower(), new SignalRRequest()
                       {
                           data = new PostSignalRData(
                           newInstanceTransition.CreatedBy,
                           instance.RecordId,
                           eventInfo,
                           instance.Id,
                           instance.EntityName,
                         entityDataDynamic, DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), IsTargetState && targetStateAsState != null ?
                        targetStateAsState.Name : newInstanceTransition.ToStateName, transition.Name, instance.BaseStatus,
                         !string.IsNullOrEmpty(pageUrl) ? new PostPageSignalRData(pageOperationTypeString, pageTypeString, new amorphie.workflow.core.Dtos.MultilanguageText(pageLanguage, pageUrl), timeout) :
                  transition.Page == null ? null :
                  new PostPageSignalRData(transition.Page.Operation.ToString(), pageTypeStringBYTransition, transition.Page.Pages == null || transition.Page.Pages.Count == 0 ? null : new amorphie.workflow.core.Dtos.MultilanguageText(transition.Page.Pages!.FirstOrDefault()!.Language, transition.Page.Pages!.FirstOrDefault()!.Label),
                  transition.Page.Timeout), hubMessage,hubErrorCode, additionalDataDynamic, instance.WorkflowName, transition.ToState.IsPublicForm == true ? "state" : "transition",
                  transition.requireData.GetValueOrDefault(false)
                  , transition.transitionButtonType == 0 ? amorphie.workflow.core.Enums.TransitionButtonType.Forward.ToString() : transition.transitionButtonType.GetValueOrDefault(amorphie.workflow.core.Enums.TransitionButtonType.Forward).ToString()
                       ),
                           source = "workflow",
                           type = "workflow",
                           subject = eventInfo,
                           id = instance.Id.ToString()
                       }
                       );
        try
        {
            responseSignalRMFAType.Headers.Add("X-Device-Id", deviceid);
        }
        catch (Exception)
        {

        }
        try
        {
            responseSignalRMFAType.Headers.Add("X-Token-Id", tokenid);
        }
        catch (Exception)
        {

        }
        try
        {
            responseSignalRMFAType.Headers.Add("A-Customer", customerid);
        }
        catch (Exception)
        {

        }
        await client.InvokeMethodAsync<string>(responseSignalRMFAType, cancellationToken);
        return Results.Ok(createMessageVariables(newInstanceTransition, transitionName.ToString(), data));
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
    private static async Task<(InstanceTransition, dynamic, dynamic, string, dynamic?, string)> SetInstanceTransition(WorkflowDBContext dbContext, Transition transition, Instance instance, string transitionName, bool error, dynamic body, bool IsTargetState, State? targetStateAsState, CancellationToken cancellationToken)
    {
        dynamic additionalDataDynamic = default!;
        dynamic entityDataDynamic = default!;
        string hubMessage = string.Empty;
        InstanceTransition? newInstanceTransition;
        dynamic? data;
        bool transitionDataFound = true;
        string updateName = deleteUnAllowedCharecters(transitionName);
        if (!error)
        {
            newInstanceTransition = await dbContext.InstanceTransitions.OrderByDescending(o => o.StartedAt)
            .FirstOrDefaultAsync(f => f.InstanceId == instance.Id && f.TransitionName == transition.Name, cancellationToken);

            data = body.GetProperty($"TRX{updateName}").GetProperty("Data");
        }
        else
        {
            newInstanceTransition = await dbContext.InstanceTransitions.Include(s => s.Transition).OrderByDescending(o => o.StartedAt)
            .FirstOrDefaultAsync(f => f.InstanceId == instance.Id && f.Transition!.FromStateName == transition.FromStateName, cancellationToken);


            try
            {
                data = body.GetProperty($"TRX{updateName}").GetProperty("Data");
            }
            catch
            {
                transitionDataFound = false;
                updateName = deleteUnAllowedCharecters(newInstanceTransition.TransitionName);
                data = body.GetProperty($"TRX{updateName}").GetProperty("Data");

                newInstanceTransition!.AdditionalData = body.GetProperty($"TRX{updateName}").GetProperty("Data").GetProperty("additionalData").ToString();
                try
                {
                    if (!string.IsNullOrEmpty(newInstanceTransition!.AdditionalData))
                        additionalDataDynamic = body.GetProperty($"TRX{updateName}").GetProperty("Data").GetProperty("additionalData");
                    else
                    {
                        additionalDataDynamic = new { };
                    }
                }
                catch (Exception ex)
                {
                    additionalDataDynamic = newInstanceTransition!.AdditionalData;
                }

                newInstanceTransition!.EntityData = body.GetProperty($"TRX{updateName}").GetProperty("Data").GetProperty("entityData").ToString();
                try
                {
                    entityDataDynamic = body.GetProperty($"TRX{updateName}").GetProperty("Data").GetProperty("entityData");
                }
                catch (Exception ex)
                {
                    entityDataDynamic = newInstanceTransition!.EntityData;
                }
                if (!IsTargetState || targetStateAsState == null)
                    newInstanceTransition!.ToStateName = transition.ToStateName;
                if (IsTargetState && targetStateAsState != null)
                    newInstanceTransition!.ToStateName = targetStateAsState.Name;

                newInstanceTransition!.CreatedBy = Guid.Parse(body.GetProperty($"TRX{updateName}").GetProperty("TriggeredBy").ToString());
                newInstanceTransition!.CreatedByBehalfOf = Guid.Parse(body.GetProperty($"TRX{updateName}").GetProperty("TriggeredByBehalfOf").ToString());
            }
            newInstanceTransition!.TransitionName = transition.Name;
            newInstanceTransition!.Transition = transition;
        }
        if (transitionDataFound)
        {
            newInstanceTransition!.AdditionalData = body.GetProperty($"TRX{updateName}").GetProperty("Data").GetProperty("additionalData").ToString();

            try
            {
                if (!string.IsNullOrEmpty(newInstanceTransition!.AdditionalData))
                    additionalDataDynamic = body.GetProperty($"TRX{updateName}").GetProperty("Data").GetProperty("additionalData");
                else
                {
                    additionalDataDynamic = new { };
                }
            }
            catch (Exception ex)
            {
                additionalDataDynamic = newInstanceTransition!.AdditionalData;
            }
            newInstanceTransition!.EntityData = body.GetProperty($"TRX{updateName}").GetProperty("Data").GetProperty("entityData").ToString();
            try
            {
                entityDataDynamic = body.GetProperty($"TRX{updateName}").GetProperty("Data").GetProperty("entityData");
            }
            catch (Exception ex)
            {
                entityDataDynamic = newInstanceTransition!.EntityData;
            }
            if (!IsTargetState || targetStateAsState == null)
                newInstanceTransition!.ToStateName = transition.ToStateName;
            if (IsTargetState && targetStateAsState != null)
                newInstanceTransition!.ToStateName = targetStateAsState.Name;

            newInstanceTransition!.CreatedBy = Guid.Parse(body.GetProperty($"TRX{updateName}").GetProperty("TriggeredBy").ToString());
            newInstanceTransition!.CreatedByBehalfOf = Guid.Parse(body.GetProperty($"TRX{updateName}").GetProperty("TriggeredByBehalfOf").ToString());
        }
        var jsonString = System.Text.Json.JsonSerializer.Serialize(newInstanceTransition!.AdditionalData);

        string eventInfo = "worker-completed";



        if (!string.IsNullOrEmpty(transition.ServiceName))
        {
            // var userAPI = RestService.For<ITodoAPI>(transition.ServiceName);
            ClientFactory _factory = new ClientFactory();
            var clientFactory = _factory.CreateClient(transition.ServiceName);
            // TODO : Use refit rather than httpclient and consider resiliency.
            SendTransitionInfoRequest sendTransitionInfoRequest = new SendTransitionInfoRequest()
            {
                recordId = instance.RecordId,
                newStatus = IsTargetState && targetStateAsState != null ? targetStateAsState.Name : transition.ToStateName!,
                entityData = JsonSerializer.Deserialize<object>(newInstanceTransition.EntityData),
                user = newInstanceTransition.CreatedBy,
                behalfOfUser = newInstanceTransition.CreatedByBehalfOf,
                workflowName = instance.WorkflowName
            };
            try
            {
                var response = await clientFactory.PostModel(sendTransitionInfoRequest);

                if (response.StatusCode == System.Net.HttpStatusCode.OK
                || response.StatusCode == System.Net.HttpStatusCode.Created
                || response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
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
                }

                else
                {

                    try
                    {

                        var problem = Newtonsoft.Json.JsonConvert.DeserializeObject<Refit.ProblemDetails>(response.Error!.Content!);
                        hubMessage += problem!.Detail;
                    }
                    catch (Exception ex)
                    {
                        hubMessage += response.ReasonPhrase;
                    }
                    instance.BaseStatus = transition.FromState!.BaseStatus;
                    eventInfo = "worker-error-with-service-" + transition.ServiceName;
                }
            }
            catch (Exception ex)
            {

                instance.BaseStatus = transition.FromState!.BaseStatus;
                eventInfo = "worker-error-with-service-" + transition.ServiceName;

            }
        }
        else
        {
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

        }
        newInstanceTransition!.FinishedAt = DateTime.Now;
        // dbContext.Add(newInstanceTransition);
        // TODO : Include a parameter for the cancelation token and convert SaveChanges to SaveChangesAsync with the cancelation token.
        await dbContext.SaveChangesAsync(cancellationToken);
        return (newInstanceTransition, additionalDataDynamic, entityDataDynamic, hubMessage, data, eventInfo);
    }

}
public record ConsumerPostTransitionRequest
{

    public dynamic EntityData { get; set; } = default!;
    public dynamic? FormData { get; set; }
    public dynamic? AdditionalData { get; set; }
    public bool GetSignalRHub { get; set; }
    public dynamic? RouteData { get; set; }
    public dynamic? QueryData { get; set; }
}
