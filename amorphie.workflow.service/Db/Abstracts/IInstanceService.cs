using amorphie.core.Base;
using amorphie.core.IBase;
using amorphie.workflow.core.Dtos;
using Microsoft.AspNetCore.Http;

namespace amorphie.workflow.service.Db.Abstracts;
    public interface IInstanceService
{
    Task<bool> IsRouteDefined(string targetTransitionOrStateName, CancellationToken cancellationToken);

    Task<IResponse> TriggerFlowAsync(Guid instanceId, string targetTransitionOrStateName, Guid user, Guid behalfOfUser, dynamic data, IHeaderDictionary? headerParameters, CancellationToken cancellationToken);
    Task<Response> ChangeInstanceStateAsync(Guid instanceId, string targetTransitionOrStateName, WorkerBodyTrxInnerDatas request, Guid createdBy, Guid createdBehalf, CancellationToken cancellationToken);

}

