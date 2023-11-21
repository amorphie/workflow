
using System.ComponentModel.DataAnnotations;
using System.Linq;
using amorphie.core.Base;
using amorphie.core.Enums;
using amorphie.core.IBase;
using amorphie.workflow.core.Dtos;
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
        app.MapGet("/workflow/definition/{recordId}", getAllWorkflowByRecordId)
               .WithOpenApi()
       .WithSummary("Gets registered workflows")
       .WithDescription("Returns existing workflows with metadata.Query parameter reference is can contain request or order reference of workflow.")
       .Produces<GetWorkflowDefinition[]>(StatusCodes.Status200OK)
       .Produces(StatusCodes.Status404NotFound);
        app.MapGet("/workflow/definition/search", getAllWorkflowWithFullTextSearch)
               .WithOpenApi()
       .WithSummary("Gets registered workflows")
       .WithDescription("Returns existing workflows with metadata.Query parameter reference is can contain request or order reference of workflow.")
       .Produces<GetWorkflowDefinition[]>(StatusCodes.Status200OK)
       .Produces(StatusCodes.Status404NotFound);

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
        app.MapPost("/workflow/definition/saveWorkflowWithFlow", saveWorkflowWitFlowAsync)
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
        app.MapPost("/workflow/definition/DeactiveWorkflowWithFlow", DeactiviteWorkflowWithFlowAsync)
      .Produces<PostWorkflowDefinitionResponse>(StatusCodes.Status200OK)
      .Produces(StatusCodes.Status201Created)
      .WithOpenApi(operation =>
        {
            operation.Summary = "Deactivite workflow definition.";
            operation.Tags = new List<OpenApiTag> { new() { Name = "Definition" } };

            operation.Responses["200"] = new OpenApiResponse { Description = "Definition updated." };
            operation.Responses["201"] = new OpenApiResponse { Description = "New definition created." };

            return operation;
        });
        app.MapPost("/workflow/definition/ActiviteWorkflowWithFlow", ActiviteWorkflowWithFlowAsync)
     .Produces<PostWorkflowDefinitionResponse>(StatusCodes.Status200OK)
     .Produces(StatusCodes.Status201Created)
     .WithOpenApi(operation =>
       {
           operation.Summary = "Activite  workflow definition.";
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

        app.MapGet("/workflow/definition/{definition-name}/state", getState)
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
        // TODO : Include a parameter for the cancelation token and convert all ToList objects to ToListAsync with the cancelation token.
        try
        {
            var query = context.Workflows!.Where(w => string.IsNullOrEmpty(definition)
                    || (!string.IsNullOrEmpty(definition) && w.Name.Contains(definition!)))
                          // .Include(w => w.Workflow)
                          .Include(w => w.Titles.Where(t => t.Language == language))
                           .Include(w => w.Entities.Where(w => (
                            string.IsNullOrEmpty(entity) || (!string.IsNullOrEmpty(entity) && w.Name.Contains(entity!)))
                            && (string.IsNullOrEmpty(definition) || (!string.IsNullOrEmpty(definition) && w.WorkflowName.Contains(definition!)))))
                        ;
            System.Text.Json.JsonSerializerOptions options = new()
            {
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault,

            };
            var workflows = query
            .Skip(page.GetValueOrDefault(0) * pageSize.GetValueOrDefault(10))
            .Take(pageSize.GetValueOrDefault(10)).Select(s => new GetWorkflowDefinition(
                s.Name,
                s.Titles.FirstOrDefault()!.Label,
                s.Tags!,
                s.Entities.Select(e => new GetWorkflowEntity(
         e.Name, e.InclusiveWorkflows == null ? false : true, e.IsStateManager,
         new StatusType[]{
        e.AvailableInStatus
         }
    )).ToArray(),
                s.RecordId == null ? string.Empty : s.RecordId.ToString()
                ))
    ;
            return Results.Ok(workflows)
            ;
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.ToString());
        }

    }
    static IResult deleteDefinition(
        [FromServices] WorkflowDBContext context,
        [FromRoute(Name = "definition-name")] string definition
    )
    {

        try
        {
            var existingRecord = context.Workflows!.Include(s => s.Titles)
                  .Include(s => s.States).ThenInclude(s => s.Titles)
                  .Include(s => s.States).ThenInclude(s => s.Transitions).ThenInclude(s => s.Titles)
                  .Include(s => s.States).ThenInclude(s => s.Transitions).ThenInclude(s => s.Forms)
                  .Include(s => s.States).ThenInclude(s => s.Transitions).ThenInclude(s => s.Page).ThenInclude(s => s.Pages)
                .Include(s => s.Entities)
                .Include(s => s.HistoryForms)

                 .FirstOrDefault(w => w.Name == definition);

            if (existingRecord != null)
            {
                context!.Remove(existingRecord);
                // TODO : Include a parameter for the cancelation token and convert SaveChanges to SaveChangesAsync with the cancelation token.
                context.SaveChanges();
                return Results.Ok();
            }
            else
            {
                return Results.NoContent();

            }
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.ToString());
        }


    }
    static IResult saveDefinition(
      [FromServices] WorkflowDBContext context,
      [FromBody] PostWorkflowDefinitionRequest data,
      [FromHeader(Name = "Language")] string? language = "en-EN"
      )
    {
        var existingRecord = context.Workflows!.Include(s => s.Entities).Include(s => s.HistoryForms).FirstOrDefault(w => w.Name == data.name);
        List<WorkflowEntity> entityList = new List<WorkflowEntity>();
        Guid recordId;
        bool recordIdNull = false;
        if (!Guid.TryParse(data.recordId, out recordId))
        {
            recordIdNull = true;
        }
        // All available status have to add 
        foreach (var item in data.entities!)
        {
            List<WorkflowEntity> entity = item.availableInStatus.Select(s => new WorkflowEntity()
            {
                AvailableInStatus = s,
                //  IsExclusive = item.isExclusive,
                IsStateManager = item.isStateManager,
                Name = item.name,
                WorkflowName = data.name

            }).ToList();
            entityList.AddRange(entity);
        }
        if (existingRecord == null)
        {
            //   var newRecord = ObjectMapper.Mapper.Map<Workflow>(data);
            //   newRecord.Entities=entityList;
            Workflow newWorkflow = new Workflow
            {
                WorkflowStatus = data.status,
                Name = data.name,
                Tags = data.tags,
                Titles = data.title.Select(s => new Translation
                {
                    Label = s.label,
                    Language = s.language
                }).ToList(),
                Entities = entityList,
                RecordId = recordIdNull ? null : recordId,
                CreatedAt = DateTime.UtcNow,
                CreatedByBehalfOf = Guid.NewGuid(),
                HistoryForms = data.historyForms != null && data.historyForms.Count() > 0 ? data.historyForms.Select(s => new Translation
                {
                    Language = s.language,
                    Label = s.label
                }).ToList() : new List<Translation>()
            };
            context!.Workflows!.Add(newWorkflow);
            // TODO : Include a parameter for the cancelation token and convert SaveChanges to SaveChangesAsync with the cancelation token.
            context.SaveChanges();
            return Results.Created($"/workflow/definition/{data.name}", data);
            // return new Response<PostWorkflowDefinitionResponse>
            // {
            //     Result = new Result(Status.Success, "Success Create"),
            //     Data = new PostWorkflowDefinitionResponse(newWorkflow.Name),
            // };
        }
        else
        {
            var hasChanges = false;
            if (existingRecord.Tags != data.tags || existingRecord.WorkflowStatus != data.status)
            {
                hasChanges = true;
                existingRecord.ModifiedAt = DateTime.UtcNow;
                existingRecord.Tags = data.tags;
                existingRecord.WorkflowStatus = data.status;
            }
            if (!recordIdNull && existingRecord.RecordId != recordId)
            {
                hasChanges = true;
                existingRecord.ModifiedAt = DateTime.UtcNow;
                existingRecord.RecordId = recordId;
            }
            if ((existingRecord.HistoryForms == null || existingRecord.HistoryForms.Count == 0) && (data.historyForms != null && data.historyForms.Count() > 0))
            {
                existingRecord.HistoryForms = data.historyForms.Select(s => new Translation
                {
                    Id = new Guid(),
                    Label = s.label,
                    Language = s.language
                }).ToList();
                hasChanges = true;
            }
            else if (data.historyForms != null && data.historyForms.Count() > 0)
            {
                foreach (var historyFormTranslantion in data.historyForms)
                {
                    if (existingRecord.HistoryForms == null)
                    {
                        existingRecord.HistoryForms = new List<Translation>();
                        existingRecord.HistoryForms.Add(new Translation()
                        {
                            Label = historyFormTranslantion.label,
                            Language = historyFormTranslantion.language
                        });
                        hasChanges = true;
                    }
                    else
                    {
                        Translation? translation = existingRecord.HistoryForms.FirstOrDefault(f => f.Language == historyFormTranslantion.language);
                        if (translation != null && translation.Label != historyFormTranslantion.label)
                        {
                            translation.Label = historyFormTranslantion.label;
                            hasChanges = true;
                        }
                        else if (translation == null)
                        {
                            existingRecord.HistoryForms.Add(new Translation()
                            {
                                Label = historyFormTranslantion.label,
                                Language = historyFormTranslantion.language
                            });
                            hasChanges = true;
                        }
                    }

                }


            }
            foreach (var req in entityList)
            {
                WorkflowEntity? existingEntity = existingRecord.Entities!.FirstOrDefault(db => db.Name == req.Name);
                //Kayıdı olmayan entitylerin eklenmesi
                if (existingEntity == null)
                {
                    context!.WorkflowEntities!.Add(new WorkflowEntity
                    {
                        Name = req.Name,
                        //  IsExclusive = req.IsExclusive,
                        IsStateManager = req.IsStateManager,
                        AvailableInStatus = req.AvailableInStatus,
                        CreatedAt = DateTime.UtcNow,
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
                return Results.Ok();
            }
            else
            {
                return Results.NoContent();
            }
        }
    }
    static async Task<IResult> saveWorkflowWitFlowAsync(
  [FromServices] WorkflowDBContext context,
  [FromBody] PostWorkflowWithFlow data,
  CancellationToken cancellationToken,
  [FromHeader(Name = "Language")] string? language = "en-EN"
  )
    {
        DtoSaveWorkflowWithFlow request = data.entityData!;
        var existingRecord = await context.Workflows!.Include(s => s.Entities).Include(s => s.HistoryForms).FirstOrDefaultAsync(w => w.Name == request.name, cancellationToken);
        List<WorkflowEntity> entityList = request.entities!.Select(s => new WorkflowEntity()
        {
            AvailableInStatus = s.availableInStatus.GetValueOrDefault(amorphie.core.Enums.StatusType.InProgress),
            IsStateManager = s.isStateManager.GetValueOrDefault(false),
            Name = s.name!,
            WorkflowName = request.name!,
            AllowOnlyOneActiveInstance = s.allowOnlyOneActiveInstance.GetValueOrDefault(false),
        }).ToList();
        if (existingRecord == null)
        {
            Workflow newWorkflow = new Workflow
            {
                WorkflowStatus = request.status,
                Name = request.name!,
                Tags = request.tags,
                Titles = request.title!.Select(s => new Translation
                {
                    Language = s.language,
                    Label = s.label
                })
                .ToList()!,
                Entities = entityList,
                CreatedAt = DateTime.UtcNow,
                CreatedByBehalfOf = Guid.NewGuid(),
                RecordId = data.recordId,
                HistoryForms = request.historyForms.Any() ?
                 request.historyForms.Where(w => !string.IsNullOrEmpty(w.label) && !string.IsNullOrEmpty(w.language)).Select(s => new Translation
                 {
                     Label = s.label,
                     Language = s.language
                 }).ToList() : new List<Translation>()
            };
            context!.Workflows!.Add(newWorkflow);

            await context.SaveChangesAsync(cancellationToken);

            var resultState = await InsertStateAndTransitions(request, context, cancellationToken);
            if (resultState.Status != Status.Success.ToString())
            {
                return Results.Problem(resultState.Message);
            }
            return Results.Created($"/workflow/definition/{newWorkflow.Name}", data);
        }
        else
        {
            var resultState = await InsertStateAndTransitions(request, context, cancellationToken);
            if (resultState.Status != Status.Success.ToString())
            {
                return Results.Problem(resultState.Message);
            }
            var hasChanges = false;
            if (existingRecord.Tags != request.tags || existingRecord.WorkflowStatus != request.status)
            {
                hasChanges = true;
                existingRecord.ModifiedAt = DateTime.UtcNow;
                existingRecord.Tags = request.tags;
                existingRecord.WorkflowStatus = request.status;
            }
            if ((!existingRecord.HistoryForms.Any()) && (request.historyForms.Any()))
            {
                existingRecord.HistoryForms = request.historyForms.Select(s => new Translation
                {
                    Id = new Guid(),
                    Label = s.label,
                    Language = s.language
                }).ToList();
                hasChanges = true;
            }
            else if (request.historyForms.Any())
            {
                foreach (var historyFormTranslantion in request.historyForms)
                {
                    if (existingRecord.HistoryForms == null)
                    {
                        existingRecord.HistoryForms = new List<Translation>();
                        existingRecord.HistoryForms.Add(new Translation()
                        {
                            Label = historyFormTranslantion.label,
                            Language = historyFormTranslantion.language
                        });
                        hasChanges = true;
                    }
                    else
                    {
                        Translation? translation = existingRecord.HistoryForms.FirstOrDefault(f => f.Language == historyFormTranslantion.language);
                        if (translation != null && translation.Label != historyFormTranslantion.label)
                        {
                            translation.Label = historyFormTranslantion.label;
                            hasChanges = true;
                        }
                        else if (translation == null)
                        {
                            existingRecord.HistoryForms.Add(new Translation()
                            {
                                Label = historyFormTranslantion.label,
                                Language = historyFormTranslantion.language
                            });
                            hasChanges = true;
                        }
                    }

                }


            }
            foreach (var req in entityList)
            {
                WorkflowEntity? existingEntity = existingRecord.Entities!.FirstOrDefault(db => db.Name == req.Name);
                //Kayıdı olmayan entitylerin eklenmesi
                if (existingEntity == null)
                {
                    context!.WorkflowEntities!.Add(new WorkflowEntity
                    {
                        Name = req.Name,
                        //  IsExclusive = req.IsExclusive,
                        IsStateManager = req.IsStateManager,
                        AvailableInStatus = req.AvailableInStatus,
                        CreatedAt = DateTime.UtcNow,
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
                await context!.SaveChangesAsync(cancellationToken);
                return Results.Ok();
            }
            else
            {
                return Results.NoContent();
            }
        }

    }
    static async Task<IResult> DeactiviteWorkflowWithFlowAsync(
[FromServices] WorkflowDBContext context,
[FromBody] PostWorkflowWithFlowDynamic data,
CancellationToken cancellationToken

)
    {
        var existingRecord = await context.Workflows!.Include(s => s.Entities).Include(s => s.HistoryForms).FirstOrDefaultAsync(w => w.RecordId == data.recordId, cancellationToken);
        if (existingRecord.WorkflowStatus != WorkflowStatus.Deactive)
        {
            existingRecord.WorkflowStatus = WorkflowStatus.Deactive;
            await context.SaveChangesAsync(cancellationToken);
        }
        return Results.Ok();
    }
    static async Task<IResult> ActiviteWorkflowWithFlowAsync(
   [FromServices] WorkflowDBContext context,
   [FromBody] PostWorkflowWithFlowDynamic data,
   CancellationToken cancellationToken
   )
    {
        var existingRecord = await context.Workflows!.Include(s => s.Entities).Include(s => s.HistoryForms).FirstOrDefaultAsync(w => w.RecordId == data.recordId, cancellationToken);
        if (existingRecord.WorkflowStatus != WorkflowStatus.Active)
        {
            existingRecord.WorkflowStatus = WorkflowStatus.Active;
            await context.SaveChangesAsync(cancellationToken);
        }
        return Results.Ok();
    }
    private static async ValueTask<Result> InsertStateAndTransitions(DtoSaveWorkflowWithFlow request, WorkflowDBContext context, CancellationToken cancellationToken)
    {
        try
        {
            if (request.states != null && request.states.Any())
            {
                bool hasChanges = false;
                foreach (var state in request.states)
                {
                    var existingState = await context.States!.Include(s => s.PublicForms).Include(s => s.Titles).Include(s => s.Transitions)
               .FirstOrDefaultAsync(w => w.WorkflowName == request.name && w.Name == state.name, cancellationToken);
                    if (existingState == null)
                    {
                        State newRecord = new State
                        {
                            WorkflowName = request.name,
                            Name = state.name,
                            BaseStatus = state.baseStatus,
                            CreatedAt = DateTime.UtcNow,
                            CreatedByBehalfOf = Guid.NewGuid(),
                            Type = state.type,
                            IsPublicForm = state.isPublicForm,
                            PublicForms = state.publicForms.Select(s =>
                             new Translation
                             {
                                 Language = s.language,
                                 Label = s.label
                             }).ToList(),
                            Titles = state.title.Select(s =>
                            new Translation
                            {
                                Language = s.language,
                                Label = s.label
                            }).ToList()

                        };
                        await context!.States!.AddAsync(newRecord, cancellationToken);

                    }
                    else
                    {
                        if (existingState.BaseStatus != state.baseStatus || existingState.Type != state.type)
                        {
                            hasChanges = true;
                            existingState.BaseStatus = state.baseStatus;
                            existingState.Type = state.type;

                        }
                        if (state.title != null && state.title.Any())
                        {
                            foreach (var language in state.title)
                            {
                                Translation? translation = existingState.Titles.FirstOrDefault(f => f.Language == language.language);
                                if (translation != null && translation.Label != language.label)
                                {
                                    translation.Label = language.label;
                                    hasChanges = true;
                                }
                                else if (translation == null)
                                {
                                    existingState.Titles.Add(new Translation()
                                    {
                                        Label = language.label,
                                        Language = language.language
                                    });
                                    hasChanges = true;
                                }
                            }
                        }
                        if (state.publicForms != null && state.publicForms.Any())
                        {
                            foreach (var language in state.publicForms)
                            {
                                Translation? translation = existingState.PublicForms.FirstOrDefault(f => f.Language == language.language);
                                if (translation != null && translation.Label != language.label)
                                {
                                    translation.Label = language.label;
                                    hasChanges = true;
                                }
                                else if (translation == null)
                                {
                                    existingState.PublicForms.Add(new Translation()
                                    {
                                        Label = language.label,
                                        Language = language.language
                                    });
                                    hasChanges = true;
                                }
                            }
                        }

                    }

                }
                if (hasChanges)
                    await context!.SaveChangesAsync(cancellationToken);



            }
            if (request.transitions != null && request.transitions.Any())
            {
                bool hasChanges = false;
                foreach (var req in request.transitions)
                {
                    Transition? existingTransition = await context.Transitions.Include(s => s.Titles).Include(s => s.Forms).Include(s => s.Flow)
                  .Include(s => s.Page).ThenInclude(t => t.Pages)
                  .FirstOrDefaultAsync(db => db.Name == req.name, cancellationToken);
                    if (existingTransition == null)
                    {
                        context!.Transitions!.Add(new Transition
                        {
                            Name = req.name,
                            ToStateName = req.toState,
                            Flow = string.IsNullOrEmpty(req.message) ? null : new ZeebeMessage()
                            {
                                Name = req.message,
                                Message = req.message,
                                Gateway = req.gateway!,
                                CreatedAt = DateTime.UtcNow,
                                Process = request.name!,
                            },
                            FlowName = string.IsNullOrEmpty(req.message) ? null : req.message,
                            ServiceName = req.serviceName,
                            Titles = req.title.Select(s => new Translation()
                            {
                                Label = s.label,
                                Language = s.language
                            }).ToList(),
                            Forms = req.forms == null ? new List<Translation>() { } : req.forms.Select(s => new Translation()
                            {
                                Label = s.label,
                                Language = s.language
                            }).ToList(),
                            TypeofUi = req.typeofUi,
                            Page = req.page == null ? null : new Page()
                            {
                                Operation = req.page!.operation,
                                Type = req.page!.type,
                                Pages = req.page.pageRoute == null ? null : string.IsNullOrEmpty(req.page.pageRoute.language) ? null : new List<Translation>(){
                            new Translation{
                             Language=req.page.pageRoute.language,
                             Label=req.page.pageRoute.label
                            }
                            },
                                Timeout = req.page!.timeout

                            },
                            FromStateName = req.fromState,
                            CreatedAt = DateTime.UtcNow,
                            CreatedByBehalfOf = Guid.NewGuid(),
                        });
                        hasChanges = true;
                    }
                    else
                    {
                        if (existingTransition.ToStateName != req.toState)
                        {
                            existingTransition.ToStateName = req.toState;
                            hasChanges = true;
                        }
                        if (existingTransition.FromStateName != req.fromState)
                        {
                            existingTransition.FromStateName = req.fromState;
                            hasChanges = true;
                        }
                        if (existingTransition.TypeofUi != req.typeofUi)
                        {
                            existingTransition.TypeofUi = req.typeofUi;
                            hasChanges = true;
                        }
                        if (req!.message != existingTransition.FlowName)
                        {
                            if (string.IsNullOrEmpty(req!.message))
                            {
                                existingTransition.FlowName = null;
                                existingTransition.Flow = null;
                            }
                            else
                            {
                                ZeebeMessage? zeebeMessage = context!.ZeebeMessages!.FirstOrDefault(f => f.Name == req.message);
                                if (zeebeMessage == null)
                                {

                                    ZeebeMessage flow = new ZeebeMessage()
                                    {
                                        Name = req.message!,
                                        Gateway = req.gateway!,
                                        CreatedAt = DateTime.UtcNow,
                                        Message = req.message!,
                                        Process = request.name!
                                    };
                                    context!.ZeebeMessages.Add(flow);
                                    existingTransition.FlowName = flow.Name;
                                    existingTransition.Flow = flow;
                                }
                                else
                                {
                                    existingTransition.Flow = zeebeMessage;
                                    existingTransition.FlowName = req.message;
                                }


                            }
                            hasChanges = true;
                        }
                        if (req!.serviceName != existingTransition.ServiceName)
                        {
                            existingTransition.ServiceName = req.serviceName;

                            hasChanges = true;
                        }
                        if (req.title != null)
                        {
                            foreach (var language in req.title)
                            {
                                Translation? translation = existingTransition.Titles.FirstOrDefault(f => f.Language == language.language);
                                if (translation != null && translation.Label != language.label)
                                {
                                    translation.Label = language.label;
                                    hasChanges = true;
                                }
                                else if (translation == null)
                                {
                                    existingTransition.Titles.Add(new Translation()
                                    {
                                        Label = language.label,
                                        Language = language.language
                                    });
                                    hasChanges = true;
                                }
                            }
                        }
                        if (req.forms != null)
                        {
                            foreach (var language in req.forms)
                            {
                                Translation? translation = existingTransition.Forms.FirstOrDefault(f => f.Language == language.language);
                                if (translation != null && translation.Label != language.label)
                                {
                                    translation.Label = language.label;
                                    hasChanges = true;
                                }
                                else if (translation == null)
                                {
                                    existingTransition.Forms.Add(new Translation()
                                    {
                                        Label = language.label,
                                        Language = language.language
                                    });
                                    hasChanges = true;
                                }
                            }

                        }

                        if (req!.page != null)
                        {
                            Page? page = existingTransition.Page;
                            if (page != null)
                            {
                                if (page.Operation != req.page.operation)
                                {
                                    existingTransition.Page!.Operation = req.page.operation;
                                    hasChanges = true;
                                }
                                if (page.Type != req.page.type)
                                {
                                    existingTransition.Page!.Type = req.page.type;
                                    hasChanges = true;
                                }
                                if (page.Timeout != req.page.timeout)
                                {
                                    existingTransition.Page!.Timeout = req.page.timeout;
                                    hasChanges = true;
                                }
                                Translation? translation = existingTransition.Page!.Pages!.FirstOrDefault(f => f.Language == req.page.pageRoute!.language);
                                if (translation != null && req.page.pageRoute != null && translation.Label != req.page.pageRoute.label)
                                {
                                    translation.Label = req.page.pageRoute.label;
                                    hasChanges = true;
                                }

                                else if ((translation == null && req.page.pageRoute != null) ||
                                (translation != null && req.page.pageRoute == null))
                                {
                                    Page pageNew = new Page()
                                    {
                                        Id = new Guid(),
                                        Operation = req.page!.operation,
                                        Type = req.page!.type,
                                        Pages = req.page.pageRoute == null ? null : new List<Translation>(){
                            new Translation{
                             Language=req.page.pageRoute.language,
                             Label=req.page.pageRoute.label
                            }

                        },
                                        Timeout = req.page!.timeout
                                    };
                                    context.Pages.Add(pageNew);
                                    existingTransition.Page = pageNew;
                                    existingTransition.PageId = pageNew.Id;
                                    hasChanges = true;
                                }
                                else
                                {

                                }
                            }
                            else
                            {
                                Page pageNew = new Page()
                                {
                                    Id = new Guid(),
                                    Operation = req.page!.operation,
                                    Type = req.page!.type,
                                    Pages = req.page.pageRoute == null ? null : new List<Translation>(){
                            new Translation{
                             Language=req.page.pageRoute.language,
                             Label=req.page.pageRoute.label
                            }

                        },
                                    Timeout = req.page!.timeout
                                };
                                context.Pages.Add(pageNew);
                                existingTransition.Page = pageNew;
                                existingTransition.PageId = pageNew.Id;
                                hasChanges = true;
                            }
                        }
                    }

                }
                if (hasChanges)
                    await context!.SaveChangesAsync(cancellationToken);
            }

            return new Result(Status.Success, "Success");
        }
        catch (Exception ex)
        {
            return new Result(Status.Error, ex.ToString());
        }
    }
    static async ValueTask<IResult> getAllWorkflowWithFullTextSearch(
           [FromServices] WorkflowDBContext context,
           [AsParameters] WorkflowSearch userSearch,
   CancellationToken cancellationToken
           )
    {
        var query = context!.Workflows!
            .Include(d => d.Entities)
            .Include(x => x.States).ThenInclude(s => s.Transitions).AsQueryable()
            ;

        if (!string.IsNullOrEmpty(userSearch.Keyword))
        {
            query = query.AsNoTracking().Where(p => p.SearchVector.Matches(EF.Functions.PlainToTsQuery("english", userSearch.Keyword)));
        }

        if (!string.IsNullOrEmpty(userSearch.WorkflowEntities))
        {
            query = query.AsNoTracking().Where(p => p.Entities.Any(t => t.Name == userSearch.WorkflowEntities));
        }

        var workflows = query.Skip(userSearch.Page * userSearch.PageSize)
            .Take(userSearch.PageSize);

        if (await workflows.CountAsync(cancellationToken) > 0)
        {
            var response = query.Select(s => new GetWorkflowDefinition(
                s.Name,
                s.Titles.FirstOrDefault()!.Label,
                s.Tags!,
                s.Entities.Select(e => new GetWorkflowEntity(
         e.Name, e.InclusiveWorkflows == null ? false : true, e.IsStateManager,
         new StatusType[]{
        e.AvailableInStatus
         }
    )).ToArray(),
                s.RecordId == null ? string.Empty : s.RecordId.ToString()
                ));

            return Results.Ok(response);
        }

        return Results.NoContent();
    }

    static async ValueTask<IResult> getAllWorkflowByRecordId(
           [FromServices] WorkflowDBContext context,
           [FromRoute(Name = "recordId")] string recordIdAsString,
           CancellationToken cancellationToken
           )
    {
        Guid recordId;
        if (!Guid.TryParse(recordIdAsString, out recordId))
        {
            return Results.BadRequest("RecordID not provided or not as a GUID");
        }
        var workflow = await context!.Workflows!
            .Include(d => d.Entities)
            .Include(x => x.States).ThenInclude(s => s.Titles)
            .Include(x => x.States).ThenInclude(s => s.Transitions).ThenInclude(s => s.Forms)
            .Include(x => x.States).ThenInclude(s => s.Transitions).ThenInclude(s => s.Titles)
            .Include(x => x.States).ThenInclude(s => s.Transitions).ThenInclude(s => s.Flow)
            .Include(x => x.States).ThenInclude(s => s.Transitions).ThenInclude(s => s.Page).ThenInclude(s => s!.Pages)
            .Where(w => w.RecordId == recordId).Select(s => new GetWorkflowDefinitionWithStates(
                    s.Name,
                    s.Titles.FirstOrDefault()!.Label,
                    s.Tags!,
                    s.Entities.Select(e => new GetWorkflowEntity(
             e.Name, e.InclusiveWorkflows == null ? false : true, e.IsStateManager,
             new StatusType[]{
        e.AvailableInStatus
             }
        )).ToArray(),
        s.States.Select(st => new GetStateDefinitionWithMultiLanguage(
            st.Name,
            st.Titles.Select(tit => new amorphie.workflow.core.Dtos.MultilanguageText(tit.Language, tit.Label)).ToArray(),
            st.BaseStatus,
            st.Transitions.Select(tr => new PostTransitionWithMultiLanguage(
                tr.Name,
                tr.Titles.Select(tit => new amorphie.workflow.core.Dtos.MultilanguageText(tit.Language, tit.Label)).ToArray(),
                tr.ToStateName,
                tr.Forms.Select(tit => new amorphie.workflow.core.Dtos.MultilanguageText(tit.Language, tit.Label)).ToArray(),
                tr.FromStateName,
                tr.ServiceName,
                tr.FlowName,
                tr.Flow == null ? string.Empty : tr.Flow.Gateway,
                tr.Page == null ? null : new PostPageDefinitionRequest(tr.Page.Operation, tr.Page.Type, tr.Page.Pages.Any() ? tr.Page.Pages.Select(tit => new amorphie.workflow.core.Dtos.MultilanguageText(tit.Language, tit.Label)).FirstOrDefault() : null, tr.Page.Timeout)))
            .ToArray())).ToArray(),
             s.RecordId == null ? string.Empty : s.RecordId.ToString()
                    )).FirstOrDefaultAsync(cancellationToken);

        if (workflow == null)
        {
            return Results.NoContent();
        }
        else
        {

            return Results.Ok(workflow);
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
        // TODO : Include a parameter for the cancelation token and convert all ToList objects to ToListAsync with the cancelation token.
        var query = context!.States!.Where(w => w.Name == state && w.WorkflowName == definition)
               .Include(w => w.Titles.Where(t => t.Language == language));


        var states = query
        .Skip(page.GetValueOrDefault(0) * pageSize.GetValueOrDefault(10))
        .Take(pageSize.GetValueOrDefault(10)).Select(s => new GetStateDefinition(
            s.Name,
            s.Titles.Where(s => s.Language == language).Select(s => new amorphie.workflow.core.Dtos.MultilanguageText(s.Language, s.Label)).First(),
            s.BaseStatus!,
            s.Transitions.Select(e => new PostTransitionDefinitionRequest(
     e.Name, e.Titles.Where(s => s.Language == language).Select(s => new amorphie.workflow.core.Dtos.MultilanguageText(s.Language, s.Label)).First(),
     e.ToStateName!, e.Forms.Where(s => s.Language == language).Select(s => new amorphie.workflow.core.Dtos.MultilanguageText(s.Language, s.Label)).FirstOrDefault(),
     e.FromStateName!, e.ServiceName, e.FlowName,
     e.Flow != null ? e.Flow.Gateway : null, e.Page == null ? null
     : new PostPageDefinitionRequest(e.Page.Operation, e.Page.Type, e.Page.Pages == null || e.Page.Pages.Count == 0 ? null :
     new amorphie.workflow.core.Dtos.MultilanguageText(language!, e.Page.Pages!.FirstOrDefault(f => f.Language == language)!.Label), e.Page.Timeout),
     e.HistoryForms != null && e.HistoryForms.Count() > 0 ? e.HistoryForms.Select(s => new amorphie.workflow.core.Dtos.MultilanguageText(s.Language, s.Label)).ToArray() : null,
     e.TypeofUi

)).ToArray()
            ))
//    .ToList();
;
        return Results.Ok(states);
    }
    static IResult deleteState(
            [FromServices] WorkflowDBContext context,
            [FromRoute(Name = "name")] string definition,
              [FromRoute(Name = "state-name")] string state,
               [FromHeader(Name = "Language")] string? language = "en-EN"
        )
    {
        var existingRecord = context.States!.Include(w => w.Titles)
        .Include(w => w.Descriptions)
         .Include(w => w.PublicForms)
        .Include(w => w.Transitions).ThenInclude(s => s.Titles)
        .Include(w => w.Transitions).ThenInclude(s => s.Pages)
        .Include(w => w.Transitions).ThenInclude(s => s.Forms)
       .FirstOrDefault(w => w.WorkflowName == definition && w.Name == state)
       ;


        if (existingRecord != null)
        {
            var toStateChangesTrans = context.Transitions!.Where(w => w.ToStateName == state);
            foreach (var transition in toStateChangesTrans)
            {
                transition.ToStateName = null;
                transition.ToState = null;
            }

            foreach (var transition in existingRecord.Transitions)
            {
                var InstanceTransitions = context.InstanceTransitions.Where(w => w.TransitionName == transition.Name);
                foreach (InstanceTransition instanceTr in InstanceTransitions)
                {
                    instanceTr.TransitionName = null;
                    instanceTr.Transition = null;
                }
            }
            context!.Remove(existingRecord);
            // TODO : Include a parameter for the cancelation token and convert SaveChanges to SaveChangesAsync with the cancelation token.
            context.SaveChanges();
            // return new Response
            // {
            //     Result = new Result(Status.Success, "Success"),
            // };
            return Results.Ok();
        }
        else
        {
            return Results.NoContent();
        }

    }
    static IResult saveState(
        [FromServices] WorkflowDBContext context,
        [FromRoute(Name = "definitionname")] string definition,
        [FromBody] PostStateDefinitionRequest data,
        [FromHeader(Name = "Language")] string? language = "en-EN"
        )
    {
        // data.transitions[0].
        var existingRecord = context.States!.Include(s => s.Titles).Include(s => s.Transitions).Include(s => s.PublicForms)
               .FirstOrDefault(w => w.WorkflowName == definition && w.Name == data.name)
               ;
        if (existingRecord == null)
        {
            State newRecord = new State
            {
                WorkflowName = definition,
                Name = data.name,
                BaseStatus = data.baseStatus,
                CreatedAt = DateTime.UtcNow,
                CreatedByBehalfOf = Guid.NewGuid(),
                Type = data.type,
                IsPublicForm = data.ispublicForm,
                PublicForms = data.publicForms.Select(s => new Translation()
                {

                    Language = s.language,
                    Label = s.label
                }).ToList(),
                Transitions = data!.transitions!.Select(x => new Transition
                {
                    Name = x.name,
                    ServiceName = x.serviceName,
                    TypeofUi = x.typeofUi,
                    Flow = x.message == null ? null : new ZeebeMessage()
                    {
                        Name = x.message,
                        Message = x.message,
                        Gateway = x.gateway!,
                        CreatedAt = DateTime.UtcNow,
                        Process = definition,
                    },
                    Page = x.page == null ? null : new Page()
                    {
                        Operation = x.page!.operation,
                        Type = x.page!.type,
                        Pages = x.page.pageRoute == null ? null : new List<Translation>(){
                            new Translation{
                             Language=x.page.pageRoute.language,
                             Label=x.page.pageRoute.label
                            }
                        },
                        Timeout = x.page!.timeout

                    },
                    Titles = new List<Translation>(){
                            new Translation{
                             Language=x.title.language,
                             Label=x.title.label
                            }
                        },
                    Forms = x.form == null ? new List<Translation>() { } : new List<Translation>(){
                            new Translation{
                             Language=x.form!.language,
                             Label=x.form!.label
                            }
                        },
                    HistoryForms = x.historyForms == null ? new List<Translation>() { } : x.historyForms.Select(s => new Translation()
                    {
                        Label = s.label,
                        Language = s.language
                    }).ToList(),
                    ToState = context!.States!.FirstOrDefault(f => f.Name == x.toState),
                    ToStateName = context!.States!.FirstOrDefault(f => f.Name == x.toState) != null ? x.toState : null,
                    CreatedAt = DateTime.UtcNow,
                    //  Type = TransitionType.AutoTransition,
                    CreatedByBehalfOf = Guid.NewGuid(),
                }).ToList(),
                Titles = new List<Translation>(){
                            new Translation{
                             Language=data.title.language,
                             Label=data.title.label
                            }
                        }
            };
            context!.States!.Add(newRecord);
            // TODO : Include a parameter for the cancelation token and convert SaveChanges to SaveChangesAsync with the cancelation token.
            context!.SaveChanges();
            //AutoMapper a alıncak 
            // return new Response<GetStateDefinition>
            // {
            //     Data=null,
            //     Result=new Result(Status.Success,"Success Create")
            // };
            return Results.Created($"workflow/definition/>{definition}/state?state-name:" + data.name, definition);
        }
        else
        {
            var hasChanges = false;
            if (existingRecord.BaseStatus != data.baseStatus || existingRecord.Type != data.type)
            {
                hasChanges = true;
                existingRecord.BaseStatus = data.baseStatus;
                existingRecord.Type = data.type;

            }
            if (data.title != null)
            {
                Translation? translation = existingRecord.Titles.FirstOrDefault(f => f.Language == language);
                if (translation != null && translation.Label != data.title.label)
                {
                    translation.Label = data.title.label;
                    hasChanges = true;
                }
            }
            if (data.publicForms != null && data.publicForms.Any())
            {
                foreach (var languageForm in data.publicForms)
                {
                    Translation? translation = existingRecord.PublicForms.FirstOrDefault(f => f.Language == languageForm.language);
                    if (translation != null && translation.Label != languageForm.label)
                    {
                        translation.Label = languageForm.label;
                        hasChanges = true;
                    }
                    else if (translation == null)
                    {

                        existingRecord.PublicForms.Add(new Translation()
                        {
                            Label = languageForm.label,
                            Language = languageForm.language
                        });
                        existingRecord.ModifiedAt = DateTime.UtcNow;
                        hasChanges = true;
                    }
                }
            }
            foreach (var req in data.transitions)
            {
                Transition? existingTransition = context.Transitions.Include(s => s.Titles).Include(s => s.Forms).Include(s => s.Flow)
                .Include(s => s.Page).ThenInclude(t => t.Pages)
                .FirstOrDefault(db => db.Name == req.name && db.FromStateName == existingRecord.Name);
                //Kayıdı olmayan Transition ların eklenmesi
                if (existingTransition == null)
                {
                    context!.Transitions!.Add(new Transition
                    {
                        Name = req.name,
                        ToStateName = context!.States!.FirstOrDefault(f => f.Name == req.toState) != null ? req.toState : string.Empty,
                        ToState = context!.States!.FirstOrDefault(f => f.Name == req.toState),
                        ServiceName = req.serviceName,

                        Titles = new List<Translation>(){
                            new Translation(){
                                Label=req.title.label,
                                Language=req.title.language
                            }
                        },
                        Forms = req.form == null ? new List<Translation>() { } : new List<Translation>(){
                            new Translation(){
                                Label=req.form!.label,
                                Language=req.form!.language
                            }
                        },
                        TypeofUi = req.typeofUi,
                        HistoryForms = req.historyForms == null ? new List<Translation>() { } : req.historyForms.Select(s => new Translation
                        {
                            Label = s.label,
                            Language = s.language
                        }).ToArray(),
                        Page = req.page == null ? null : new Page()
                        {
                            Operation = req.page!.operation,
                            Type = req.page!.type,
                            Pages = req.page.pageRoute == null ? null : new List<Translation>(){
                            new Translation{
                             Language=req.page.pageRoute.language,
                             Label=req.page.pageRoute.label
                            }
                        },
                            Timeout = req.page!.timeout

                        },
                        FromStateName = req.fromState,
                        CreatedAt = DateTime.UtcNow,
                        CreatedByBehalfOf = Guid.NewGuid(),
                    });
                    hasChanges = true;
                }
                else
                {
                    if (existingTransition.ToStateName != req.toState)
                    {
                        existingTransition.FlowName = req.message;
                        //Kayıdı olup update edilmesi gereken transitionlar 
                        // existingTransition.FromStateName = req.fromState!;
                        existingTransition.ToState = context!.States!.FirstOrDefault(f => f.Name == req.toState);
                        if (existingTransition.ToState != null)
                            existingTransition.ToStateName = req.toState;
                        // existingTransition.FromState = req.fromState!=null?context!.States!.FirstOrDefault(f => f.Name == req.fromState)!:default!;
                        hasChanges = true;
                    }
                    if (existingTransition.TypeofUi != req.typeofUi)
                    {
                        existingTransition.TypeofUi = req.typeofUi;
                        hasChanges = true;
                    }
                    if (req!.message != existingTransition.FlowName)
                    {
                        if (string.IsNullOrEmpty(req!.message))
                        {
                            existingTransition.FlowName = null;
                            existingTransition.Flow = null;
                        }
                        else
                        {
                            ZeebeMessage? zeebeMessage = context!.ZeebeMessages!.FirstOrDefault(f => f.Name == req.message);
                            if (zeebeMessage == null)
                            {

                                ZeebeMessage flow = new ZeebeMessage()
                                {
                                    Name = req.message!,
                                    Gateway = req.gateway!,
                                    CreatedAt = DateTime.UtcNow,
                                    Message = req.message!,
                                    Process = definition,
                                };
                                context!.ZeebeMessages.Add(flow);
                                existingTransition.FlowName = flow.Name;
                                existingTransition.Flow = flow;
                            }
                            else
                            {
                                existingTransition.Flow = zeebeMessage;
                                existingTransition.FlowName = req.message;
                            }


                        }
                        hasChanges = true;
                    }
                    if (req!.serviceName != existingTransition.ServiceName)
                    {
                        existingTransition.ServiceName = req.serviceName;

                        hasChanges = true;
                    }
                    if (req.title != null)
                    {
                        Translation? translation = existingTransition.Titles.FirstOrDefault(f => f.Language == language);
                        if (translation != null && translation.Label != req.title.label)
                        {
                            translation.Label = req.title.label;
                            hasChanges = true;
                        }
                    }
                    if ((existingTransition.HistoryForms == null || existingTransition.HistoryForms.Count == 0) && (req.historyForms != null && req.historyForms.Count() > 0))
                    {
                        existingTransition.HistoryForms = req.historyForms.Select(s => new Translation
                        {
                            Label = s.label,
                            Language = s.language
                        }).ToList();
                    }
                    else if (req.historyForms != null && req.historyForms.Count() > 0)
                    {
                        foreach (var historyFormTranslantion in req.historyForms)
                        {
                            if (existingTransition.HistoryForms == null)
                            {
                                existingTransition.HistoryForms = new List<Translation>();
                                existingTransition.HistoryForms.Add(new Translation()
                                {
                                    Label = historyFormTranslantion.label,
                                    Language = historyFormTranslantion.language
                                });
                            }
                            else
                            {
                                Translation? translation = existingTransition.HistoryForms.FirstOrDefault(f => f.Language == historyFormTranslantion.language);
                                if (translation != null && translation.Label != historyFormTranslantion.label)
                                {
                                    translation.Label = historyFormTranslantion.label;
                                    hasChanges = true;
                                }
                                else if (translation == null)
                                {
                                    existingTransition.HistoryForms.Add(new Translation()
                                    {
                                        Label = historyFormTranslantion.label,
                                        Language = historyFormTranslantion.language
                                    });
                                }
                            }

                        }


                    }
                    if (req.form != null)
                    {
                        Translation? translation = existingTransition.Forms.FirstOrDefault(f => f.Language == language);
                        if (translation != null && translation.Label != req.form.label)
                        {
                            translation.Label = req.form.label;
                            hasChanges = true;
                        }
                    }

                    if (req!.page != null)
                    {
                        Page? page = existingTransition.Page;
                        if (page != null)
                        {
                            if (page.Operation != req.page.operation)
                            {
                                existingTransition.Page!.Operation = req.page.operation;
                                hasChanges = true;
                            }
                            if (page.Type != req.page.type)
                            {
                                existingTransition.Page!.Type = req.page.type;
                                hasChanges = true;
                            }
                            if (page.Timeout != req.page.timeout)
                            {
                                existingTransition.Page!.Timeout = req.page.timeout;
                                hasChanges = true;
                            }
                            Translation? translation = existingTransition.Page!.Pages!.FirstOrDefault(f => f.Language == language);
                            if (translation != null && req.page.pageRoute != null && translation.Label != req.page.pageRoute.label)
                            {
                                translation.Label = req.page.pageRoute.label;
                                hasChanges = true;
                            }

                            else if ((translation == null && req.page.pageRoute != null) ||
                            (translation != null && req.page.pageRoute == null))
                            {
                                Page pageNew = new Page()
                                {
                                    Id = new Guid(),
                                    Operation = req.page!.operation,
                                    Type = req.page!.type,
                                    Pages = req.page.pageRoute == null ? null : new List<Translation>(){
                            new Translation{
                             Language=req.page.pageRoute.language,
                             Label=req.page.pageRoute.label
                            }

                        },
                                    Timeout = req.page!.timeout
                                };
                                context.Pages.Add(pageNew);
                                existingTransition.Page = pageNew;
                                existingTransition.PageId = pageNew.Id;
                                hasChanges = true;
                            }
                            else
                            {

                            }
                        }
                        else
                        {
                            Page pageNew = new Page()
                            {
                                Id = new Guid(),
                                Operation = req.page!.operation,
                                Type = req.page!.type,
                                Pages = req.page.pageRoute == null ? null : new List<Translation>(){
                            new Translation{
                             Language=req.page.pageRoute.language,
                             Label=req.page.pageRoute.label
                            }

                        },
                                Timeout = req.page!.timeout
                            };
                            context.Pages.Add(pageNew);
                            existingTransition.Page = pageNew;
                            existingTransition.PageId = pageNew.Id;
                            hasChanges = true;
                        }
                    }
                }

            }
            if (hasChanges)
            {
                // TODO : Include a parameter for the cancelation token and convert SaveChanges to SaveChangesAsync with the cancelation token.
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


