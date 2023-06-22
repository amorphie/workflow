using System.Text.Json;
using Dapr.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

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


    static IResult postWorkflowCompleted(
            [FromBody] dynamic body,
            [FromServices] WorkflowDBContext dbContext,
            HttpRequest request,
            HttpContext httpContext,
            [FromServices] DaprClient client
        )
    {

        var targetState = request.Headers["TARGET_STATE"].ToString();
        var transitionName = body.GetProperty("LastTransition").ToString();
        var instanceIdAsString = body.GetProperty("InstanceId").ToString();
        var data= body.GetProperty($"TRX-{transitionName}").GetProperty("Data");
        Guid instanceId;
        if (!Guid.TryParse(instanceIdAsString, out instanceId))
        {
            return Results.BadRequest("InstanceId not provided or not as a GUID");
        }

        Instance? instance = dbContext.Instances
            .Where(i => i.Id == instanceId)
            .Include(i => i.State)
                .ThenInclude(s => s.Transitions)
                .ThenInclude(t => t.ToState)
            .FirstOrDefault();

        if (instance is null)
        {
            return Results.NotFound($"Instance not found with instance id : {instanceId} ");
        }
        var transition = instance.State.Transitions.Where(t => t.Name == transitionName).FirstOrDefault();

        if (transition is null)
        {
            if (instance.BaseStatus != amorphie.core.Enums.StatusType.LockedInFlow)
            {
                string transitionNameAsString=transitionName;
                Transition? OldTransitionControl = dbContext.Transitions.Where(t => t.Name == transitionNameAsString)
                .Include(i => i.ToState).FirstOrDefault();
                if(OldTransitionControl!=null&&OldTransitionControl.ToStateName==instance.StateName)
                {
                    //It is already updated so return true: It is used for multiple trigger bug
                         return Results.Ok("{}");
                }
            }
            return Results.NotFound($"Transition not found with transition name : {transitionName} ");
        }

        if (targetState is null || targetState.ToLower() == "default")
        {

            if (transition.ToStateName is null)
            {
                return Results.BadRequest($"Target state is not provided nor defined on transition");
            }

            //var transitionData = JsonSerializer.Deserialize<dynamic>(body.GetProperty("LastTransitionData").ToString());


            var newInstanceTransition = new InstanceTransition
            {
                InstanceId = instance.Id,
                FromStateName = instance.StateName,
                ToStateName = transition.ToStateName,
                EntityData = body.GetProperty($"TRX-{transitionName}").GetProperty("Data").GetProperty("entityData").ToString(),
                RouteData = body.GetProperty($"TRX-{transitionName}").GetProperty("Data").GetProperty("routeData").ToString(),
                QueryData = body.GetProperty($"TRX-{transitionName}").GetProperty("Data").GetProperty("queryData").ToString(),
                FormData = body.GetProperty($"TRX-{transitionName}").GetProperty("Data").GetProperty("formData").ToString(),
                AdditionalData = body.GetProperty($"TRX-{transitionName}").GetProperty("Data").GetProperty("additionalData").ToString(),
                CreatedBy = Guid.Parse(body.GetProperty($"TRX-{transitionName}").GetProperty("TriggeredBy").ToString()),
                CreatedByBehalfOf = Guid.Parse(body.GetProperty($"TRX-{transitionName}").GetProperty("TriggeredByBehalfOf").ToString()),
            };
            string eventInfo = "worker-completed";
            dbContext.Add(newInstanceTransition);


            if (!string.IsNullOrEmpty(transition.ServiceName))
            {
                var clientHttp = new HttpClient();
                amorphie.workflow.core.Dtos.SendTransitionInfoRequest sendTransitionInfoRequest = new amorphie.workflow.core.Dtos.SendTransitionInfoRequest()
                {
                    recordId = instance.RecordId,
                    newStatus = transition.ToStateName!,
                    entityData = JsonSerializer.Deserialize<object>(newInstanceTransition.EntityData),
                    user = newInstanceTransition.CreatedBy,
                    behalfOfUser = newInstanceTransition.CreatedByBehalfOf,
                    workflowName = instance.WorkflowName
                };
                string jsonRequest = System.Text.Json.JsonSerializer.Serialize(sendTransitionInfoRequest);
                var response = clientHttp.PostAsync(transition.ServiceName, new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json")).Result;
                //var content=new FormUrlEncodedContent(newInstanceTransition!.EntityData!);

                try
                {
                    // var contentString = response!.Content!.ReadAsStringAsync().Result;
                    // dynamic JsonResultdata = Newtonsoft.Json.Linq.JObject.Parse(contentString);
                    // var status = JsonResultdata.result.status;
                    // if (status != "Success")
                    // {
                    //     var message = JsonResultdata.result.message;
                    //     instance.BaseStatus = transition.FromState!.BaseStatus;
                    //     eventInfo = "worker-error-with-service-" + transition.ServiceName;
                    // }
                    // else
                    // {
                    //     instance.BaseStatus = transition.ToState!.BaseStatus;
                    //     instance.StateName = transition.ToStateName;
                    // }
                    if (response.StatusCode == System.Net.HttpStatusCode.OK ||
                    response.StatusCode == System.Net.HttpStatusCode.Created)
                    {
                        instance.BaseStatus = transition.ToState!.BaseStatus;
                        instance.StateName = transition.ToStateName;
                    }
                    else
                    {
                        instance.BaseStatus = transition.FromState!.BaseStatus;
                        eventInfo = "worker-error-with-service-" + transition.ServiceName;
                    }
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                instance.BaseStatus = transition.ToState!.BaseStatus;
                instance.StateName = transition.ToStateName;

            }

            dbContext.SaveChanges();
            var responseSignalR = client.InvokeMethodAsync<PostSignalRData, string>(
                       HttpMethod.Post,
                       "amorphie-workflow-hub.test-amorphie-workflow-hub",
                       "sendMessage",
                       new PostSignalRData(
                           newInstanceTransition.CreatedBy,
                          eventInfo,
                           instance.Id,
                         newInstanceTransition.EntityData, DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), newInstanceTransition.ToStateName, transition.Name, instance.BaseStatus
                       ));
           return Results.Ok(createMessageVariables(newInstanceTransition,transitionName.ToString(),data));
        }
        else
        {
        }

        return Results.NotFound();
    }
    private static void SendSignalRData(InstanceTransition instanceTransition, string eventInfo, DaprClient _client, Instance instance)
    {

    }
      private static dynamic createMessageVariables( InstanceTransition instanceTransition,string _transitionName,dynamic _data)
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

        variables.Add($"TRX-{_transitionName}", targetObject);
        return variables;
    }

}