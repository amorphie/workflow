
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using amorphie.core.Base;
using amorphie.core.Enums;
using amorphie.core.IBase;
using amorphie.workflow.core.Dtos;
using Dapr.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;


public interface IPostTransactionService
{
    Task<IResponse> Init(string entity, Guid recordId, string transitionName, Guid user, Guid behalfOfUser, ConsumerPostTransitionRequest data);
    Task<IResponse> Execute();
}


public class PostTransactionService : IPostTransactionService
{
    private string _transitionName { get; set; }

    private Transition _transition { get; set; }
    private WorkflowDBContext _dbContext { get; set; }
    private IZeebeCommandService _zeebeService { get; set; }

    private Guid _user { get; set; }
    private Guid _behalfOfUser { get; set; }

    private string _entity { get; set; }
    private Guid _recordId { get; set; }
    private DaprClient _client { get; set; }

    private ConsumerPostTransitionRequest _data { get; set; }

    private List<Instance>? _activeInstances { get; set; }
    private IConfiguration _configuration { get; set; }

    public PostTransactionService(WorkflowDBContext dbContext, IZeebeCommandService zeebeService, DaprClient client, IConfiguration configuration)
    {
        _dbContext = dbContext;
        _zeebeService = zeebeService;
        _client = client;
        _transitionName = default!;
        _user = default!;
        _behalfOfUser = default!;
        _entity = default!;
        _recordId = default!;

        _transition = default!;
        _data = default!;
        _configuration = configuration;
    }

    public async Task<IResponse> Init(string entity, Guid recordId, string transitionName, Guid user, Guid behalfOfUser, ConsumerPostTransitionRequest data)
    {
        _entity = entity;
        _recordId = recordId;
        _transitionName = transitionName;
        _user = user;
        _behalfOfUser = behalfOfUser;
        _data = data;

        // var transition = _dbContext.Transitions.Find(_transitionName);
        var transition = await _dbContext.Transitions.Where(w => w.Name == _transitionName).Include(t => t.Page).ThenInclude(t => t!.Pages)
        .Include(s => s.FromState).ThenInclude(s => s.Workflow).ThenInclude(s => s!.Entities)
         .Include(s => s.ToState).ThenInclude(s => s!.Workflow).ThenInclude(s => s!.Entities)
        .FirstOrDefaultAsync();
        if (transition == null)
        {

            return new Response
            {
                Result = new Result(Status.Error, $"{_transitionName} is not found."),
            };
        }
        else
        {
            _transition = transition;
        }

        // Load all running instances of record
        _activeInstances = await _dbContext.Instances.Where(i => i.EntityName == entity
        && i.RecordId == recordId
        && i.BaseStatus != StatusType.Completed).ToListAsync();

        if (!_activeInstances.Any(i => i.StateName == _transition.FromStateName) && !(_activeInstances.Count == 0 && _transition.FromState.Type == StateType.Start))
        {
            if (_transition.FromState.Type == StateType.Start && _transition.FromState.Workflow!.Entities.Any(a => a.IsStateManager == false))
            {

            }
            else
            {
                return new Response
                {
                    Result = new Result(Status.Error, $"There is an active workflow exists for {recordId} at different state."),
                };
            }

        }

        return new Response
        {
            Result = new Result(Status.Success, "Success"),
        };
    }

    public async Task<IResponse> Execute()
    {
        DateTime? started = DateTime.Now;
        var instanceAtState = _activeInstances?.Where(i => i.StateName == _transition.FromStateName).FirstOrDefault();

        // There is no active instance at submited state
        if (instanceAtState == null)
        {
            _dbContext.Entry(_transition).Reference(t => t.FromState).Load();

            if (_transition.FromState.Type == StateType.Start)
            {

                if (string.IsNullOrEmpty(_transition.FlowName))
                {
                    return await noFlowNoInstance(started);
                }
                else
                {
                    return hasFlowNoInstance();
                }
            }
            else
            {
                return new Response
                {
                    Result = new Result(Status.Error, _transition.ServiceName + $"There is no active workflow for {_recordId} and also {_transition.Name} is not transition of any start state."),
                };
            }
        }
        else
        {
            if (string.IsNullOrEmpty(_transition.FlowName))
            {

                return await noFlowHasInstance(instanceAtState, started);
            }
            else
            {
                return hasFlowHasInstance(instanceAtState);
            }
        }
    }

    private async Task<IResponse> noFlowNoInstance(DateTime? started)
    {

        _dbContext.Entry(_transition).Reference(t => t.ToState).Load();
        //Create an instace for request.
        var newInstance = new Instance
        {
            WorkflowName = _transition.FromState.WorkflowName!,
            EntityName = _entity,
            RecordId = _recordId,
            StateName = _transition.ToStateName!,
            BaseStatus = _transition.ToState!.BaseStatus,
            CreatedBy = _user,
            CreatedByBehalfOf = _behalfOfUser,
        };

        // _dbContext.Add(newInstance);

        // addInstanceTansition(newInstance);
        // _dbContext.SaveChanges();

        return await ServiceKontrol(newInstance, false, started);
        //return Results.Ok();
    }

    private async Task<IResponse> noFlowHasInstance(Instance instanceAtState, DateTime? started)
    {

        _dbContext.Entry(_transition).Reference(t => t.ToState).Load();

        return await ServiceKontrol(instanceAtState, true, started);


    }

    private IResponse hasFlowNoInstance()
    {
        DateTime started = DateTime.Now;
        _dbContext.Entry(_transition).Reference(t => t.Flow).Load();

        var newInstance = new Instance
        {
            WorkflowName = _transition.FromState.WorkflowName!,
            EntityName = _entity,
            RecordId = _recordId,
            StateName = _transition.FromStateName!,
            BaseStatus = StatusType.LockedInFlow,
            CreatedBy = _user,
            ZeebeFlow = _transition.Flow,
            ZeebeFlowName = _transition.FlowName,
            CreatedByBehalfOf = _behalfOfUser,
        };

        dynamic variables = createMessageVariables(newInstance);



        _dbContext.Add(newInstance);

        addInstanceTansition(newInstance, started, null);
        _dbContext.SaveChanges();
        SendSignalRData(newInstance, "worker-started", string.Empty);
        _zeebeService.PublishMessage(_transition.Flow!.Message, variables, null, _transition.Flow!.Gateway);
        return new Response
        {
            Result = new Result(Status.Success, "Instance Has been Created"),
        };
    }

    private IResponse hasFlowHasInstance(Instance instanceAtState)
    {
        _dbContext.Entry(_transition).Reference(t => t.ToState).Load();
        _dbContext.Entry(_transition).Reference(t => t.Flow).Load();
        DateTime started = DateTime.Now;
        instanceAtState.StateName = _transition.FromStateName!;
        instanceAtState.ModifiedBy = _user;
        instanceAtState.ModifiedByBehalfOf = _behalfOfUser;
        instanceAtState.ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc);
        instanceAtState.BaseStatus = StatusType.LockedInFlow;

        dynamic variables = createMessageVariables(instanceAtState);



        addInstanceTansition(instanceAtState, started, null);
        _dbContext.SaveChanges();
        _zeebeService.PublishMessage(_transition.Flow!.Message, variables, instanceAtState.Id.ToString(), _transition.Flow!.Gateway);
        SendSignalRData(instanceAtState, "worker-started", string.Empty);
        //return Results.Ok();
        return new Response
        {
            Result = new Result(Status.Success, "Instance Has been Updated"),
        };
    }

    private dynamic createMessageVariables(Instance instanceAtState)
    {
        dynamic variables = new Dictionary<string, dynamic>();

        variables.Add("EntityName", _entity);
        variables.Add("RecordId", _recordId);
        variables.Add("InstanceId", instanceAtState.Id);
        variables.Add("LastTransition", _transitionName);

        dynamic targetObject = new ExpandoObject();
        targetObject.Data = _data;
        targetObject.TriggeredBy = _user;
        targetObject.TriggeredByBehalfOf = _behalfOfUser;

        variables.Add($"TRX-{_transitionName}", targetObject);
        return variables;
    }

    private void addInstanceTansition(Instance instance, DateTime? started, DateTime? finished)
    {
        var newInstanceTransition = new InstanceTransition
        {
            InstanceId = instance.Id,
            FromStateName = _transition.FromStateName,
            ToStateName = _transition.ToStateName!,
            EntityData = Convert.ToString(_data.EntityData),
            FormData = Convert.ToString(_data.FormData),
            AdditionalData = Convert.ToString(_data.AdditionalData),
            QueryData = Convert.ToString(_data.QueryData),
            RouteData = Convert.ToString(_data.RouteData),
            CreatedBy = _user,
            CreatedByBehalfOf = _behalfOfUser,
            TransitionName = _transition.Name,
            StartedAt = started,
            FinishedAt = finished
        };

        _dbContext.Add(newInstanceTransition);
    }
    private async Task<IResponse> ServiceKontrol(Instance instance, bool hasInstance, DateTime? started)
    {
        if (!string.IsNullOrEmpty(_transition.ServiceName))
        {
            ClientFactory _factory = new ClientFactory();
            var clientFactory = _factory.CreateClient(_transition.ServiceName);
            try
            {

                SendTransitionInfoRequest request = new SendTransitionInfoRequest()
                {
                    recordId = instance.RecordId,
                    newStatus = _transition.ToStateName!,
                    entityData = _data.EntityData,
                    user = _user,
                    behalfOfUser = _behalfOfUser,
                    workflowName = instance.WorkflowName
                };
                var response = await clientFactory.PostModel(request);
                try
                {


                    if (response.StatusCode == System.Net.HttpStatusCode.OK ||
                          response.StatusCode == System.Net.HttpStatusCode.Created
                           || response.StatusCode == System.Net.HttpStatusCode.NotModified
                        )
                    {
                        return UpdateInstance(instance, hasInstance, started);
                    }
                    else
                    {
                        string hubMessage = string.Empty;
                        try
                        {
                            var problem = Newtonsoft.Json.JsonConvert.DeserializeObject<Refit.ProblemDetails>(response.Error!.Content!);
                            hubMessage += problem!.Detail;
                        }
                        catch (Exception ex)
                        {
                            hubMessage += response.ReasonPhrase;
                        }

                        SendSignalRData(instance, "transition-completed-with-error", hubMessage);
                        return new Response
                        {
                            Result = new Result(Status.Error, ""),
                        };
                    }

                }
                catch (Exception ex)
                {
                    SendSignalRData(instance, "transition-completed-with-error", string.Empty);
                    return new Response
                    {
                        Result = new Result(Status.Error, ""),
                    };
                }


            }
            catch (Exception ex)
            {
                SendSignalRData(instance, "transition-completed-with-error", "unexpected error");
                return new Response
                {
                    Result = new Result(Status.Error, "unexpected error:" + ex.ToString()),
                };
            }
        }
        else
        {
            return UpdateInstance(instance, hasInstance, started);
        }
    }

    private IResponse UpdateInstance(Instance instance, bool hasInstance, DateTime? started)
    {
        if (hasInstance)
        {
            instance.StateName = _transition.ToStateName!;
            instance.ModifiedBy = _user;
            instance.ModifiedByBehalfOf = _behalfOfUser;
            instance.ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc);
            instance.BaseStatus = _transition.ToState!.BaseStatus;
            if (instance.WorkflowName != _transition.ToState.WorkflowName)
            {
                instance.WorkflowName = _transition.ToState!.WorkflowName!;
                if (!_transition.ToState.Workflow!.Entities.Any(a => a.Name == instance.EntityName))
                {
                    instance.EntityName = _transition.ToState.Workflow.Entities.FirstOrDefault()!.Name;
                }
            }
        }
        else
        {
            _dbContext.Add(instance);
        }

        addInstanceTansition(instance, started, DateTime.Now);
        _dbContext.SaveChanges();
        SendSignalRData(instance, "transition-completed", string.Empty);
        return new Response
        {
            Result = new Result(Status.Success, "Instance has been updated"),
        };
    }
    private void SendSignalRData(Instance instance, string eventInfo, string message)
    {
        try
        {
            string hubUrl = _configuration["hubUrl"]!.ToString();
            var responseSignalR = _client.InvokeMethodAsync<PostSignalRData, string>(
                      HttpMethod.Post,
                      hubUrl,
                      "sendMessage",
                      new PostSignalRData(
                          _user,
                          instance.RecordId,
                         eventInfo,
                          instance.Id,
                          instance.EntityName,
                        _data.EntityData, DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), instance.StateName, _transitionName, instance.BaseStatus,
                        _transition.Page == null ? null : eventInfo == "worker-started" ? null :
                        new PostPageSignalRData(_transition.Page.Operation.ToString(), _transition.Page.Type.ToString(), _transition.Page.Pages == null || _transition.Page.Pages.Count == 0 ? null : new MultilanguageText(_transition.Page.Pages!.FirstOrDefault()!.Language, _transition.Page.Pages!.FirstOrDefault()!.Label),
                        _transition.Page.Timeout), message, _data.AdditionalData

                      ));
        }
        catch (Exception ex)
        {

        }

    }

}