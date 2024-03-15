using amorphie.workflow;
using amorphie.workflow.core.Dtos.Definition;
using amorphie.workflow.core.Enums;
using amorphie.workflow.service.Db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

public static class MigrateModule
{

    public static void MapMigrateModuleEndpoints(this WebApplication app)
    {
        // app.MapPost("/migrate/state/{workflowName}", MigrateModuleApis.MigrateTransition)
        // .Produces<WorkflowCreateDto>(StatusCodes.Status200OK)
        // .Produces(StatusCodes.Status204NoContent)
        // .WithOpenApi(operation =>
        // {
        //     operation.Summary = "Migrate workflows all transitions to state table with its routes";
        //     operation.Tags = new List<OpenApiTag> { new() { Name = "V2 Workflow" } };
        //     operation.Responses["200"].Description = "wf with its states migration.";
        //     operation.Responses["204"].Description = "No instance found.";
        //     return operation;
        // });


        app.MapGet("/migrate/wf/{workflowName}", MigrateModuleApis.GetDefinitionBulk)
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

        app.MapGet("/migrate/wf/{workflowName}/legacy", MigrateModuleApis.GetDefinitionBulkFromLegacy)
        .Produces<WorkflowCreateDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status204NoContent)
        .WithOpenApi(operation =>
        {
            operation.Summary = "Get Definition Bulk In New Style";
            operation.Tags = new List<OpenApiTag> { new() { Name = "V2 Workflow" } };
            operation.Responses["200"].Description = "wf with its states and routes those which mutated from legacy transitions and states.";
            operation.Responses["204"].Description = "No instance found.";
            return operation;
        });

        app.MapGet("/migrate/wf/{workflowName}/legacyTolegacy", MigrateModuleApis.GetDefinitionBulkFromLegacyToLegacy)
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

    }
}

public class MigrateModuleApis
{
//     public static async Task<IResult> MigrateTransition(
//   CancellationToken cancellationToken,
//   [FromServices] MigrateService service,
//   [FromServices] ILogger<MigrateModuleApis> logger,
//   [FromRoute(Name = "workflowName")] string workflowName
// )
//     {
//         var response = await service.GetDefinitionBulkAsync(workflowName);
//         // logger.LogCritical("Service injection test");
//         return ApiResult.CreateResult(response);
//     }
    public static async Task<IResult> GetDefinitionBulk(
  CancellationToken cancellationToken,
  [FromServices] MigrateService service,
  [FromRoute(Name = "workflowName")] string workflowName
)
    {
        var response = await service.GetDefinitionBulkAsync(workflowName);
        return ApiResult.CreateResult(response);
    }

    public static async Task<IResult> GetDefinitionBulkFromLegacy(
  CancellationToken cancellationToken,
  [FromServices] MigrateService service,
  [FromRoute(Name = "workflowName")] string workflowName
)
    {
        var response = await service.GetDefinitionFromLegacyBulkAsync(workflowName);
        return ApiResult.CreateResult(response);
    }

    public static async Task<IResult> GetDefinitionBulkFromLegacyToLegacy(
  CancellationToken cancellationToken,
  [FromServices] MigrateService service,
  [FromRoute(Name = "workflowName")] string workflowName
)
    {
        var response = await service.GetDefinitionFromLegacyToLegacyBulkAsync(workflowName);
        return ApiResult.CreateResult(response);
    }

}

