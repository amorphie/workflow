using amorphie.workflow.core.Dtos;
using amorphie.workflow.core.Dtos.Definition;
using amorphie.workflow.core.Dtos.Transfer;
using amorphie.workflow.core.Enums;
using amorphie.workflow.service.Db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
namespace amorphie.workflow;
public static class TransferModule
{

    public static void MapTransferModuleEndpoints(this WebApplication app)
    {
        app.MapGet("/workflow/transfer/wf/{workflowName}", TransferModuleApis.GetDefinitionBulkAsync)
        .Produces<WorkflowCreateDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status204NoContent)
        .WithOpenApi(operation =>
        {
            operation.Summary = "Get Definition Bulk";
            operation.Tags = new List<OpenApiTag> { new() { Name = "V2 Workflow" } };
            operation.Responses["200"].Description = "wf with its states.";
            operation.Responses["204"].Description = "No instance found.";
            return operation;
        });

        app.MapGet("/workflow/transfer/wf/{workflowName}/convert", TransferModuleApis.GetDefinitionFromLegacyToNewBulkAsync)
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
        app.MapPost("/workflow/transfer/wf/get/templates", TransferModuleApis.GetTemplatesFromLegacyBulkAsync)
        .Produces<amorphie.core.Base.Response<List<string>>>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status204NoContent)
        .WithOpenApi(operation =>
        {
            operation.Summary = "Get Template List From Legacy To New Style Bulk";
            operation.Tags = new List<OpenApiTag> { new() { Name = "V2 Workflow" } };
            operation.Responses["200"].Description = "wf with its states and routes those which mutated from legacy transitions and states.";
            operation.Responses["204"].Description = "No instance found.";
            return operation;
        });
         app.MapGet("/workflow/transfer/wf/get/transferHistory", TransferModuleApis.GetTransferHistoryAsync)
        .Produces<amorphie.core.Base.Response<List<string>>>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status204NoContent)
        .WithOpenApi(operation =>
        {
            operation.Summary = "Get Template List From Legacy To New Style Bulk";
            operation.Tags = new List<OpenApiTag> { new() { Name = "V2 Workflow" } };
            operation.Responses["200"].Description = "wf with its states and routes those which mutated from legacy transitions and states.";
            operation.Responses["204"].Description = "No instance found.";
            return operation;
        });
          app.MapPost("/workflow/transfer/wf/save/templates", TransferModuleApis.SaveTemplatesFromLegacyBulkAsync)
        .Produces<amorphie.core.Base.Response<TemplateEngineTemplateDefinitions>>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status204NoContent)
        .WithOpenApi(operation =>
        {
            operation.Summary = "Get Template List From Legacy To New Style Bulk";
            operation.Tags = new List<OpenApiTag> { new() { Name = "V2 Workflow" } };
            operation.Responses["200"].Description = "wf with its states and routes those which mutated from legacy transitions and states.";
            operation.Responses["204"].Description = "No instance found.";
            return operation;
        });
        app.MapPost("/workflow/transfer/wf/save", TransferModuleApis.SaveTransferRequestAsync)
       .Produces<PostWorkflowDefinitionResponse>(StatusCodes.Status200OK)
       .Produces(StatusCodes.Status201Created)
       .WithOpenApi(operation =>
         {
             operation.Summary = "Saves or updates the request of -workflow and its states and transitions definition-.";
             operation.Tags = new List<OpenApiTag> { new() { Name = "V2 Workflow" } };

             operation.Responses["200"] = new OpenApiResponse { Description = "Definition updated." };
             operation.Responses["201"] = new OpenApiResponse { Description = "New definition created." };

             return operation;
         });

        app.MapPost("/workflow/transfer/wf/approve", TransferModuleApis.ApproveTransferOfDefinitionAsync)
        .Produces<WorkflowCreateDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status204NoContent)
        .WithOpenApi(operation =>
        {
            operation.Summary = "Approve Transfer of Definition";
            operation.Tags = new List<OpenApiTag> { new() { Name = "V2 Workflow" } };
            operation.Responses["200"].Description = "Approve";
            operation.Responses["204"].Description = "No request found.";
            return operation;
        });
        app.MapPost("/workflow/transfer/wf/cancel", TransferModuleApis.CancelTransferOfDefinitionAsync)
        .Produces<WorkflowCreateDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status204NoContent)
        .WithOpenApi(operation =>
        {
            operation.Summary = "Cancel Transfer of Definition";
            operation.Tags = new List<OpenApiTag> { new() { Name = "V2 Workflow" } };
            operation.Responses["200"].Description = "Cancel";
            operation.Responses["204"].Description = "No request found.";
            return operation;
        });

    }
}

public class TransferModuleApis
{
    public static async Task<IResult> GetDefinitionBulkAsync([FromServices] TransferService service, [FromRoute(Name = "workflowName")] string workflowName, CancellationToken cancellationToken)
    {        
        var response = await service.GetDefinitionBulkAsync(workflowName, cancellationToken);
        return ApiResult.CreateResult(response);
    }

    public static async Task<IResult> GetDefinitionFromLegacyToNewBulkAsync([FromServices] TransferService service, [FromRoute(Name = "workflowName")] string workflowName, CancellationToken cancellationToken)
    {
        var response = await service.GetDefinitionFromLegacyToNewBulkAsync(workflowName, cancellationToken);
        return ApiResult.CreateResult(response);
    }

    public static async Task<IResult> SaveTransferRequestAsync([FromServices] TransferService service, [FromBody] WorkflowCreateDto data, CancellationToken cancellationToken)
    {
        var response = await service.SaveTransferRequestAsync(data, cancellationToken);
        return ApiResult.CreateResult(response);
    }

    public static async Task<IResult> ApproveTransferOfDefinitionAsync([FromServices] TransferService service, [FromBody] TransferResultDto transferDto, CancellationToken cancellationToken)
    {
        var response = await service.ApproveOrCancelTransferOfDefinitionAsync(transferDto, TransferStatus.Approved, cancellationToken);
        return ApiResult.CreateResult(response);
    }

    public static async Task<IResult> CancelTransferOfDefinitionAsync([FromServices] TransferService service, [FromBody] TransferResultDto transferDto, CancellationToken cancellationToken)
    {
        var response = await service.ApproveOrCancelTransferOfDefinitionAsync(transferDto, TransferStatus.Cancelled, cancellationToken);
        return ApiResult.CreateResult(response);
    }
    public static async Task<IResult> GetTemplatesFromLegacyBulkAsync([FromServices] TransferService service, [FromBody] TemplateListRequestModel data,  CancellationToken cancellationToken)
    {
        var response = await service.GetTemplatesFromLegacyBulkAsync(data, cancellationToken);
        return ApiResult.CreateResult(response);
    }
    public static async Task<IResult> GetTransferHistoryAsync([FromServices] TransferService service, [AsParameters] TransferHistoryRequestDto data,  CancellationToken cancellationToken)
    {
        var response = await service.GetTransferHistoryAsync(data, cancellationToken);
        return ApiResult.CreateResult(response);
    }
    public static async Task<IResult> SaveTemplatesFromLegacyBulkAsync([FromServices] TransferService service, [FromBody] TemplateEngineTransferModel data, CancellationToken cancellationToken)
    {
        var response = await service.SaveTemplatesFromLegacyBulkAsync(data, cancellationToken);
        return ApiResult.CreateResult(response);
    }
	

}

