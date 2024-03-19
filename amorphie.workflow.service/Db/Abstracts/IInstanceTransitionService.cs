using amorphie.workflow.core.Dtos;
using amorphie.workflow.core.Dtos.Consumer;

namespace amorphie.workflow.service.Db.Abstracts
{
    public interface IInstanceTransitionService
    {
        void Insert(Instance instance, ConsumerPostTransitionRequest request, Dictionary<string, string>? headerParameters, string ToStateName, DateTime? started, DateTime? finished, Guid createdBy, Guid createdBehalf);
        void Insert(Instance instance, WorkerBodyTrxInnerDatas request, string ToStateName, DateTime? started, DateTime? finished, Guid createdBy, Guid createdBehalf);
    }
}
