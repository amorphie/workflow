using System.Text.Json;
using amorphie.workflow.core.Dtos;
using amorphie.workflow.core.Dtos.Consumer;
using amorphie.workflow.service.Db.Abstracts;

namespace amorphie.workflow.service.Db;
public class InstanceTransitionService : IInstanceTransitionService
{
    private readonly WorkflowDBContext _dbContext;

    public InstanceTransitionService(WorkflowDBContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void Insert(Instance instance, ConsumerPostTransitionRequest request, Dictionary<string, string>? headerParameters, DateTime? started, DateTime? finished, Guid createdBy, Guid createdBehalf)
    {
        var newInstanceTransition = new InstanceTransition
        {
            InstanceId = instance.Id,
            Instance = instance,
            FromStateName = instance.StateName,
            ToStateName = instance.StateName,
            //TransitionName = ToStateName,
            EntityData = Convert.ToString(request.EntityData),
            FormData = Convert.ToString(request.FormData),
            AdditionalData = Convert.ToString(request.AdditionalData),
            QueryData = Convert.ToString(request.QueryData),
            RouteData = Convert.ToString(request.RouteData),
            // HeadersData = Convert.ToString(headerParameters),
            HeadersData = JsonSerializer.Serialize(headerParameters),
            CreatedBy = createdBy,
            CreatedByBehalfOf = createdBehalf,
            StartedAt = started,
            FinishedAt = finished
        };

        _dbContext.Add(newInstanceTransition);
    }

    public void Insert(Instance instance, WorkerBodyTrxInnerDatas request, DateTime? started, DateTime? finished, Guid createdBy, Guid createdBehalf)
    {
        var newInstanceTransition = new InstanceTransition
        {
            InstanceId = instance.Id,
            Instance = instance,
            FromStateName = instance.StateName,
            ToStateName = instance.StateName,
            //TransitionName = ToStateName,
            EntityData = Convert.ToString(request.EntityData),
            FormData = Convert.ToString(request.FormData),
            AdditionalData = Convert.ToString(request.AdditionalData),
            QueryData = Convert.ToString(request.QueryData),
            RouteData = Convert.ToString(request.RouteData),
            CreatedBy = createdBy,
            CreatedByBehalfOf = createdBehalf,
            StartedAt = started,
            FinishedAt = finished
        };

        _dbContext.Add(newInstanceTransition);
    }

}
