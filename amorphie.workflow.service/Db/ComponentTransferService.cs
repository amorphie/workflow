using amorphie.core.Base;
using amorphie.workflow.core.Dtos;
using amorphie.workflow.core.Enums;
using amorphie.workflow.core.Models;
using Microsoft.EntityFrameworkCore;
using amorphie.workflow.core.Dtos.Definition;
using amorphie.workflow.core.Mapper;
using amorphie.workflow.core.Dtos.DefinitionLegacy;
using amorphie.workflow.service.Db.Abstracts;
using amorphie.workflow.core.Token;
using System.Text.Json.Serialization;
using System.Text.Json;
using amorphie.workflow.core.Models.Transfer;
using amorphie.workflow.core.Dtos.Transfer;

namespace amorphie.workflow.service.Db;
public class ComponentTransferService
{
    private readonly WorkflowDBContext _dbContext;
    private readonly DbSet<Workflow> _dbSet;
    private readonly IWorkflowService _workflowService;
    private readonly IStateService _stateService;

    public ComponentTransferService(WorkflowDBContext dbContext, IWorkflowService workflowService, IStateService stateService)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<Workflow>();
        _workflowService = workflowService;
        _stateService = stateService;
    }
    public async Task<Response<TransferResultDto>> SaveTransferRequestAsync(DtoPageComponents pageComponentsDto, CancellationToken cancellationToken)
    {
        // if (string.IsNullOrEmpty(workflowDto.Hash))
        // {
        //     return new Response<WorkflowTransferResultDto>
        //     {
        //         Result = new Result(amorphie.core.Enums.Status.Error, "Hash must be provided")
        //     };
        // }
        var transferHistroy = new TransferHistory
        {
            Hash = Md5.Generate(pageComponentsDto),
            RequestBody = JsonSerializer.Serialize(pageComponentsDto),
            SubjectName = pageComponentsDto.pageName!,
            TransferStatus = TransferStatus.WaitingForApproval,
            TransferringType = nameof(PageComponent)

        };
        _dbContext.TransferHistories.Add(transferHistroy);
        await _dbContext.SaveChangesAsync();
        return new Response<TransferResultDto>
        {
            Data = new TransferResultDto{
                TransferId = transferHistroy.Id
            },
            Result = new Result(amorphie.core.Enums.Status.Success, "")
        };
    }

    public async Task<Response> ApproveOrCancelTransferAsync(TransferResultDto transferDto, TransferStatus transferStatus, CancellationToken cancellationToken)
    {
        var transferHistroy = await _dbContext.TransferHistories.FirstOrDefaultAsync(p => p.Id == transferDto.TransferId && p.TransferStatus == TransferStatus.WaitingForApproval);
        if (transferHistroy == null)
        {
            return Response.Error("Transfer request not found nor it is in WaitingForApproval state");
        }
        if (transferStatus == TransferStatus.Approved)
        {
            var pageComponentsDto = JsonSerializer.Deserialize<DtoPageComponents>(transferHistroy.RequestBody);
            if (pageComponentsDto == null)
            {
                return Response.Error($"Transfer request could not be parsed to {nameof(WorkflowCreateDto)}");
            }
            // if (!Md5.Check(pageComponentsDto))
            // {
            //     return Response.Error("Request body must not be modified before save");
            // }
            //var saveResponse = await SaveDefinitionToLegacyBulkAsync(workflowDto!, cancellationToken);
            transferHistroy.TransferStatus = TransferStatus.Approved;
        }
        else
        {
            transferHistroy.TransferStatus = TransferStatus.Cancelled;
        }
        await _dbContext!.SaveChangesAsync();
        return Response.Success("");
    }
}

