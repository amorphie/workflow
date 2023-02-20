
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

public static class DefinitionModule
{
    public static void MapDefinitionEndpoints(this WebApplication app)
    {
        app.MapGet("/workflow/definition", getDefinition)
            .Produces<GetWorkflowDefinition[]>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status204NoContent)
            .WithOpenApi(operation =>
            {
                operation.Summary = "Returns queried workflow definitions.";
              
                operation.Parameters[0].Description = "Partial or full name of the definition.";
                operation.Parameters[1].Description = "Filters result workflows with provided Tag(s).";
                operation.Parameters[2].Description = "Returns submitted entity's workflows.";
                operation.Parameters[3].Description = "Pagination value for requested page. Default is 0, max is 100";
                operation.Parameters[4].Description = "Pagination value for requested page size. Default is 10, max is 100";
                operation.Parameters[5].Description = "RFC 5646 compliant language code.";

                operation.Tags = new List<OpenApiTag> { new() { Name = "Definition" } };

                operation.Responses["200"].Description = "One or more defifinitions found.";
                operation.Responses["204"].Description = "No definitions found.";
                return operation;
            });


        app.MapPost("/workflow/definition", (
            [FromBody] PostWorkflowDefinitionRequest data)
            =>
        { })
            .Produces<PostWorkflowDefinitionResponse>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status201Created)
            .WithOpenApi(operation =>
              {
                  operation.Summary = "Saves or updates workflow definition.";
                  operation.Tags = new List<OpenApiTag> { new() { Name = "Definition" } };

                  operation.Responses["200"] = new OpenApiResponse { Description = "Definition updated." };
                  operation.Responses["201"] = new OpenApiResponse { Description = "New definition created." };

                  return operation;
              });

        app.MapDelete("/workflow/definition/{definition-name}", (
            [FromRoute(Name = "definition-name")] string definition)
            =>
        { })
              .WithOpenApi(operation =>
              {
                  operation.Summary = "Deletes workflow definition.";
                  operation.Tags = new List<OpenApiTag> { new() { Name = "Definition" } };

                  operation.Parameters[0].Description = "Exact name of the definition";

                  operation.Responses = new OpenApiResponses
                  {
                      ["200"] = new OpenApiResponse { Description = "Definition deleted successfully" },
                      ["404"] = new OpenApiResponse { Description = "Definition not found." },
                      ["422"] = new OpenApiResponse { Description = "Definition has active instance(s). Cannot be deleted." }
                  };
                  return operation;
              });

        app.MapGet("/workflow/definition/{definition-name}/state", (
            [FromHeader(Name = "Accept-Language")] string? language,
            [FromRoute(Name = "definition-name")] string definition,
            [FromQuery(Name = "state-name")] string? state
            ) =>
        { })
              .Produces<GetStateDefinition[]>(StatusCodes.Status200OK)
              .Produces(StatusCodes.Status204NoContent)
              .WithOpenApi(operation =>
              {
                  operation.Summary = "Returns queried workflows state and transition definitions.";
                  operation.Tags = new List<OpenApiTag> { new() { Name = "Definition" } };


                  operation.Parameters[0].Description = "Provided as *Accept-Language* in header. RFC 5646 compliant language code.";
                  operation.Parameters[1].Description = "Exact name of definition.";
                  operation.Parameters[2].Description = "Partial or full name of the state.";

                  operation.Responses["200"].Description = "One or more states found.";
                  operation.Responses["204"].Description = "State not found.";

                  return operation;
              });





        app.MapPost("/workflow/definition/{definitionname}/state", (
            [FromRoute(Name = "definitionname")] string definition,

            [FromBody] PostStateDefinitionRequest data
            ) =>
        { })
            .Produces<PostStateDefinitionResponse>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status422UnprocessableEntity)
            .WithOpenApi(operation =>
              {
                  operation.Summary = "Updates or creates workflow state.";
                  operation.Tags = new List<OpenApiTag> { new() { Name = "Definition" } };

                  operation.Parameters[0].Description = "Exact name of definition.";

                  operation.Responses["200"] = new OpenApiResponse { Description = "Definition updated." };
                  operation.Responses["201"] = new OpenApiResponse { Description = "New definition created." };
                  operation.Responses["422"] = new OpenApiResponse { Description = "State must have at least one transition" };
                  return operation;
              });


        app.MapDelete("/workflow/definition/{name}/state/{state-name}", () => { })
              .WithOpenApi(operation =>
              {
                  operation.Summary = "Deletes existing state.";
                  operation.Description = @" State can be deleted if it is not target or source state of any transition.";
                  operation.Tags = new List<OpenApiTag> { new() { Name = "Definition" } };

                  operation.Responses = new OpenApiResponses
                  {
                      ["200"] = new OpenApiResponse { Description = "State deleted successfully" },
                      ["404"] = new OpenApiResponse { Description = "State not found." },
                  };
                  return operation;
              });

    }

    static IResult getDefinition(
            [FromServices] WorkflowDBContext context,
            [FromQuery] string? definition,
            [FromQuery] string[]? tags,
            [FromQuery] string? entity,
            [FromQuery][Range(0, 100)] int? page = 0,
            [FromQuery][Range(5, 100)] int? pageSize = 10,
            [FromHeader(Name = "Language")] string? language = "en-EN"
        )
    {
        var query = context.Workflows!
               .Include(w => w.Titles.Where(t => t.Language == language));

        var workflows = query.ToList();
        return Results.Ok(workflows);
    }

}



