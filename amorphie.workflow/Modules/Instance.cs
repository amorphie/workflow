
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

public static class InstanceModule
{

    public static void MapInstanceEndpoints(this WebApplication app)
    {

        app.MapPut("/workflow/instance/{name}", ([FromBody] PostInstanceRequest data) => { })
              .WithOpenApi(operation =>
              {
                  operation.Summary = "Always creates a new instance of worklfow";
                  return operation;
              })
              .Produces<PostInstanceResponse>(StatusCodes.Status200OK)
              .Produces(StatusCodes.Status204NoContent);


        app.MapGet("/workflow/instance", (string? entity, Guid? entityId, GetInstanceType? filter) => { })
              .WithOpenApi(operation =>
              {
                  operation.Summary = "Return requested workflow instance(s)";
                  operation.Parameters[2].Description = "Enum :  All, Completed, Running, Suspended";


                  return operation;
              })
              .Produces<GetInstanceResponse[]>(StatusCodes.Status200OK)
              .Produces(StatusCodes.Status204NoContent);


        app.MapGet("/workflow/instance/{instance-id}", ([FromHeader(Name = "Accept-Language")] string? language, [FromRoute(Name = "instance-id")] Guid instanceId) => { })
              .WithOpenApi(operation =>
              {
                  operation.Summary = "Return requested workflow instance";
                  return operation;
              })
              .Produces<GetInstanceResponse[]>(StatusCodes.Status200OK)
              .Produces(StatusCodes.Status204NoContent);


        app.MapPatch("/workflow/instance/{instance-id}/transaction/{transition}", ([FromRoute(Name = "instance-id")] Guid instanceId, [FromRoute(Name = "transition")] string transition, [FromBody] PatchTransitionRequest data) => { })
              .WithOpenApi(operation =>
              {
                  operation.Summary = "Trigger transition of instance";
                  return operation;
              })
              .Produces<PatchTransitionResponse>(StatusCodes.Status200OK)
              .Produces(StatusCodes.Status204NoContent);

        app.MapGet("/workflow/instance/{instance-id}/event", (
            [FromHeader(Name = "Accept-Language")] string? language,
            [FromRoute(Name = "instance-id")] Guid instanceId,
            [FromQuery] int page,
            [FromQuery] int pageSize

        ) =>
        { })
              .WithOpenApi(operation =>
              {
                  operation.Summary = "Return events of workflow instance";
                  return operation;
              })
              .Produces<GetInstanceEventResponse[]>(StatusCodes.Status200OK)
              .Produces(StatusCodes.Status204NoContent);

    }
}