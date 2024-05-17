using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using amorphie.core.Base;
using amorphie.workflow.core.Dtos;
using amorphie.workflow.core.Dtos.Definition;
using amorphie.workflow.core.Dtos.Transfer;
using amorphie.workflow.core.Enums;

namespace amorphie.workflow.service.Db.Abstracts;
    public interface ITransferService
    {
        Task<Response<Workflow>> MigrateTransitionAsync(string workflowName);
        Task<Response<WorkflowCreateDto>> GetDefinitionBulkAsync(string workflowName,  CancellationToken cancellationToken);
        Task<Response<WorkflowCreateDto>> GetDefinitionFromLegacyToNewBulkAsync(string workflowName, CancellationToken cancellationToken);
        Task<Response<TransferResultDto>> SaveTransferRequestAsync(WorkflowCreateDto workflowDto, CancellationToken cancellationToken);
        Task<Response> ApproveOrCancelTransferOfDefinitionAsync(TransferResultDto transferDto, TransferStatus transferStatus, CancellationToken cancellationToken);
        Task<Response<TemplateEngineTemplateDefinitions>> SaveTemplatesFromLegacyBulkAsync(TemplateEngineTransferModel transferModel, CancellationToken cancellationToken);
        Task<Response<List<string>>> GetTemplatesFromLegacyBulkAsync(TemplateListRequestModel requestModel, CancellationToken cancellationToken);
        
    }
