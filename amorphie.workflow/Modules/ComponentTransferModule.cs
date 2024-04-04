using amorphie.workflow.core.Dtos.Definition;
using amorphie.workflow.core.Dtos.Transfer;
using amorphie.workflow.core.Enums;
using amorphie.workflow.service.Db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
namespace amorphie.workflow;
public static class ComponentTransferModule
{

    public static void MapComponentTransferModuleEndpoints(this WebApplication app)
    {

        app.MapPost("/transfer/component/save", ComponentTransferModuleApis.SaveTransferRequestAsync)
       .Produces<PostWorkflowDefinitionResponse>(StatusCodes.Status200OK)
       .Produces(StatusCodes.Status201Created)
       .WithOpenApi(operation =>
         {
             operation.Summary = "Saves or updates the request of page component.";
             operation.Tags = new List<OpenApiTag> { new() { Name = "V2 Workflow" } };

             operation.Responses["200"] = new OpenApiResponse { Description = "Request created." };
             return operation;
         });

        app.MapPost("/transfer/component/approve", ComponentTransferModuleApis.ApproveTransferAsync)
        .Produces<WorkflowCreateDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status204NoContent)
        .WithOpenApi(operation =>
        {
            operation.Summary = "Approve Page Component Transfer";
            operation.Tags = new List<OpenApiTag> { new() { Name = "V2 Workflow" } };
            operation.Responses["200"].Description = "Approve";
            operation.Responses["204"].Description = "No request found.";
            return operation;
        });
        app.MapPost("/transfer/component/cancel", ComponentTransferModuleApis.CancelTransferAsync)
        .Produces<WorkflowCreateDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status204NoContent)
        .WithOpenApi(operation =>
        {
            operation.Summary = "Cancel Page Component Transfer";
            operation.Tags = new List<OpenApiTag> { new() { Name = "V2 Workflow" } };
            operation.Responses["200"].Description = "Cancel";
            operation.Responses["204"].Description = "No request found.";
            return operation;
        });

    }
}

public class ComponentTransferModuleApis
{
    public static async Task<IResult> SaveTransferRequestAsync([FromServices] ComponentTransferService service, [FromBody] DtoPageComponents data, CancellationToken cancellationToken)
    {
        var response = await service.SaveTransferRequestAsync(data, cancellationToken);
        return ApiResult.CreateResult(response);
    }

    public static async Task<IResult> ApproveTransferAsync([FromServices] ComponentTransferService service, [FromBody] TransferResultDto transferDto, CancellationToken cancellationToken)
    {
        var response = await service.ApproveOrCancelTransferAsync(transferDto, TransferStatus.Approved, cancellationToken);
        return ApiResult.CreateResult(response);
    }

    public static async Task<IResult> CancelTransferAsync([FromServices] ComponentTransferService service, [FromBody] TransferResultDto transferDto, CancellationToken cancellationToken)
    {
        var response = await service.ApproveOrCancelTransferAsync(transferDto, TransferStatus.Cancelled, cancellationToken);
        return ApiResult.CreateResult(response);
    }

}

