using amorphie.workflow.core.Dtos.Definition;
using amorphie.workflow.service.Db;
using amorphie.workflow.service.Db.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
namespace amorphie.workflow;
public static class DefinitionV2Module
{
    public static void MapDefinitionV2Endpoints(this WebApplication app)
    {

        app.MapPost("/workflow/saveWorkflow/new", SaveWorkflowAsync)
            .Produces<PostWorkflowDefinitionResponse>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status201Created)
            .WithOpenApi(operation =>
              {
                  operation.Summary = "Saves or updates workflow definition in new style.";
                  operation.Tags = new List<OpenApiTag> { new() { Name = "V2 Definition" } };

                  operation.Responses["200"] = new OpenApiResponse { Description = "Definition updated." };
                  operation.Responses["201"] = new OpenApiResponse { Description = "New definition created." };

                  return operation;
              });

        app.MapPost("/workflow/saveWorkflow/legacy", SaveWorkflowLegacyAsync)
            .Produces<PostWorkflowDefinitionResponse>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status201Created)
            .WithOpenApi(operation =>
              {
                  operation.Summary = "Saves or updates workflow and its states and transitions definition in legacy style.";
                  operation.Tags = new List<OpenApiTag> { new() { Name = "V2 Definition" } };
                  operation.Responses["200"] = new OpenApiResponse { Description = "Definition updated." };
                  operation.Responses["201"] = new OpenApiResponse { Description = "New definition created." };
                  return operation;
              });
    }


    static async Task<IResult> SaveWorkflowAsync(
      [FromServices] IWorkflowService service,
      [FromBody] WorkflowCreateDto data
      )
    {
        var response = await service.SaveAsync(data);
        return ApiResult.CreateResult(response);
    }

    static async Task<IResult> SaveWorkflowLegacyAsync([FromServices] TransferService transferService, [FromBody] WorkflowCreateDto data, CancellationToken cancellationToken)
    {
        var response = await transferService.SaveDefinitionToLegacyBulkAsync(data, cancellationToken);
        return ApiResult.CreateResult(response);
    }

}


