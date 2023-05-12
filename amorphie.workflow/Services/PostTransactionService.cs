
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using amorphie.core.Base;
using amorphie.core.Enums;
using amorphie.core.IBase;
using Dapr.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;


public interface IPostTransactionService
{
    IResponse Init(string entity, Guid recordId, string transitionName, Guid user, Guid behalfOfUser, ConsumerPostTransitionRequest data);
    IResponse Execute();
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

    public PostTransactionService(WorkflowDBContext dbContext, IZeebeCommandService zeebeService,DaprClient client)
    {
        _dbContext = dbContext;
        _zeebeService = zeebeService;
        _client=client;
        _transitionName = default!;
        _user = default!;
        _behalfOfUser = default!;
        _entity = default!;
        _recordId = default!;

        _transition = default!;
        _data = default!;
    }

    public IResponse Init(string entity, Guid recordId, string transitionName, Guid user, Guid behalfOfUser, ConsumerPostTransitionRequest data)
    {
        _entity = entity;
        _recordId = recordId;
        _transitionName = transitionName;
        _user = user;
        _behalfOfUser = behalfOfUser;
        _data = data;

        var transition = _dbContext.Transitions.Find(_transitionName);

        if (transition == null)
        {

             return new Response{
            Result=new Result(Status.Error,$"{_transitionName} is not found."),
            };
        }
        else
        {
            _transition = transition;
        }

        // Load all running instances of record
        _activeInstances = _dbContext.Instances.Where(i => i.EntityName == entity && i.RecordId == recordId && i.BaseStatus != StatusType.Completed).ToList();

        if (_activeInstances.Where(i => i.StateName != _transition.FromStateName).Count() > 0)
        {
            return new Response{
            Result=new Result(Status.Error,$"There is an active workflow exists for {recordId} at different state."),
            };
        }

        return new Response{
            Result=new Result(Status.Success,"Success"),
            };
    }

    public IResponse Execute()
    {
        var instanceAtState = _activeInstances?.Where(i => i.StateName == _transition.FromStateName).FirstOrDefault();

        // There is no active instance at submited state
        if (instanceAtState == null)
        {
            _dbContext.Entry(_transition).Reference(t => t.FromState).Load();

            if (_transition.FromState.Type == StateType.Start)
            {

                if (string.IsNullOrEmpty(_transition.FlowName))
                {
                    return noFlowNoInstance();
                }
                else
                {
                    return hasFlowNoInstance();
                }
            }
            else
            {
                return new Response{
            Result=new Result(Status.Error,_transition.ServiceName +$"There is no active workflow for {_recordId} and also {_transition.Name} is not transition of any start state."),
            };
            }
        }
        else
        {
            if (string.IsNullOrEmpty(_transition.FlowName))
            {

                return noFlowHasInstance(instanceAtState);
            }
            else
            {
                return hasFlowHasInstance(instanceAtState);
            }
        }
    }

    private IResponse noFlowNoInstance()
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

        return ServiceKontrol(newInstance, false);
        //return Results.Ok();
    }

    private IResponse noFlowHasInstance(Instance instanceAtState)
    {

        _dbContext.Entry(_transition).Reference(t => t.ToState).Load();

        return ServiceKontrol(instanceAtState, true);


    }

    private IResponse hasFlowNoInstance()
    {
        _dbContext.Entry(_transition).Reference(t => t.Flow).Load();

        var newInstance = new Instance
        {
            WorkflowName = _transition.FromState.WorkflowName!,
            EntityName = _entity,
            RecordId = _recordId,
            StateName = _transition.FromStateName!,
            BaseStatus = StatusType.LockedInFlow ,
            CreatedBy = _user,
            ZeebeFlow = _transition.Flow,
            ZeebeFlowName = _transition.FlowName,
            CreatedByBehalfOf = _behalfOfUser,
        };

        dynamic variables = createMessageVariables(newInstance);
        
        _zeebeService.PublishMessage(_transition.Flow!.Message, variables, null,_transition.Flow!.Gateway);

        _dbContext.Add(newInstance);
        SendSignalRData(newInstance,"worker-started");
        addInstanceTansition(newInstance);
        _dbContext.SaveChanges();

        return new Response{
            Result=new Result(Status.Success,"Instance Has been Created"),
        };
    }

    private IResponse hasFlowHasInstance(Instance instanceAtState)
    {
        _dbContext.Entry(_transition).Reference(t => t.ToState).Load();
        _dbContext.Entry(_transition).Reference(t => t.Flow).Load();

        instanceAtState.StateName = _transition.FromStateName!;
        instanceAtState.ModifiedBy = _user;
        instanceAtState.ModifiedByBehalfOf = _behalfOfUser;
        instanceAtState.ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc);
        instanceAtState.BaseStatus = StatusType.LockedInFlow ;

        dynamic variables = createMessageVariables(instanceAtState);
        SendSignalRData(instanceAtState,"worker-started");
        _zeebeService.PublishMessage(_transition.Flow!.Message, variables, instanceAtState.Id.ToString(),_transition.Flow!.Gateway);

        addInstanceTansition(instanceAtState);
        _dbContext.SaveChanges();

        //return Results.Ok();
        return new Response{
            Result=new Result(Status.Success,"Instance Has been Updated"),
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

    private void addInstanceTansition(Instance instance)
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
        };

        _dbContext.Add(newInstanceTransition);
    }
    private IResponse ServiceKontrol(Instance instance, bool hasInstance)
    {
        if (!string.IsNullOrEmpty(_transition.ServiceName))
        {
            var clientHttp = new HttpClient();
            var response = new HttpResponseMessage();
            if (_transition.ServiceName.Contains("{") && _transition.ServiceName.Contains("}"))
            {
                //     //dynamic JsonRoutedata = Newtonsoft.Json.Linq.JObject.Parse(_data.RouteData.ToString());
                //     System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"/\{([^}]+)\}/");

                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("{(.*?)}");
                var v = regex.Match(_transition.ServiceName);
                // string? test3=v.Groups[1].ToString();
                foreach (var item in v.Groups)
                {
                    if (!item.ToString()!.Contains("{"))
                    {
                        string? RouteDataString = _data.RouteData!.ToString();
                        dynamic JsonRoutedata = Newtonsoft.Json.Linq.JObject.Parse(RouteDataString);
                        string replaceVaule = JsonRoutedata[item.ToString()!];
                        _transition.ServiceName = _transition.ServiceName.Replace("{"+item.ToString()!+"}", replaceVaule);
                    }

                }
            }
            else
            {

            }
            try
            {
                response = clientHttp.PostAsync(_transition.ServiceName, new StringContent(_data.EntityData.ToString(), System.Text.Encoding.UTF8, "application/json")).Result;
              try
              {
                var contentString= response!.Content!.ReadAsStringAsync().Result;
                dynamic JsonResultdata = Newtonsoft.Json.Linq.JObject.Parse(contentString);
                var status=JsonResultdata.result.status;
                if(status!="Success")
                {
                    var message=JsonResultdata.result.message;
                     return new Response{
            Result=new Result(Status.Error,message),
            };
                  //  return Results.BadRequest(status+" "+message);
                }
              } 
              catch(Exception ex)
              {
                
              }
              
             
            }
            catch(Exception ex)
            {
                return new Response{
            Result=new Result(Status.Error,"unexpected error:"+ex.ToString()),
            };
            }
           

            if (response.StatusCode == System.Net.HttpStatusCode.OK
            || response.StatusCode == System.Net.HttpStatusCode.Created
            || response.StatusCode == System.Net.HttpStatusCode.NotModified

            )
            {
              return UpdateInstance(instance,hasInstance);
            }
            else
            {
                return new Response{
            Result=new Result(Status.Error,_transition.ServiceName + " message:" + response.ReasonPhrase),
        };
                //return Results.BadRequest(_transition.ServiceName + " message:" + response.ReasonPhrase);
            }
        }
        else
        {
             return UpdateInstance(instance,hasInstance);
        }
    }

    private IResponse UpdateInstance(Instance instance, bool hasInstance)
    {
         if (hasInstance)
                {
                    instance.StateName = _transition.ToStateName!;
                    instance.ModifiedBy = _user;
                    instance.ModifiedByBehalfOf = _behalfOfUser;
                    instance.ModifiedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc);
                    instance.BaseStatus = _transition.ToState!.BaseStatus;
                }
                else
                {
                    _dbContext.Add(instance);
                }
                SendSignalRData(instance,"transition-completed");
                addInstanceTansition(instance);
                _dbContext.SaveChanges();
                 return new Response{
            Result=new Result(Status.Success,"Instance has been updated"),
            };
    }
    private void SendSignalRData(Instance instance,string eventInfo)
    {
            var responseSignalR = _client.InvokeMethodAsync<PostSignalRData, string>(
            HttpMethod.Post,
            "amorphie-workflow-hub.test-amorphie-workflow-hub",
            "sendMessage",
            new PostSignalRData(
                _user,
               eventInfo,
                instance.Id,
              _data.EntityData,DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc),instance.StateName,_transitionName,instance.BaseStatus
            ));
    }

}