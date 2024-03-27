using amorphie.workflow.core.Dtos.Definition;
using amorphie.workflow.core.Enums;
using amorphie.workflow.service.Db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
namespace amorphie.workflow;
public static class TransferModule
{

    public static void MapTransferModuleEndpoints(this WebApplication app)
    {
        app.MapGet("/transfer/wf/{workflowName}/new", TransferModuleApis.GetDefinitionFromNewBulkAsync)
        .Produces<WorkflowCreateDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status204NoContent)
        .WithOpenApi(operation =>
        {
            operation.Summary = "Get Definition Bulk In New Style";
            operation.Tags = new List<OpenApiTag> { new() { Name = "V2 Workflow" } };
            operation.Responses["200"].Description = "wf with its states.";
            operation.Responses["204"].Description = "No instance found.";
            return operation;
        });

        app.MapGet("/transfer/wf/{workflowName}/convert", TransferModuleApis.GetDefinitionFromLegacyToNewBulkAsync)
        .Produces<WorkflowCreateDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status204NoContent)
        .WithOpenApi(operation =>
        {
            operation.Summary = "Get Converted Definition From Legacy To New Style Bulk";
            operation.Tags = new List<OpenApiTag> { new() { Name = "V2 Workflow" } };
            operation.Responses["200"].Description = "wf with its states and routes those which mutated from legacy transitions and states.";
            operation.Responses["204"].Description = "No instance found.";
            return operation;
        });

        app.MapGet("/transfer/wf/{workflowName}/legacy", TransferModuleApis.GetDefinitionFromLegacyBulkAsync)
        .Produces<WorkflowCreateDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status204NoContent)
        .WithOpenApi(operation =>
        {
            operation.Summary = "Get Definition Bulk";
            operation.Tags = new List<OpenApiTag> { new() { Name = "V2 Workflow" } };
            operation.Responses["200"].Description = "wf with its states and transitions.";
            operation.Responses["204"].Description = "No instance found.";
            return operation;
        });

        app.MapPost("/transfer/wf/save/legacy", TransferModuleApis.SaveTransferRequestAsync)
       .Produces<PostWorkflowDefinitionResponse>(StatusCodes.Status200OK)
       .Produces(StatusCodes.Status201Created)
       .WithOpenApi(operation =>
         {
             operation.Summary = "Saves or updates the request of -workflow and its states and transitions definition in legacy style-.";
             operation.Tags = new List<OpenApiTag> { new() { Name = "V2 Workflow" } };

             operation.Responses["200"] = new OpenApiResponse { Description = "Definition updated." };
             operation.Responses["201"] = new OpenApiResponse { Description = "New definition created." };

             return operation;
         });

        app.MapPost("/transfer/wf/approve/legacy", TransferModuleApis.ApproveTransferOfLegacyDefinitionAsync)
        .Produces<WorkflowCreateDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status204NoContent)
        .WithOpenApi(operation =>
        {
            operation.Summary = "Approve Transfer of Legacy Definition";
            operation.Tags = new List<OpenApiTag> { new() { Name = "V2 Workflow" } };
            operation.Responses["200"].Description = "Approve";
            operation.Responses["204"].Description = "No request found.";
            return operation;
        });
        app.MapPost("/transfer/wf/cancel/legacy", TransferModuleApis.CancelTransferOfLegacyDefinitionAsync)
        .Produces<WorkflowCreateDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status204NoContent)
        .WithOpenApi(operation =>
        {
            operation.Summary = "Cancel Transfer of Legacy Definition";
            operation.Tags = new List<OpenApiTag> { new() { Name = "V2 Workflow" } };
            operation.Responses["200"].Description = "Cancel";
            operation.Responses["204"].Description = "No request found.";
            return operation;
        });

    }
}

public class TransferModuleApis
{
    public static async Task<IResult> GetDefinitionFromNewBulkAsync([FromServices] TransferService service, [FromRoute(Name = "workflowName")] string workflowName, CancellationToken cancellationToken)
    {
        var response = await service.GetDefinitionFromNewBulkAsync(workflowName);
        return ApiResult.CreateResult(response);
    }

    public static async Task<IResult> GetDefinitionFromLegacyToNewBulkAsync([FromServices] TransferService service, [FromRoute(Name = "workflowName")] string workflowName, CancellationToken cancellationToken)
    {
        var response = await service.GetDefinitionFromLegacyToNewBulkAsync(workflowName, cancellationToken);
        return ApiResult.CreateResult(response);
    }

    public static async Task<IResult> GetDefinitionFromLegacyBulkAsync([FromServices] TransferService service, [FromRoute(Name = "workflowName")] string workflowName, CancellationToken cancellationToken)
    {
        var response = await service.GetDefinitionFromLegacyBulkAsync(workflowName, cancellationToken);
        return ApiResult.CreateResult(response);
    }


    public static async Task<IResult> SaveTransferRequestAsync([FromServices] TransferService service, [FromBody] WorkflowCreateDto data, CancellationToken cancellationToken)
    {
        var response = await service.SaveTransferRequestAsync(data, cancellationToken);
        return ApiResult.CreateResult(response);
    }

    public static async Task<IResult> ApproveTransferOfLegacyDefinitionAsync([FromServices] TransferService service, [FromBody] Guid transferId, CancellationToken cancellationToken)
    {
        var response = await service.ApproveOrCancelTransferOfLegacyDefinitionAsync(transferId, TransferStatus.Approved, cancellationToken);
        return ApiResult.CreateResult(response);
    }

    public static async Task<IResult> CancelTransferOfLegacyDefinitionAsync([FromServices] TransferService service, [FromBody] Guid transferId, CancellationToken cancellationToken)
    {
        var response = await service.ApproveOrCancelTransferOfLegacyDefinitionAsync(transferId, TransferStatus.Cancelled, cancellationToken);
        return ApiResult.CreateResult(response);
    }

}

