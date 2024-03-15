using amorphie.workflow;
using amorphie.workflow.core.Dtos.DefinitionLegacy;
using amorphie.workflow.service.Db.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

public static class DefinitionV2Module
{
    public static void MapDefinitionV2Endpoints(this WebApplication app)
    {

        app.MapPost("/workflow/saveWorkflow", SaveWorkflowAsync)
            .Produces<PostWorkflowDefinitionResponse>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status201Created)
            .WithOpenApi(operation =>
              {
                  operation.Summary = "Saves or updates workflow definition.";
                  operation.Tags = new List<OpenApiTag> { new() { Name = "V2 Definition" } };

                  operation.Responses["200"] = new OpenApiResponse { Description = "Definition updated." };
                  operation.Responses["201"] = new OpenApiResponse { Description = "New definition created." };

                  return operation;
              });
    }


    static async Task<IResult> SaveWorkflowAsync(
      [FromServices] IWorkflowService service,
      [FromBody] WorkflowCreateDtoLegacy data
      )
    {
        var response = await service.SaveAsync(data);
        return ApiResult.CreateResult(response);
    }

}


