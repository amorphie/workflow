using System.Dynamic;
using amorphie.core.Base;
using amorphie.core.Enums;
using amorphie.core.IBase;
using amorphie.workflow.core.Dtos;
using amorphie.workflow.core.Dtos.Consumer;
using amorphie.workflow.core.Enums;
using amorphie.workflow.service.SignalR;
using amorphie.workflow.service.Variable;
using amorphie.workflow.service.Zeebe;
using amorphie.workflow.service.Db.Abstracts;
using Dapr.Client;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Linq.Expressions;
using amorphie.workflow.core.Models;

namespace amorphie.workflow.service.Db;
public partial class InstanceService : IInstanceService
{

    private readonly WorkflowDBContext _dbContext;
    private readonly IInstanceTransitionService _instanceTransitionService;
    private readonly IZeebeCommandService _zeebeService;

    private readonly DaprClient _client;

    private readonly IConfiguration _configuration;

    public InstanceService(WorkflowDBContext dbContext, IZeebeCommandService zeebeService, DaprClient client, IConfiguration configuration, IInstanceTransitionService instanceTransition)
    {
        _dbContext = dbContext;
        _zeebeService = zeebeService;
        _client = client;

        _configuration = configuration;
        _instanceTransitionService = instanceTransition;
    }

    public async Task<bool> IsRouteDefined(string targetTransitionOrStateName, CancellationToken cancellationToken)
    {
        return await _dbContext.StateToStates.AnyAsync(p => p.FromStateName == targetTransitionOrStateName);
    }

    public async Task<IResponse> TriggerFlowAsync(Guid instanceId, string targetTransitionOrStateName, Guid user, Guid behalfOfUser, dynamic data, IHeaderDictionary? headerParameters, CancellationToken cancellationToken)
    {

        var commitResult = await CommitInstanceAndState(targetTransitionOrStateName, instanceId, user, behalfOfUser, cancellationToken);
        if (commitResult.HasError)
        {
            return Response.Error(commitResult.Message);
        }
        var instance = commitResult.Instance;
        var targetState = commitResult.State;

        ConsumerPostTransitionRequest request = new ConsumerPostTransitionRequest()
        {
            EntityData = data,
            AdditionalData = new { },
            GetSignalRHub = true
        };
        var headers = await SetHeaders(instanceId, headerParameters);
        _instanceTransitionService.Insert(instance!, request, headers, DateTime.UtcNow, DateTime.UtcNow, user, behalfOfUser);

        _dbContext.SaveChanges();
        if (targetState?.Kind == StateKind.Transition)
        {
            dynamic variables = VariableService.CreateMessageVariables(instance!, request, headers);
            _zeebeService.PublishMessage(targetTransitionOrStateName, variables, instance!.Id.ToString());
        }
        string hubUrl = _configuration["hubUrl"]!.ToString();
        var requestTrx = new WorkerBodyTrxInnerDatas { EntityData = data };
        await SignalRService.SendSignalRDataAsync(instance!, requestTrx, "worker-started", string.Empty, hubUrl, _client, headers);
        return Response.Success("Instance triggered");
    }

    public async Task<Response> ChangeInstanceStateAsync(Guid instanceId, string targetTransitionOrStateName, WorkerBodyTrxDatas workerBodyTrxDatas, CancellationToken cancellationToken)
    {
        var commitResult = await CommitInstanceAndState(targetTransitionOrStateName, instanceId, workerBodyTrxDatas.TriggeredBy.GetValueOrDefault(Guid.Empty), workerBodyTrxDatas.TriggeredByBehalfOf.GetValueOrDefault(Guid.Empty), cancellationToken);
        if (commitResult.HasError)
        {
            return Response.Error(commitResult.Message);
        }
        var instance = commitResult.Instance;
        _instanceTransitionService.Insert(instance!, workerBodyTrxDatas.Data!, DateTime.UtcNow, DateTime.UtcNow, workerBodyTrxDatas.TriggeredBy.GetValueOrDefault(Guid.Empty), workerBodyTrxDatas.TriggeredByBehalfOf.GetValueOrDefault(Guid.Empty));
        _dbContext.SaveChanges();
        return Response.Success("", instance!);
    }



    private async Task<Dictionary<string, string>> SetHeaders(Guid instanceId, IHeaderDictionary? headerParameters)
    {
        InstanceTransition? lastInstanceTransition = await _dbContext.InstanceTransitions.Where(w => w.InstanceId == instanceId).OrderByDescending(c => c.CreatedAt).FirstOrDefaultAsync();
        List<string> listFlowHeaders = await _dbContext.FlowHeaders.Select(s => s.Key.Replace("-", string.Empty).ToLower()).ToListAsync();
        Dictionary<string, string> headerDict = headerParameters
            .Where(w => listFlowHeaders.Contains(w.Key.Replace("-", string.Empty).ToLower())).ToDictionary(a => a.Key.Replace("-", string.Empty).ToLower(), a => string.Join(";", a.Value));
        if (lastInstanceTransition?.HeadersData != null)
        {
            Dictionary<string, string> lastTrDict = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, string>>(lastInstanceTransition.HeadersData);
            headerDict = headerDict.Concat(lastTrDict.Where(x => !headerDict.Keys.Contains(x.Key.Replace("-", string.Empty).ToLower()))).ToDictionary(x => x.Key.Replace("-", string.Empty).ToLower(), x => x.Value);
        }
        //var serialize = System.Text.Json.JsonSerializer.Serialize(headerDict.ToDictionary(x => x.Key.Replace("-", string.Empty), x => x.Value));
        return headerDict;
    }

    private async Task<InstanceAndStateCommitResult> CommitInstanceAndState(string targetTransitionOrStateName, Guid instanceId, Guid userId, Guid behalfOfUserId, CancellationToken cancellationToken)
    {
        var instance = await _dbContext.Instances.Where(i => i.Id == instanceId
               && i.BaseStatus != StatusType.Completed)
                   .Include(s => s.State)
                   .Include(w => w.Workflow).
                   FirstOrDefaultAsync(cancellationToken);

        State? targetState = null;
        //Not null nor default
        if (!(targetTransitionOrStateName is null || targetTransitionOrStateName.ToLower() == "default" || targetTransitionOrStateName.ToLower() == "error"))
        {
            targetState = await _dbContext.States.FirstOrDefaultAsync(i => i.Name == targetTransitionOrStateName);
            if (targetState == null)
            {
                return new InstanceAndStateCommitResult(true, $"{targetTransitionOrStateName} target state is not defined", null, null);
            }
        }
        //if same state is intending then let it flow
        if (instance?.StateName == targetTransitionOrStateName)
        {
            return new InstanceAndStateCommitResult(false, "", instance, targetState);
        }
        if (instance == null && targetState?.Type != StateType.Start)
        {
            return new InstanceAndStateCommitResult(true, $"No instance found with {instanceId} instance id", null, null);
        }
        if (instance == null && targetState?.Type == StateType.Start)
        {
            //Create an instace for request.
            instance = new Instance
            {
                Id = instanceId,
                WorkflowName = targetState.WorkflowName!,
                EntityName = "",
                RecordId = instanceId,
                StateName = targetState.Name,
                BaseStatus = targetState.BaseStatus,
                CreatedBy = userId,
                ModifiedBy = userId,
                UserReference = "",
                CreatedByBehalfOf = behalfOfUserId,
            };
        }
        else if (instance != null)
        {
            var updateResult = await UpdateInstance(instance, targetState, targetTransitionOrStateName, cancellationToken);
            instance.ModifiedBy = userId;
            instance.ModifiedByBehalfOf = behalfOfUserId;
            if (updateResult.HasError) return updateResult;
        }
        return new InstanceAndStateCommitResult(false, "", instance, targetState);
    }
    private async Task<InstanceAndStateCommitResult> UpdateInstance(Instance instance, State? targetState, string targetTransitionOrStateName, CancellationToken cancellationToken)
    {
        //check
        Expression<Func<StateToState, bool>> stateToStatePredicate;
        //if popping up from subflow
        //TODO: extend the rules for popping up
        if (targetState != null && instance.WorkflowName != targetState.WorkflowName)
        {
            instance.WorkflowName = targetState.WorkflowName!;
        }
        //if pushing into subflow
        else if (instance.State?.Type == StateType.SubWorkflow)
        {
            //is -instance's last setted state- subworkflow ? 
            if (targetState != null && targetState.Type == StateType.Start)
            {
                instance.WorkflowName = targetState.WorkflowName!;
            }
            else
            {
                return new InstanceAndStateCommitResult(true, $"{targetTransitionOrStateName} target state is not type of start (100) for subflow", null, null);
            }
        }
        else
        {
            if (targetTransitionOrStateName == "error")
            {
                targetState = await _dbContext.States.FirstOrDefaultAsync(i => i.Type == StateType.Fail && i.WorkflowName == instance.WorkflowName);
                if (targetState == null)
                {
                    return new InstanceAndStateCommitResult(true, $"No error state defined for {instance.WorkflowName}", null, null);
                }
            }
            else
            {
                //if target state not provided or provided as default default get default target of current state.
                if (targetTransitionOrStateName is null || targetTransitionOrStateName.ToLower() == "default")
                {
                    stateToStatePredicate = i => i.FromStateName == instance.StateName && i.IsDefault;
                }
                //otherwise try get defined target of current state if route exist
                else
                {
                    stateToStatePredicate = i => i.FromStateName == instance.StateName && i.ToStateName == targetTransitionOrStateName;
                }

                var stateToStates = await _dbContext.StateToStates.Where(stateToStatePredicate)
                    .Include(p => p.ToState)
                    .FirstOrDefaultAsync(cancellationToken);
                if (stateToStates == null)
                {
                    return new InstanceAndStateCommitResult(true, $"No route defined from {instance.StateName} to {targetTransitionOrStateName}", null, null);
                }
                //in case state name is (default or null) : targetstate will be null. set target state
                targetState = stateToStates.ToState;
            }
            //instance.ModifiedBy = user;
        }
        instance.StateName = targetState!.Name;
        instance.ModifiedAt = DateTime.UtcNow;
        return new InstanceAndStateCommitResult(false, "", instance, targetState);

    }

}

public record InstanceAndStateCommitResult(bool HasError, string Message, Instance? Instance, State? State);

