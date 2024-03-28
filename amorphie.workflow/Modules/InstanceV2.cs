using amorphie.core.Base;
using amorphie.workflow;
using amorphie.workflow.service.Db.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

public static class InstanceV2Module
{
    public static void MapInstanceV2Endpoints(this WebApplication app)
    {
        app.MapPost("/v2/workflow/instance/{instanceId}/transition/{transitionName}", TriggerFlow)
        .Produces<Response>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status204NoContent)
        .WithOpenApi(operation =>
        {
            operation.Summary = "Triggers flow ";
            operation.Tags = new List<OpenApiTag> { new() { Name = "V2 Instance" } };
            operation.Responses["200"].Description = "One or more instances found.";
            operation.Responses["204"].Description = "No instance found.";
            return operation;
        });
    }

    static async ValueTask<IResult> TriggerFlow(
        CancellationToken cancellationToken,
        [FromServices] IInstanceService service,
        [FromRoute(Name = "transitionName")] string transitionName,
        [FromRoute(Name = "instanceId")] Guid instanceId,
        HttpRequest request,
        [FromBody] dynamic body,
        [FromHeader(Name = "User")] Guid user,
        [FromHeader(Name = "Behalf-Of-User")] Guid behalOfUser)
    {
        var response = await service.TriggerFlowAsync(instanceId, transitionName, user, behalOfUser, body, request.Headers, cancellationToken);
        return ApiResult.CreateResult(response);
    }

}

