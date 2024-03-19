using amorphie.core.Base;
using amorphie.core.IBase;
using amorphie.workflow.core.Dtos;
using Microsoft.AspNetCore.Http;

namespace amorphie.workflow.service.Db.Abstracts;
    public interface IInstanceService
    {
        Task<IResponse> TriggerFlow(Guid instanceId, string transitionOrStateName, Guid user, Guid behalfOfUser, dynamic data, IHeaderDictionary? headerParameters, CancellationToken cancellationToken);
        Task<Response> ChangeInstanceState(Guid instanceId, string transitionOrStateName, WorkerBodyTrxInnerDatas request, Guid createdBy, Guid createdBehalf, CancellationToken cancellationToken);

    }

