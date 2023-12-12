using System.Dynamic;
using System.Text.Json;
using amorphie.workflow.core.Dtos;
using AutoMapper.Configuration.Annotations;
using Dapr.Client;
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
             CancellationToken cancellationToken,
             IConfiguration configuration
        )
    {
        // TODO : Include a parameter for the cancelation token and add cancelation token to FirstOrDefault
        dynamic additionalDataDynamic = default!;
        dynamic entityDataDynamic = default!;
        var targetState = request.Headers["TARGET_STATE"].ToString();
        var transitionName = body.GetProperty("LastTransition").ToString();
        string hubMessage = string.Empty;
        try
        {
            hubMessage = body.GetProperty("message").ToString();
        }
        catch (Exception ex)
        {
            hubMessage = string.Empty;
        }

        var instanceIdAsString = body.GetProperty("InstanceId").ToString();
        Guid instanceId;
        if (!Guid.TryParse(instanceIdAsString, out instanceId))
        {
            return Results.BadRequest("InstanceId not provided or not as a GUID");
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
            return Results.NotFound($"Instance not found with instance id : {instanceId} ");
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
            targetStateAsState = await dbContext.States.FirstOrDefaultAsync(f => f.Name==targetState
            && f.WorkflowName == instance.WorkflowName
            , cancellationToken);
            if (targetStateAsState == null)
                return Results.BadRequest($"Target state is not provided ");
            error = true;
            IsTargetState = true;
            transition = await dbContext.Transitions.Include(i => i.ToState).ThenInclude(t => t!.Workflow)
                .ThenInclude(t => t!.Entities).Where(t => t.Name == transitionNameAsString
           && instance.WorkflowName == t.ToState!.WorkflowName).FirstOrDefaultAsync(cancellationToken);
        }
        //var transitionData = JsonSerializer.Deserialize<dynamic>(body.GetProperty("LastTransitionData").ToString());
        if (transition is null)
        {
            return Results.NotFound($"Transition not found with transition name : {transitionName} ");
        }

        if (!IsTargetState && transition != null && transition.ToStateName is null)
        {
            return Results.BadRequest($"Target state is not provided nor defined on transition");
        }
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

        string hubUrl = configuration["hubUrl"]!.ToString();
        Console.WriteLine(hubUrl);

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
              transition.Page == null ? null :
              new PostPageSignalRData(transition.Page.Operation.ToString(), transition.Page.Type.ToString(), transition.Page.Pages == null || transition.Page.Pages.Count == 0 ? null : new amorphie.workflow.core.Dtos.MultilanguageText(transition.Page.Pages!.FirstOrDefault()!.Language, transition.Page.Pages!.FirstOrDefault()!.Label),
              transition.Page.Timeout), hubMessage, additionalDataDynamic, instance.WorkflowName
                   ), cancellationToken);
        return Results.Ok(createMessageVariables(newInstanceTransition, transitionName.ToString(), data));
    }
    private static void SendSignalRData(InstanceTransition instanceTransition, string eventInfo, DaprClient _client, Instance instance)
    {

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
