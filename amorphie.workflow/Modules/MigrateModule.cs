using amorphie.workflow;
using amorphie.workflow.core.Dtos.Definition;
using amorphie.workflow.core.Dtos.DefinitionLegacy;
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


        app.MapGet("/migrate/wf/{workflowName}/new", MigrateModuleApis.GetDefinitionFromNewBulk)
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

        app.MapGet("/migrate/wf/{workflowName}/convert", MigrateModuleApis.GetDefinitionFromLegacyToNewBulk)
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

        app.MapGet("/migrate/wf/{workflowName}/legacy", MigrateModuleApis.GetDefinitionFromLegacyBulk)
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
    public static async Task<IResult> GetDefinitionFromNewBulk(
  CancellationToken cancellationToken,
  [FromServices] MigrateService service,
  [FromRoute(Name = "workflowName")] string workflowName
)
    {
        var response = await service.GetDefinitionFromNewBulkAsync(workflowName);
        return ApiResult.CreateResult(response);
    }

    public static async Task<IResult> GetDefinitionFromLegacyToNewBulk(
  CancellationToken cancellationToken,
  [FromServices] MigrateService service,
  [FromRoute(Name = "workflowName")] string workflowName
)
    {
        var response = await service.GetDefinitionFromLegacyToNewBulkAsync(workflowName);
        return ApiResult.CreateResult(response);
    }

    public static async Task<IResult> GetDefinitionFromLegacyBulk(
  CancellationToken cancellationToken,
  [FromServices] MigrateService service,
  [FromRoute(Name = "workflowName")] string workflowName
)
    {
        var response = await service.GetDefinitionFromLegacyBulkAsync(workflowName);
        return ApiResult.CreateResult(response);
    }

}

