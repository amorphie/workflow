
using Dapr.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

public static class StateManagerModule
{

    public static void MapStateManagerEndpoints(this WebApplication app)
    {
        app.MapPost("/amorphie-workflow-completed", postWorkflowCompleted)
            .Produces(StatusCodes.Status200OK)
            .WithOpenApi(operation =>
            {
                operation.Summary = "Maps amorphie-workflow-completed service worker on Zeebe";
                operation.Tags = new List<OpenApiTag> { new() { Name = "Zeebe" } };
                return operation;
            });
    }


    static IResult postWorkflowCompleted(
            [FromBody] dynamic body,
            [FromServices] WorkflowDBContext dbContext,
            HttpRequest request,
            HttpContext httpContext,
            [FromServices] DaprClient client
        )
    {
        return Results.Ok();
    }
}