
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Text;
using amorphie.core.Base;
using amorphie.core.Enums;
using amorphie.core.IBase;
using amorphie.workflow.core.Constants;
using amorphie.workflow.core.Dtos;
using amorphie.workflow.core.Dtos.Consumer;
using amorphie.workflow.core.Enums;
using amorphie.workflow.core.Models;
using amorphie.workflow.service.Zeebe;
using Dapr.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;



public interface IPostTransactionService
{
    Task<IResponse> Init(string entity, Guid recordId, string transitionName, Guid user, Guid behalfOfUser, ConsumerPostTransitionRequest data, IHeaderDictionary? headerParameters, CancellationToken cancellationToken);
    Task<IResponse> InitWithoutEntity(Guid instanceId, string transitionName, Guid user, Guid behalfOfUser, dynamic data, IHeaderDictionary? headerParameters, CancellationToken cancellationToken);
    Task<IResponse> Execute();
    Task<IResponse> ExecuteWithoutEntity();
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
    private Guid _instanceId { get; set; }
    private DaprClient _client { get; set; }

    private ConsumerPostTransitionRequest _data { get; set; }

    private List<Instance>? _activeInstances { get; set; }
    private Instance? _activeInstance { get; set; }
    private IConfiguration _configuration { get; set; }
    private IHeaderDictionary? _headerParameters { get; set; }
    private dynamic? headers { get; set; }
    private dynamic? mfaType { get; set; } = MFATypeEnum.Public.ToString();
    private Dictionary<string, string> _headerDict { get; set; }
    private CancellationToken _cancellationToken { get; set; }

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

    public async Task<IResponse> Init(string entity, Guid recordId, string transitionName, Guid user, Guid behalfOfUser, ConsumerPostTransitionRequest data, IHeaderDictionary? headerParameters,
    CancellationToken cancellationToken)
    {
        _entity = entity;
        _recordId = recordId;
        _transitionName = transitionName;
        _user = user;
        _behalfOfUser = behalfOfUser;
        _data = data;
        _headerParameters = headerParameters;
        _cancellationToken=cancellationToken;
        // var transition = _dbContext.Transitions.Find(_transitionName);
        var Control = await TransitionControl(_transitionName);
        if (Control!.Result.Status == Status.Error.ToString())
        {

            return Control;
        }


        // Load all running instances of record
        _activeInstances = await _dbContext.Instances.Where(i => i.EntityName == entity
        && i.RecordId == recordId
        && i.BaseStatus != StatusType.Completed).Include(s => s.State).Include(w => w.Workflow).OrderByDescending(o => o.CreatedAt).ToListAsync();
        Instance? lastInstance = _activeInstances.FirstOrDefault();
        _instanceId = lastInstance != null ? lastInstance.Id : Guid.NewGuid();
        return await InstanceControl(lastInstance, recordId);
    }

    public async Task<IResponse> InitWithoutEntity(Guid instanceId, string transitionName, Guid user, Guid behalfOfUser, dynamic data, IHeaderDictionary? headerParameters, CancellationToken cancellationToken)
    {
        _transitionName = transitionName;
        _user = user;
        _behalfOfUser = behalfOfUser;
        _headerParameters = headerParameters;
        _instanceId = instanceId;
        _recordId = instanceId;
        _cancellationToken=cancellationToken;
        ConsumerPostTransitionRequest request = new ConsumerPostTransitionRequest()
        {
            EntityData = data,
            AdditionalData = new { },
            GetSignalRHub = true

        };
        _data = request;
        var Control = await TransitionControl(_transitionName);
        if (Control!.Result.Status == Status.Error.ToString())
        {

            return Control;
        }
        //TODO Taner: Entity olmadan instance başlattı instance üzerinden devam etmeyip sonrasında consumer üzerinden(entity ile) devam ederse oluşacak hatayı gidermek amacıyla yapıldı.
        //Bu durum ortadan kalktığında kaldırılacak
        WorkflowEntity? entity = _transition.FromState.Workflow!.Entities.OrderByDescending(c => c.Name).FirstOrDefault();
        _entity = entity != null ? entity.Name : string.Empty;
        _activeInstance = await _dbContext.Instances.Where(i => i.Id == instanceId)
        .Include(s => s.State).Include(w => w.Workflow).OrderByDescending(o => o.CreatedAt).FirstOrDefaultAsync(cancellationToken);
        _activeInstances = new List<Instance>();
        if (_activeInstance != null)
            _activeInstances.Add(_activeInstance);

        return await InstanceControl(_activeInstance, _instanceId);
    }
    private async Task<IResponse?> TransitionControl(string transitionName)
    {
        // _entity = entity;
        // _recordId = recordId;
        // _transitionName = transitionName;
        // _user = user;
        // _behalfOfUser = behalfOfUser;
        // _data = data;
        // _headerParameters = headerParameters;
        // _instanceId=instanceId;
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
        if (transition != null)
        {
            _transition = transition;
            return new Response
            {
                Result = new Result(Status.Success, "Success"),
            };
        }
        return new Response
        {
            Result = new Result(Status.Error, "Not Found transition"),
        };

    }
    private async Task<IResponse> InstanceControl(Instance? lastInstance, Guid id)
    {
        if (lastInstance != null && lastInstance.Workflow.WorkflowStatus == WorkflowStatus.Deactive)
        {
            return new Response
            {
                Result = new Result(Status.Error, $"{lastInstance.WorkflowName} is deactive flow."),
            };
        }
        if (!_activeInstances.Any(i => i.StateName == _transition.FromStateName) && !(_activeInstances.Count == 0 && _transition.FromState.Type == StateType.Start))
        {
            if ((_transition.FromState.Type == StateType.Start &&
            (
                (_transition.FromState.Workflow!.Entities.Any(a => a.IsStateManager == false))
            || (lastInstance.State.Type == StateType.SubWorkflow)

            )) || (_transition.transitionButtonType == TransitionButtonType.Back || _transition.transitionButtonType == TransitionButtonType.Cancel))
            {

            }
            else
            {
                return new Response
                {
                    Result = new Result(Status.Error, $"There is an active workflow exists for {id} at different state."),
                };
            }

        }
        InstanceTransition? lastTrans = null;
        if (lastInstance != null)
        {
            lastTrans = await _dbContext.InstanceTransitions.Where(w => w.InstanceId == lastInstance.Id).OrderByDescending(c => c.CreatedAt).FirstOrDefaultAsync();
        }
        await SetHeaders(lastTrans);
        return new Response
        {
            Result = new Result(Status.Success, "Success"),
        };

    }


    public async Task<IResponse> Execute()
    {

        var instanceAtState = _activeInstances?.Where(i => i.StateName == _transition.FromStateName).FirstOrDefault();
        return await ExecuteWithInstance(instanceAtState, _recordId, ExecuteFlowMethod.RecordId);

    }
    public async Task<IResponse> ExecuteWithoutEntity()
    {

        return await ExecuteWithInstance(_activeInstance, _instanceId, ExecuteFlowMethod.InstanceId);

    }
    private async Task<IResponse> ExecuteWithInstance(Instance? instanceAtState, Guid id, ExecuteFlowMethod executeMethod)
    {
        DateTime? started = DateTime.UtcNow;
        if (instanceAtState == null)
        {
            _dbContext.Entry(_transition).Reference(t => t.FromState).Load();

            if (_transition.FromState.Type == StateType.Start)
            {

                if (string.IsNullOrEmpty(_transition.FlowName))
                {
                    mfaType = _transition.ToState.MFAType.GetValueOrDefault(MFATypeEnum.Public).ToString().ToLower();
                    return await noFlowNoInstance(started);
                }
                else
                {
                    mfaType = _transition.FromState.MFAType.GetValueOrDefault(MFATypeEnum.Public).ToString().ToLower();
                    return await hasFlowNoInstance();
                }
            }
            else
            {
                return new Response
                {
                    Result = new Result(Status.Error, _transition.ServiceName + $"There is no active workflow for {id} and also {_transition.Name} is not transition of any start state."),
                };
            }
        }
        else
        {
            if (string.IsNullOrEmpty(_transition.FlowName))
            {
                mfaType = _transition.ToState.MFAType.GetValueOrDefault(MFATypeEnum.Public).ToString().ToLower();
                return await noFlowHasInstance(instanceAtState, started);
            }
            else
            {
                mfaType = _transition.FromState.MFAType.GetValueOrDefault(MFATypeEnum.Public).ToString().ToLower();
                return await hasFlowHasInstance(instanceAtState);
            }
        }
    }

    private async Task<IResponse> noFlowNoInstance(DateTime? started)
    {

        _dbContext.Entry(_transition).Reference(t => t.ToState).Load();
        string UserReference = string.Empty;
        try
        {
            if (!_headerDict.TryGetValue("user_reference", out UserReference))
                UserReference = string.Empty;
        }
        catch (Exception)
        {
            UserReference = string.Empty;
        }
        //Create an instace for request.
        var newInstance = new Instance
        {
            Id = _instanceId,
            WorkflowName = _transition.FromState.WorkflowName!,
            EntityName = _entity,
            RecordId = _recordId,
            StateName = _transition.ToStateName!,
            BaseStatus = _transition.ToState!.BaseStatus,
            CreatedBy = _user,
            UserReference = UserReference,
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

    private async Task<IResponse> hasFlowNoInstance()
    {
        DateTime started = DateTime.UtcNow;
        _dbContext.Entry(_transition).Reference(t => t.Flow).Load();
        string UserReference = string.Empty;
        try
        {
            if (!_headerDict.TryGetValue("user_reference", out UserReference))
                UserReference = string.Empty;
        }
        catch (Exception ex)
        {
            UserReference = string.Empty;
        }
        var newInstance = new Instance
        {
            Id = _instanceId,
            WorkflowName = _transition.FromState.WorkflowName!,
            EntityName = _entity,
            RecordId = _recordId,
            StateName = _transition.FromStateName!,
            BaseStatus = StatusType.LockedInFlow,
            CreatedBy = _user,
            ZeebeFlow = _transition.Flow,
            ZeebeFlowName = _transition.FlowName,
            UserReference = UserReference,
            CreatedByBehalfOf = _behalfOfUser,
        };
        dynamic variables = createMessageVariables(newInstance);



        await _dbContext.AddAsync(newInstance,_cancellationToken);

        await addInstanceTansition(newInstance, started, null);
        await _dbContext.SaveChangesAsync(_cancellationToken);
        SendSignalRData(newInstance, EventInfos.WorkerStarted, string.Empty);
        await _zeebeService.PublishMessage(_transition.Flow!.Message, variables, null, _transition.Flow!.Gateway);
        return new Response
        {
            Result = new Result(Status.Success, "Instance Has been Created"),
        };
    }

    private async Task<IResponse> hasFlowHasInstance(Instance instanceAtState)
    {
        _dbContext.Entry(_transition).Reference(t => t.ToState).Load();
        _dbContext.Entry(_transition).Reference(t => t.Flow).Load();
        DateTime started = DateTime.UtcNow;
        instanceAtState.StateName = _transition.FromStateName!;
        instanceAtState.ModifiedBy = _user;
        instanceAtState.ModifiedByBehalfOf = _behalfOfUser;
        instanceAtState.ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc);
        instanceAtState.BaseStatus = StatusType.LockedInFlow;

        dynamic variables = createMessageVariables(instanceAtState);


        string message=_transition.Flow!.Message;
        await addInstanceTansition(instanceAtState, started, null);
        await _dbContext.SaveChangesAsync(_cancellationToken);
        HumanTask? humanTask= await _dbContext.HumanTasks.FirstOrDefaultAsync(f=>f.State== instanceAtState.StateName
        &&f.InstanceId==instanceAtState.Id&&f.Status!=HumanTaskStatus.Completed&&f.Status!=HumanTaskStatus.Denied,_cancellationToken);
        if(humanTask!=null)
        {
            message=HumanTaskZeebeCommand.humanTaskMessage;
            variables.Add($"humanTaskMessageValue", _transition.Name);
        }
        _zeebeService.PublishMessage(message, variables, instanceAtState.Id.ToString(), _transition.Flow!.Gateway);
        SendSignalRData(instanceAtState, EventInfos.WorkerStarted, string.Empty);
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

        string updateName = deleteUnAllowedCharecters(_transitionName);
        variables.Add($"TRX-{_transitionName}", targetObject);
        variables.Add($"TRX{updateName}", targetObject);
        variables.Add($"Headers", headers);
        return variables;
    }
    private static string deleteUnAllowedCharecters(string transitionName)
    {
        return System.Text.RegularExpressions.Regex.Replace(transitionName, "[^A-Za-z0-9]", "", System.Text.RegularExpressions.RegexOptions.Compiled);
    }
    private async Task addInstanceTansition(Instance instance, DateTime? started, DateTime? finished)
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
            HeadersData = Convert.ToString(headers),
            CreatedBy = _user,
            CreatedByBehalfOf = _behalfOfUser,
            TransitionName = _transition.Name,
            StartedAt = started,
            FinishedAt = finished
        };

       await _dbContext.AddAsync(newInstanceTransition,_cancellationToken);
    }
    private async Task<IResponse> ServiceKontrol(Instance instance, bool hasInstance, DateTime? started)
    {
        if (!string.IsNullOrEmpty(_transition.ServiceName))
        {
            ClientFactory _factory = new();
            var clientFactory = _factory.CreateClient(_transition.ServiceName);
            try
            {

                SendTransitionInfoRequest request = new()
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
                        return await UpdateInstance(instance, hasInstance, started);
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

                        SendSignalRData(instance, EventInfos.TransitionCompletedWithError, hubMessage);
                        return new Response
                        {
                            Result = new Result(Status.Error, ""),
                        };
                    }

                }
                catch (Exception ex)
                {
                    SendSignalRData(instance, EventInfos.TransitionCompletedWithError, string.Empty);
                    return new Response
                    {
                        Result = new Result(Status.Error, ""),
                    };
                }


            }
            catch (Exception ex)
            {
                SendSignalRData(instance, EventInfos.TransitionCompletedWithError, "unexpected error");
                return new Response
                {
                    Result = new Result(Status.Error, "unexpected error:" + ex.ToString()),
                };
            }
        }
        else
        {
            return await UpdateInstance(instance, hasInstance, started);
        }
    }

    private async Task<IResponse> UpdateInstance(Instance instance, bool hasInstance, DateTime? started)
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
                if (_transition.ToState.Workflow!.Entities.All(a => a.Name != instance.EntityName))
                {
                    instance.EntityName = _transition.ToState.Workflow.Entities.FirstOrDefault()!.Name;
                }
            }
        }
        else
        {
          await  _dbContext.AddAsync(instance,_cancellationToken);
        }

        await addInstanceTansition(instance, started, DateTime.UtcNow);
        await _dbContext.SaveChangesAsync(_cancellationToken);
        SendSignalRData(instance, EventInfos.TransitionCompleted, string.Empty);
        return new Response
        {
            Result = new Result(Status.Success, "Instance has been updated"),
        };
    }
    private void SendSignalRData(Instance instance, string eventInfo, string message)
    {
        try
        {
            string pageTypeStringBYTransition = string.Empty;
            if (_transition.Page != null)
                try
                {

                    pageTypeStringBYTransition = amorphie.workflow.core.Helper.EnumHelper.GetDescription<NavigationType>(((NavigationType)_transition.Page.Type));
                }
                catch (Exception)
                {
                    pageTypeStringBYTransition = string.Empty;
                }
            string hubUrl = _configuration["hubUrl"]!.ToString();
            // var responseSignalR = _client.InvokeMethodAsync<PostSignalRData, string>(
            //           HttpMethod.Post,
            //           hubUrl,
            //           "sendMessage",
            //           new PostSignalRData(
            //               _user,
            //               instance.RecordId,
            //              eventInfo,
            //               instance.Id,
            //               instance.EntityName,
            //             _data.EntityData, DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), instance.StateName, _transitionName, instance.BaseStatus,
            //             _transition.Page == null ? null : eventInfo == "worker-started" ? null :
            //             new PostPageSignalRData(_transition.Page.Operation.ToString(), pageTypeStringBYTransition, _transition.Page.Pages == null || _transition.Page.Pages.Count == 0 ? null : new amorphie.workflow.core.Dtos.MultilanguageText(_transition.Page.Pages!.FirstOrDefault()!.Language, _transition.Page.Pages!.FirstOrDefault()!.Label),
            //             _transition.Page.Timeout), message, string.Empty, _data.AdditionalData, instance.WorkflowName, _transition.ToState.IsPublicForm == true ? "state" : "transition", _transition.requireData.GetValueOrDefault(false), _transition.transitionButtonType == 0 ? TransitionButtonType.Forward.ToString() : _transition.transitionButtonType.GetValueOrDefault(TransitionButtonType.Forward).ToString()

            //           ));
            bool routeChange = false;
            if (eventInfo == EventInfos.WorkerStarted || _transition.Page == null)
            {
                routeChange = false;
            }
            else if (_transition.Page != null && _transition.Page.Pages != null && _transition.Page.Pages.Count > 0)
            {
                routeChange = true;
            }
            var responseSignalRMFAtype = _client.CreateInvokeMethodRequest<SignalRRequest>(
                      HttpMethod.Post,
                      hubUrl,
                      "sendMessage/" + mfaType,
                      new SignalRRequest()
                      {
                          data = new PostSignalRData(
                            _user,
                          instance.RecordId,
                         eventInfo,
                          instance.Id,
                          instance.EntityName,
                        _data.EntityData, DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc), instance.StateName, _transitionName, null, instance.BaseStatus,
                        _transition.Page == null ? null : eventInfo == EventInfos.WorkerStarted ? null :
                        new PostPageSignalRData(_transition.Page.Operation.ToString(), pageTypeStringBYTransition, _transition.Page.Pages == null || _transition.Page.Pages.Count == 0 ? null : new amorphie.workflow.core.Dtos.MultilanguageText(_transition.Page.Pages!.FirstOrDefault()!.Language, _transition.Page.Pages!.FirstOrDefault()!.Label),
                        _transition.Page.Timeout), message, string.Empty, _data.AdditionalData, instance.WorkflowName, _transition.ToState.IsPublicForm == true ? "state" : "transition", _transition.requireData.GetValueOrDefault(false), _transition.transitionButtonType == 0 ? TransitionButtonType.Forward.ToString() : _transition.transitionButtonType.GetValueOrDefault(TransitionButtonType.Forward).ToString()

                      ),
                          source = "workflow",
                          type = "workflow",
                          subject = eventInfo,
                          id = instance.Id.ToString(),
                          routeChange = routeChange


                      }
                          );
            string deviceID = string.Empty;
            string tokenID = string.Empty;
            string customer = string.Empty;


            if (_headerDict.TryGetValue("xdeviceid", out deviceID))
                responseSignalRMFAtype.Headers.Add("X-Device-Id", deviceID);
            if (_headerDict.TryGetValue("xtokenid", out tokenID))
                responseSignalRMFAtype.Headers.Add("X-Token-Id", tokenID);
            if (_headerDict.TryGetValue("acustomer", out customer))
                responseSignalRMFAtype.Headers.Add("A-Customer", customer);


            var generarlSignalR = _client.InvokeMethodAsync<string>(responseSignalRMFAtype);



        }
        catch (Exception ex)
        {


        }

    }
    private async ValueTask<bool> SetHeaders(InstanceTransition? lastTransition)
    {
        List<string> listFlowHeaders = await _dbContext.FlowHeaders.Select(s => s.Key.Replace("-", string.Empty).ToLower()).ToListAsync();
        Dictionary<string, string> headerDict
         = _headerParameters.Where(w => listFlowHeaders.Contains(w.Key.Replace("-", string.Empty).ToLower())).ToDictionary(a => a.Key.Replace("-", string.Empty).ToLower(), a => string.Join(";", a.Value));
        if (lastTransition != null)
        {
            Dictionary<string, string> lastTrDict = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, string>>(lastTransition.HeadersData);

            headerDict = headerDict.Concat(lastTrDict.Where(x => !headerDict.Keys.Contains(x.Key.Replace("-", string.Empty).ToLower()))).ToDictionary(x => x.Key.Replace("-", string.Empty).ToLower(), x => x.Value);
        }
        var serialize = System.Text.Json.JsonSerializer.Serialize(headerDict.ToDictionary(x => x.Key.Replace("-", string.Empty), x => x.Value));
        headers = System.Text.Json.JsonSerializer.Deserialize<dynamic?>(serialize);
        _headerDict = headerDict;
        return true;
    }
}

