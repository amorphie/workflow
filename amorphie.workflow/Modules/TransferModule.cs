using amorphie.workflow;
using amorphie.workflow.core.Dtos.Definition;
using amorphie.workflow.core.Dtos.DefinitionLegacy;
using amorphie.workflow.core.Enums;
using amorphie.workflow.service.Db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

public static class TransferModule
{

    public static void MapTransferModuleEndpoints(this WebApplication app)
    {
        app.MapGet("/transfer/wf/{workflowName}/new", TransferModuleApis.GetDefinitionFromNewBulk)
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

        app.MapGet("/transfer/wf/{workflowName}/convert", TransferModuleApis.GetDefinitionFromLegacyToNewBulk)
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

        app.MapGet("/transfer/wf/{workflowName}/legacy", TransferModuleApis.GetDefinitionFromLegacyBulk)
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

        app.MapPost("/transfer/wf/approve/legacy", TransferModuleApis.ApproveTransferOfLegacyDefinition)
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
        app.MapPost("/transfer/wf/cancel/legacy", TransferModuleApis.CancelTransferOfLegacyDefinition)
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
    public static async Task<IResult> GetDefinitionFromNewBulk(CancellationToken cancellationToken, [FromServices] TransferService service, [FromRoute(Name = "workflowName")] string workflowName)
    {
        var response = await service.GetDefinitionFromNewBulkAsync(workflowName);
        return ApiResult.CreateResult(response);
    }

    public static async Task<IResult> GetDefinitionFromLegacyToNewBulk(CancellationToken cancellationToken, [FromServices] TransferService service, [FromRoute(Name = "workflowName")] string workflowName)
    {
        var response = await service.GetDefinitionFromLegacyToNewBulkAsync(workflowName);
        return ApiResult.CreateResult(response);
    }

    public static async Task<IResult> GetDefinitionFromLegacyBulk(CancellationToken cancellationToken, [FromServices] TransferService service, [FromRoute(Name = "workflowName")] string workflowName)
    {
        var response = await service.GetDefinitionFromLegacyBulkAsync(workflowName);
        return ApiResult.CreateResult(response);
    }


    public static async Task<IResult> SaveTransferRequestAsync([FromServices] TransferService service, [FromBody] WorkflowCreateDto data)
    {
        var response = await service.SaveTransferRequestAsync(data);
        return ApiResult.CreateResult(response);
    }

    public static async Task<IResult> ApproveTransferOfLegacyDefinition(CancellationToken cancellationToken, [FromServices] TransferService service, [FromBody] Guid transferId)
    {
        var response = await service.ApproveOrCancelTransferOfLegacyDefinition(transferId, TransferStatus.Approved);
        return ApiResult.CreateResult(response);
    }

    public static async Task<IResult> CancelTransferOfLegacyDefinition(CancellationToken cancellationToken, [FromServices] TransferService service, [FromBody] Guid transferId)
    {
        var response = await service.ApproveOrCancelTransferOfLegacyDefinition(transferId, TransferStatus.Cancelled);
        return ApiResult.CreateResult(response);
    }

}

