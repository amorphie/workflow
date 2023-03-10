
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

public static class InstanceModule
{

    public static void MapInstanceEndpoints(this WebApplication app)
    {
        app.MapGet("/workflow/instance", getAllInstance)
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

        app.MapGet("/workflow/instance/{instance-id}", getInstance
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


        app.MapGet("/workflow/instance/{instance-id}/history", getInstanceTransactions)
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

    static IResult getAllInstance(
        [FromServices] WorkflowDBContext context,
        [FromQuery] string? entity,
         [FromQuery] Guid? recordId,
          [FromQuery] GetInstanceStatusType? status,
           [FromQuery][Range(0, 100)] int? page = 0,
        [FromQuery][Range(5, 100)] int? pageSize = 10,
           [FromHeader(Name = "Language")] string? language = "en-EN"
    )
    {
        var query = context.Instances!
   .Where(w => w.EntityName == entity && w.RecordId == recordId)
   ;

        var instances = query.Skip(page.GetValueOrDefault(0) * pageSize.GetValueOrDefault(10))
         .Take(pageSize.GetValueOrDefault(10))
         .ToList();
        return Results.Ok(
                instances.Select(s => new GetInstanceResponse(
                   s.EntityName,
                   s.RecordId.ToString(),
                   s.Id,
                   s.WorkflowName,
                   new GetStateDefinition(s.StateName, new MultilanguageText(
                    language!, s.State.Titles.FirstOrDefault(f => f.Language == language)!.Label
                    ),
                    s.State.BaseStatus,
                    s.State.Transitions.Select(t => new PostTransitionDefinitionRequest(
                        t.Name,
                        new MultilanguageText(
                            language!, t.Titles.FirstOrDefault(f => f.Language == language)!.Label),
                        t.ToStateName!,
                         new MultilanguageText(
                            language!, t.Forms.FirstOrDefault(f => f.Language == language)!.Label),
                        t.FromStateName,
                        t.FlowName,
                        null
                    )).ToArray()
                    ),
                   s.CreatedAt,
                   DateTime.Now//Buradaki değer ne olacak?

                    )
                ).ToArray());
    }
    static IResult getInstance(
          [FromServices] WorkflowDBContext context,
          [FromRoute(Name = "instance-id")] Guid instanceId,
             [FromHeader(Name = "Language")] string? language = "en-EN"
      )
    {
        var instance = context.Instances!
   .FirstOrDefault(w => w.Id == instanceId)
   ;
        if (instance == null)
        {
            return Results.NotFound();
        }
        else
        {
            return Results.Ok(
                          new GetInstanceResponse(
                             instance!.EntityName,
                             instance!.RecordId.ToString(),
                             instance.Id,
                             instance.WorkflowName,
                             new GetStateDefinition(instance.StateName, new MultilanguageText(
                              language!, instance.State.Titles.FirstOrDefault(f => f.Language == language)!.Label
                              ),
                              instance.State.BaseStatus,
                              instance.State.Transitions.Select(t => new PostTransitionDefinitionRequest(
                                  t.Name,
                                  new MultilanguageText(
                                      language!, t.Titles.FirstOrDefault(f => f.Language == language)!.Label),
                                  t.ToStateName!,
                                   new MultilanguageText(
                                      language!, t.Forms.FirstOrDefault(f => f.Language == language)!.Label),
                                  t.FromStateName,
                                  t.FlowName,
                                  null
                              )).ToArray()
                              ),
                             instance.CreatedAt,
                             DateTime.Now//Buradaki değer ne olacak?

                              )
                          );
        }

    }
    static IResult getInstanceTransactions(
       [FromServices] WorkflowDBContext context,
      [FromRoute(Name = "instance-id")] Guid instanceId,
            [FromQuery] int page,
            [FromQuery] int pageSize,
          [FromHeader(Name = "Language")] string? language = "en-EN"
   )
    {
       var query = context.InstanceTransitions!.Include(i=>i.Instance)
   .Where(w => w.InstanceId== instanceId);
   var instances = query.Skip(page * pageSize)
         .Take(pageSize)
         .ToList();
        return Results.Ok(instances.Select(it=>new GetInstanceTransitionHistoryResponse(
it.Id,
it.FromStateName,
it.ToStateName,
context!.Transitions.FirstOrDefault(f=>f.ToStateName==it.ToStateName&&f.FromStateName==it.ToStateName)!.Name,
it.EntityData,
it.FormData!,
it.CreatedAt,
context!.InstanceEvents.Where(w=>w.InstanceTransitionId==it.Id).Select(s=>new GetInstanceEventHistoryResponse(
    s.Id,
    s.Id.ToString(),
    new Dictionary<string, string>(),
    s.InputData.Split(';', System.StringSplitOptions.None)
    .Select (part  => part.Split('=', System.StringSplitOptions.None))
    .Where (part => part.Length == 2)
    .ToDictionary (sp => sp[0], sp => sp[1]),
    s.OutputData.Split(';', System.StringSplitOptions.None)
    .Select (part  => part.Split('=', System.StringSplitOptions.None))
    .Where (part => part.Length == 2)
    .ToDictionary (sp => sp[0], sp => sp[1]),
    s.CreatedAt
)).ToArray()
        )).ToArray() );
    }
}