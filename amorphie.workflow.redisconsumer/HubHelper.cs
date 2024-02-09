using System.Text.Json.Nodes;
using amorphie.workflow.core.Constants;
using amorphie.workflow.core.Dtos;
using Dapr.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace amorphie.workflow.redisconsumer;
public class StateHelper
{
    public static string HubUrl;
    public static async Task<IResult> SetState(WorkflowDBContext dbContext, Guid instanceId,
    JsonObject variables, string targetState,
    CancellationToken cancellationToken)
    {
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
        string lastTransition = variables[ZeebeVariableKeys.LastTransition].ToString();
        if (targetState is null || targetState.ToLower() == "default")
        {
            transition = instance.State.Transitions.Where(t => t.Name == lastTransition).FirstOrDefault();


        }
        else if (targetState.ToLower() == "error")
        {
            transition = await dbContext.Transitions.Include(i => i.ToState).ThenInclude(t => t!.Workflow)
                .ThenInclude(t => t!.Entities).Where(t => t.Name == lastTransition
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
                return Results.Problem($"Target state is not provided ");
                //throw new ZeebeBussinesException(errorMessage: $"Target state is not provided ");
            }

            error = true;
            IsTargetState = true;
            transition = await dbContext.Transitions.Include(i => i.ToState).ThenInclude(t => t!.Workflow)
                .ThenInclude(t => t!.Entities).Where(t => t.Name == lastTransition
           && instance.WorkflowName == t.ToState!.WorkflowName).FirstOrDefaultAsync(cancellationToken);

        }
        //var transitionData = JsonSerializer.Deserialize<dynamic>(body.GetProperty("LastTransitionData").ToString());
        if (transition is null)
        {
            return Results.Problem($"Transition not found with transition name : {lastTransition} ");
            //throw new ZeebeBussinesException(errorMessage: $"Transition not found with transition name : {transitionName} ");
        }

        if (!IsTargetState && transition != null && transition.ToStateName is null)
        {
            return Results.Problem($"Target state is not provided nor defined on transition");
            //throw new ZeebeBussinesException(errorMessage: $"Target state is not provided nor defined on transition");
        }
        return null;

    }
    public static async Task CallStateManager(WorkerBody workerBody, string targetState, long processInstanceKey, CancellationToken cancellationToken)
    {
        DaprClient daprClient = new DaprClientBuilder().Build();
        var stateId = "amorphie-workflow-zeebe.test-amorphie-workflow-zeebe";
        var stateRequest = daprClient.CreateInvokeMethodRequest(
                     HttpMethod.Post,
                      stateId,
                     "/exporter-set-state",
                     workerBody
                     );
        stateRequest.Headers.Add("TARGET_STATE", targetState);
        await daprClient.InvokeMethodAsync<string>(stateRequest, cancellationToken);

    }

    public static async Task SendHubMessage(PostSignalRData hubData, string subject, string instanceId,
    string deviceid, string tokenid, string customerid,
     CancellationToken cancellationToken)
    {
        DaprClient daprClient = new DaprClientBuilder().Build();


        if (!string.IsNullOrEmpty(HubUrl))
        {
            var signalRequest = daprClient.CreateInvokeMethodRequest<SignalRRequest>(
                      HttpMethod.Post,
                       HubUrl,
                      "sendExporterMessage/Public",
                      new SignalRRequest()
                      {
                          data = hubData,
                          source = "workflow",
                          type = "workflow",
                          subject = subject,
                          id = instanceId
                      }
                      );
            // string deviceid = "123";
            // string tokenid = "abc";
            // string customerid = "456";
            signalRequest.Headers.Add("X-Device-Id", deviceid);
            signalRequest.Headers.Add("X-Token-Id", tokenid);
            signalRequest.Headers.Add("A-Customer", customerid);
            signalRequest.Headers.Add("X-Request-Id", customerid);
            await daprClient.InvokeMethodAsync<string>(signalRequest, cancellationToken);


        }

    }
}