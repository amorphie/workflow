using amorphie.core.Base;
using amorphie.workflow.core.Enums;
using Microsoft.EntityFrameworkCore;
using amorphie.workflow.core.Token;
using System.Text.Json;
using amorphie.workflow.core.Models.Transfer;
using amorphie.workflow.core.Dtos.Transfer;

namespace amorphie.workflow.service.Db;
public class ComponentTransferService
{
    private readonly WorkflowDBContext _dbContext;
    private readonly DbSet<Workflow> _dbSet;
    private readonly PageComponentService _pageComponentService;


    public ComponentTransferService(WorkflowDBContext dbContext, PageComponentService pageComponentService)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<Workflow>();
        _pageComponentService = pageComponentService;
    }
    public async Task<Response<TransferResultDto>> SaveTransferRequestAsync(DtoPageComponents pageComponentsDto, CancellationToken cancellationToken)
    {
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
            Data = new TransferResultDto
            {
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
                return Response.Error($"Transfer request could not be parsed to {nameof(DtoPageComponents)}");
            }
            var saveResponse = await _pageComponentService.InsertOrUpdateAsync(pageComponentsDto, cancellationToken);
            if (saveResponse.Result.Status == "Error")
            {
                return saveResponse;
            }
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

