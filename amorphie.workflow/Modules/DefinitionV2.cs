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

        app.MapPost("/workflow/saveWorkflow", SaveWorkflowAsync)
            .Produces<PostWorkflowDefinitionResponse>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status201Created)
            .WithOpenApi(operation =>
              {
                  operation.Summary = "Saves or updates workflow definition. if NewStates object is not null then it commits states&transition in new style else legacy style.";
                  operation.Description="If NewStates and States object is given in same request then NewStates processed";
                  operation.Tags = new List<OpenApiTag> { new() { Name = "V2 Definition" } };

                  operation.Responses["200"] = new OpenApiResponse { Description = "Definition saved." };
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

}


