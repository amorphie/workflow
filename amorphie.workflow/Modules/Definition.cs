
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

public static class DefinitionModule
{
    public static void MapDefinitionEndpoints(this WebApplication app)
    {
        app.MapGet("/workflow/definition", (
            [FromHeader(Name = "Accept-Language")] string? language,
            [FromQuery] string? definition) =>
        { })
              .WithOpenApi(operation =>
              {
                  operation.Summary = "Returns queried workflow definitions.";
                  operation.Parameters[0].Description = "RFC 5646 compliant language code.";
                  operation.Parameters[1].Description = "Partial or full name of the definition.";
                  operation.Responses = new OpenApiResponses
                  {
                      ["200"] = new OpenApiResponse { Description = "One or more defifinitions found." },
                      ["204"] = new OpenApiResponse { Description = "Definition not found." }
                  };

                  return operation;
              })
              .WithTags("Definition")
              .Produces<GetWorkflowDefinition[]>(StatusCodes.Status200OK)
              .Produces(StatusCodes.Status204NoContent);

        app.MapPost("/workflow/definition", (
            [FromBody] PostWorkflowDefinitionRequest data)
            =>
        { })
              .WithOpenApi(operation =>
              {
                  operation.Summary = "Saves or updates  workflow definition.";
                  operation.Responses = new OpenApiResponses
                  {
                      ["200"] = new OpenApiResponse { Description = "Definition updated." },
                      ["201"] = new OpenApiResponse { Description = "New definition created." }
                  };
                  return operation;
              })
              .WithTags("Definition")
              .Produces<PostWorkflowDefinitionReesponse>(StatusCodes.Status200OK)
              .Produces(StatusCodes.Status201Created);


        app.MapDelete("/workflow/definition/{definition-name}", (
            [FromRoute(Name = "definition-name")] string definition)
            =>
        { })
              .WithOpenApi(operation =>
              {
                  operation.Summary = "Deletes workflow definition.";
                  operation.Parameters[0].Description = "Exact name of the definition";
                  operation.Responses = new OpenApiResponses
                  {
                      ["200"] = new OpenApiResponse { Description = "Definition deleted successfully" },
                      ["404"] = new OpenApiResponse { Description = "Definition not found." },
                      ["422"] = new OpenApiResponse { Description = "Definition has active instance(s). Cannot be deleted." }
                  };
                  return operation;
              })
              .WithTags("Definition")
              .Produces(StatusCodes.Status200OK)
              .Produces(StatusCodes.Status204NoContent)
              .Produces(StatusCodes.Status422UnprocessableEntity);

        app.MapGet("/workflow/definition/{definition-name}/state", (
            [FromHeader(Name = "Accept-Language")] string? language,
            [FromRoute(Name = "definition-name")] string definition,
            [FromQuery(Name = "state-name")] string? state
            ) =>
        { })
              .WithOpenApi(operation =>
              {
                  operation.Summary = "Returns queried workflows state and transition definitions.";
                  operation.Parameters[0].Description = "Provided as *Accept-Language* in header. RFC 5646 compliant language code.";
                  operation.Parameters[1].Description = "Exact name of definition.";
                  operation.Parameters[2].Description = "Partial or full name of the state.";
                  operation.Responses = new OpenApiResponses
                  {
                      ["200"] = new OpenApiResponse { Description = "One or more states found." },
                      ["204"] = new OpenApiResponse { Description = "State not found." }
                  };


                  return operation;
              })
              .WithTags("Definition")
              .Produces<GetStateDefinition[]>(StatusCodes.Status200OK)
              .Produces(StatusCodes.Status204NoContent);

        app.MapPost("/workflow/definition/{definition-name}/state", (
            [FromRoute(Name = "definition-name")] string definition,
            [FromBody] PostStateDefinitionRequest data
            ) =>
        { })
              .WithOpenApi(operation =>
              {
                  operation.Summary = "Updates or creates FSM workflow state.";
                  operation.Parameters[0].Description = "Exact name of definition.";
                  operation.Description = "Limited with FSM workflows.<br/> *Zeebe states and transitions are populated dynamicly.*";
                  operation.Responses = new OpenApiResponses
                  {
                      ["200"] = new OpenApiResponse { Description = "Definition updated." },
                      ["201"] = new OpenApiResponse { Description = "New definition created." },
                      ["422"] = new OpenApiResponse { Description = "State must have at least one transition" }
                  };
                  return operation;
              })
              .WithTags("Definition")
              .Produces<PostStateDefinitionResponse>(StatusCodes.Status200OK)
              .Produces(StatusCodes.Status201Created)
              .Produces(StatusCodes.Status422UnprocessableEntity);


        app.MapDelete("/workflow/definition/{name}/state/{state-name}", () => { })
              .WithOpenApi(operation =>
              {
                  operation.Summary = "Deletes existing FSM state.";
                  operation.Description = @" Deletes existing FSM state;<br/>
            * FSM state can be deleted if it is not target state of any transition.<br/>
            * Zeebe states cannot be deleted.";
                  operation.Responses = new OpenApiResponses
                  {
                      ["200"] = new OpenApiResponse { Description = "State deleted successfully" },
                      ["404"] = new OpenApiResponse { Description = "State not found." },
                  };
                  return operation;
              })
              .WithTags("Definition")
              .Produces(StatusCodes.Status200OK)
              .Produces(StatusCodes.Status404NotFound);

    }
}