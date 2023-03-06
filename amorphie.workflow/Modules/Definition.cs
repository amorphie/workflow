
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


        app.MapPost("/workflow/definition", saveDefinition)
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

        app.MapDelete("/workflow/definition/{definition-name}", deleteDefinition)
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

        app.MapGet("/workflow/definition/{definition-name}/state",getState)
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





        app.MapPost("/workflow/definition/{definitionname}/state", saveState)
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


        app.MapDelete("/workflow/definition/{name}/state/{state-name}", deleteState)
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
        var query = context.Workflows!.Where(w => w.Name == definition)
               .Include(w => w.Titles.Where(t => t.Language == language))
               .Include(w => w.Entities.Where(w => w.Name == entity && w.WorkflowName == definition));

        var workflows = query
        .Skip(page.GetValueOrDefault(0) * pageSize.GetValueOrDefault(10))
        .Take(pageSize.GetValueOrDefault(10))
        .ToList();
        return Results.Ok(workflows);
    }
    static IResult deleteDefinition(
        [FromServices] WorkflowDBContext context,
        [FromRoute(Name = "definition-name")] string definition
    )
    {
        var existingRecord = context.Workflows!
       .FirstOrDefault(w => w.Name == definition);

        if (existingRecord != null)
        {
            context!.Remove(existingRecord);
            context.SaveChanges();
            return Results.Ok();
        }
        else
        {
            return Results.NotFound();
        }

    }
    static IResult saveDefinition(
      [FromServices] WorkflowDBContext context,
      [FromBody] PostWorkflowDefinitionRequest data,
      [FromHeader(Name = "Language")] string? language = "en-EN"
      )
    {
        var existingRecord = context.Workflows!.FirstOrDefault(w => w.Name == data.name);
        List<WorkflowEntity> entityList = new List<WorkflowEntity>();
        // All available status have to add 
        foreach (var item in data.entities)
        {
            List<WorkflowEntity> entity = item.availableInStatus.Select(s => new WorkflowEntity()
            {
                AvailableInStatus = s,
              //  IsExclusive = item.isExclusive,
                IsStateManager = item.isStateManager,
                Name = item.name
            }).ToList();
            entityList.AddRange(entity);
        }
        if (existingRecord == null)
        {

            context!.Workflows!.Add(new Workflow
            {
                Name = data.name,
                Tags = data.tags,
                Titles = data.title.Select(s => new Translation
                {
                    Label = s.label,
                    Language = s.language
                }).ToList(),
                Entities = entityList,
                CreatedAt = DateTime.Now,
                CreatedByBehalfOf = Guid.NewGuid(),
            });
            context.SaveChanges();
            return Results.Created($"/workflow/definition/{data.name}", data);
        }
        else
        {
            var hasChanges = false;
            if (existingRecord.Tags != data.tags)
            {
                hasChanges = true;
                existingRecord.ModifiedAt = DateTime.Now;
                existingRecord.Tags = data.tags;
            }
            foreach (var req in entityList)
            {
                WorkflowEntity? existingEntity = existingRecord.Entities.FirstOrDefault(db => db.Name == req.Name);
                //Kayıdı olmayan entitylerin eklenmesi
                if (existingEntity == null)
                {
                    context!.WorkflowEntities!.Add(new WorkflowEntity
                    {
                        Name = req.Name,
                      //  IsExclusive = req.IsExclusive,
                        IsStateManager = req.IsStateManager,
                        AvailableInStatus = req.AvailableInStatus,
                        CreatedAt = DateTime.Now,
                        CreatedByBehalfOf = Guid.NewGuid(),
                    });
                    hasChanges = true;
                }
                else if (existingEntity.IsStateManager != req.IsStateManager
              //  || existingEntity.IsExclusive != req.IsExclusive
                || existingEntity.AvailableInStatus != req.AvailableInStatus)
                {
                    //Kayıdı olup update edilmesi gereken entityler 
                   // existingEntity.IsExclusive = req.IsExclusive;
                    existingEntity.IsStateManager = req.IsStateManager;
                    existingEntity.AvailableInStatus = req.AvailableInStatus;
                    hasChanges = true;
                }

            }

            if (hasChanges)
            {
                context!.SaveChanges();
                return Results.Ok(new PostWorkflowDefinitionResponse(data.name));
            }
            else
            {
                return Results.Problem("Not Modified", null, 304);
            }
        }
    }
    static IResult getState(
           [FromServices] WorkflowDBContext context,
           [FromRoute(Name = "definition-name")] string definition,
           [FromQuery(Name = "state-name")] string? state,
            [FromQuery][Range(0, 100)] int? page = 0,
           [FromQuery][Range(5, 100)] int? pageSize = 10,
           [FromHeader(Name = "Language")] string? language = "en-EN"
       )
    {
        var query = context!.States!.Where(w => w.Name == state && w.WorkflowName == definition)
               .Include(w => w.Titles.Where(t => t.Language == language));


        var states = query
        .Skip(page.GetValueOrDefault(0) * pageSize.GetValueOrDefault(10))
        .Take(pageSize.GetValueOrDefault(10))
        .ToList();
        return Results.Ok(states);
    }
    static IResult deleteState(
            [FromServices] WorkflowDBContext context,
            [FromRoute(Name = "name")] string definition,
              [FromRoute(Name = "state-name")] string state,
               [FromHeader(Name = "Language")] string? language = "en-EN"
        )
    {
        var existingRecord = context.States!.Include(w => w.Titles.Where(t => t.Language == language))
       .FirstOrDefault(w => w.WorkflowName == definition && w.Name == state)
       ;

        if (existingRecord != null)
        {
            context!.Remove(existingRecord);
            context.SaveChanges();
            return Results.Ok();
        }
        else
        {
            return Results.NotFound();
        }

    }
    static IResult saveState(
        [FromServices] WorkflowDBContext context,
        [FromRoute(Name = "definitionname")] string definition,
        [FromBody] PostStateDefinitionRequest data,
        [FromHeader(Name = "Language")] string? language = "en-EN"
        )
    {
            var existingRecord = context.States!
                   .FirstOrDefault(w => w.WorkflowName == definition && w.Name == data.name)
                   ;
            if (existingRecord == null)
            {
                context!.States!.Add(new State
                {
                    WorkflowName = definition,
                    Name = data.name,
                    BaseStatus = data.baseStatus,
                    CreatedAt = DateTime.Now,
                    CreatedByBehalfOf = Guid.NewGuid(),
                    Type=StateType.Standart,
                    Transitions = data!.transitions!.Select(x => new Transition
                    {
                        Name = x.name,
                        ToState = context!.States!.FirstOrDefault(f => f.Name == x.toState),
                        CreatedAt = DateTime.Now,
                      //  Type = TransitionType.AutoTransition,
                        CreatedByBehalfOf = Guid.NewGuid(),
                    }).ToList(),
                    Titles = new List<Translation>(){
                            new Translation{
                             Language=data.title.language,
                             Label=data.title.label
                            }
                        }
                });
                context!.SaveChanges();

                return Results.Created($"workflow/definition/{definition}/state?state-name:"+data.name,definition);
            }
            else
            {
                var hasChanges = false;
                if (existingRecord.BaseStatus != data.baseStatus)
                {
                    hasChanges = true;
                    existingRecord.BaseStatus = data.baseStatus;
                }
                foreach (var req in data.transitions)
            {
                Transition? existingTransition = existingRecord.Transitions.FirstOrDefault(db => db.Name == req.name);
                //Kayıdı olmayan Transition ların eklenmesi
                if (existingTransition == null)
                {
                    context!.Transitions!.Add(new Transition
                    {
                        Name = req.name,
                        ToStateName=req.toState,
                        ToState=context!.States!.FirstOrDefault(f => f.Name == req.toState),
                        FromStateName=req.toState,
                        FromState=req.fromState!=null?context!.States!.FirstOrDefault(f => f.Name == req.fromState)!:default!,
                        //IsExclusive = req.IsExclusive,
                        Titles=new List<Translation>(){
                            new Translation(){
                                Label=req.title.label,
                                Language=req.title.language
                            }
                        },
                        CreatedAt = DateTime.Now,
                        CreatedByBehalfOf = Guid.NewGuid(),
                    });
                    hasChanges = true;
                }
                else if (existingTransition.ToStateName != req.toState||existingTransition.FromStateName != req.fromState)
                {
                    //Kayıdı olup update edilmesi gereken transitionlar 
                    existingTransition.FromStateName = req.fromState!;
                    existingTransition.ToStateName = req.toState;
                    existingTransition.ToState = context!.States!.FirstOrDefault(f => f.Name == req.toState);
                    existingTransition.FromState = req.fromState!=null?context!.States!.FirstOrDefault(f => f.Name == req.fromState)!:default!;
                    hasChanges = true;
                }

            }
                if (hasChanges)
                {
                    context!.SaveChanges();

                    return Results.Ok(new PostStateDefinitionResponse(data.name));
                }
                else
                {
                    return Results.Problem("Not Modified", null, 304);
                }
            }


    }
}


