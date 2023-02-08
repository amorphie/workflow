
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

public static class InstanceModule
{

    public static void MapInstanceEndpoints(this WebApplication app)
    {
        app.MapGet("/workflow/instance", (
                string? entity,
                Guid? recordId,
                GetInstanceStatusType? status) =>
        { })
            .Produces<GetInstanceResponse[]>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status204NoContent)
            .WithOpenApi(operation =>
            {
                operation.Summary = "Return queried workflow instance(s)";
                operation.Parameters[2].Description = "Enum :  All, Completed, Running, Suspended";

                operation.Tags = new List<OpenApiTag> { new() { Name = "Instance" } };

                operation.Responses["200"].Description = "One or more instances found.";
                operation.Responses["204"].Description = "No instance found.";

                return operation;
            });

        app.MapGet("/workflow/instance/{instance-id}", (
            [FromRoute(Name = "instance-id")] Guid instanceId) =>
        { }
            )
            .Produces<GetInstanceResponse[]>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi(operation =>
            {
                operation.Summary = "Returns requested workflow instance";
                operation.Parameters[0].Description = "Workflow instance id.";

                operation.Tags = new List<OpenApiTag> { new() { Name = "Instance" } };

                operation.Responses["200"].Description = "Instances information returned.";
                operation.Responses["404"].Description = "No instance found.";
                return operation;
            });


        app.MapGet("/workflow/instance/{instance-id}/history", (
            [FromRoute(Name = "instance-id")] Guid instanceId,
            [FromQuery] int page,
            [FromQuery] int pageSize
            ) =>
            { })
            .Produces<GetInstanceTransitionHistoryResponse[]>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi(operation =>
            {
                operation.Summary = "Returns history of workflow instance";

                operation.Tags = new List<OpenApiTag> { new() { Name = "Instance" } };

                operation.Parameters[0].Description = "Workflow instance id.";
                operation.Parameters[1].Description = "Pagination value for requested page. Default is 0, max is 100";
                operation.Parameters[2].Description = "Pagination value for requested page size. Default is 10, max is 100";


                operation.Responses["200"].Description = "Instance history returned.";
                operation.Responses["204"].Description = "No history found.";
                operation.Responses["404"].Description = "No instance found.";

                return operation;
            });

        app.MapPost("/workflow/instance/{instance-id}/transaction/{transition}", (
            [FromRoute(Name = "instance-id")] Guid instanceId,
            [FromRoute(Name = "transition")] string transition,
            [FromBody] PostTransitionRequest data) =>
        { })
            .Produces<PostTransitionResponse>(StatusCodes.Status200OK)
              .Produces(StatusCodes.Status404NotFound)
              .WithOpenApi(operation =>
              {
                operation.Summary = "Triggers transition of instance";
                operation.Tags = new List<OpenApiTag> { new() { Name = "Instance" } };

                operation.Responses["200"].Description = "Instance triggered successfully.";
                operation.Responses["404"].Description = "Instance or eligable transition not found.";

                return operation;
              });
    }
}