
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using amorphie.core.Base;
using amorphie.core.Enums;
using amorphie.core.Extension;
using amorphie.core.IBase;
using amorphie.workflow.core.Dtos;
using amorphie.workflow.core.Dtos.Definition;
using amorphie.workflow.core.Dtos.Hierarchy;

using amorphie.workflow.core.Models.SemanticVersion;
using amorphie.workflow.service.Db;
using amorphie.workflow.service.Filters;
using amorphie.workflow.core.Dtos.Transfer;



using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Semver;
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
               .WithOpenApi(operation =>
            {
                operation.Parameters[5].Description = "Enum :  OrderByDescending=>1,OrderBy=>0";
                return operation;
            })
       .WithSummary("Gets registered workflows")
       .WithDescription("Returns existing workflows with metadata.Query parameter reference is can contain request or order reference of workflow.")
       .Produces<GetWorkflowDefinition[]>(StatusCodes.Status200OK)
       .Produces(StatusCodes.Status404NotFound);
       
        app.MapGet("/workflow/definition/search/names", getAllWorkflowNameWithFullTextSearch)
               .WithOpenApi(operation =>
            {
                operation.Parameters[5].Description = "Enum :  OrderByDescending=>1,OrderBy=>0";
                return operation;
            })
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
        app.MapGet("/workflow/definition/{workflowName}/hyerarchy", getWorkflowHierarchy)
      .WithOpenApi(operation =>
      {

          operation.Tags = new List<OpenApiTag> { new() { Name = "Definition" } };

          operation.Responses = new OpenApiResponses
          {
          };
          return operation;
      });
        app.MapGet("/workflow/definition/{workflowName}/hyerarchy/v2", getWorkflowHierarchyV2)
      .WithOpenApi(operation =>
      {

          operation.Tags = new List<OpenApiTag> { new() { Name = "Definition" } };

          operation.Responses = new OpenApiResponses
          {
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
    async static Task<IResult> deleteDefinition(
         [FromServices] WorkflowDBContext context,
         CancellationToken cancellationToken,
         [FromRoute(Name = "definition-name")] string definition
     )
    {

        try
        {
            var existingRecord = context.Workflows!.Include(s => s.Titles)
                  .Include(s => s.States).ThenInclude(s => s.Descriptions)
                   .Include(s => s.States).ThenInclude(s => s.PublicForms)
                   .Include(s => s.States).ThenInclude(w => w.UiForms).ThenInclude(s => s.Forms)
                   .Include(s => s.States).ThenInclude(s => s.Titles)
                  .Include(s => s.States).ThenInclude(s => s.Transitions).ThenInclude(s => s.Titles)
                  .Include(s => s.States).ThenInclude(s => s.Transitions).ThenInclude(s => s.Forms)
                  .Include(s => s.States).ThenInclude(s => s.Transitions).ThenInclude(s => s.Page).ThenInclude(s => s.Pages)
                .Include(s => s.States).ThenInclude(w => w.Transitions).ThenInclude(s => s.UiForms).ThenInclude(s => s.Forms)
                .Include(s => s.Entities)
                .Include(s => s.HistoryForms)

                 .FirstOrDefault(w => w.Name == definition);
            if (existingRecord != null && existingRecord.States.Any())
            {
                foreach (State state in existingRecord.States)
                {
                    var toStateChangesTrans = context.Transitions!.Where(w => w.ToStateName == state.Name);
                    foreach (var transition in toStateChangesTrans)
                    {
                        transition.ToStateName = null;
                        transition.ToState = null;
                    }

                    foreach (var transition in state.Transitions)
                    {
                        var InstanceTransitions = context.InstanceTransitions.Where(w => w.TransitionName == transition.Name);
                        foreach (InstanceTransition instanceTr in InstanceTransitions)
                        {
                            instanceTr.TransitionName = null;
                            instanceTr.Transition = null;
                        }
                    }
                    context!.Remove(state);
                }

            }
            if (existingRecord != null)
            {
                context!.Remove(existingRecord);
                // TODO : Include a parameter for the cancelation token and convert SaveChanges to SaveChangesAsync with the cancelation token.
                await context.SaveChangesAsync(cancellationToken);
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
  async  static Task<IResult> saveDefinition(
      [FromBody] PostWorkflowDefinitionRequest data,
      [FromServices] WorkflowDBContext context,
      [FromServices] amorphie.workflow.service.Db.VersionService versionService,
      CancellationToken token,
      [FromHeader(Name = "Language")] string? language = "en-EN"
      )
    {
        var existingRecord =await context.Workflows!.Include(s => s.Entities).Include(s => s.HistoryForms).FirstOrDefaultAsync(w => w.Name == data.name,token);
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
                IsForbiddenData = data.IsForbiddenData,
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
            newWorkflow.SemVer=new SemVersion(1,0,0).ToString();
           
            await context!.Workflows!.AddAsync(newWorkflow,token);
            
            await context.SaveChangesAsync(token);
            await versionService.SaveVersionWorkflow(newWorkflow.Name,newWorkflow.SemVer,token);
            return Results.Created($"/workflow/definition/{data.name}", data);

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
            if (data.IsForbiddenData != null && data.IsForbiddenData != existingRecord.IsForbiddenData)
            {
                hasChanges = true;
                existingRecord.IsForbiddenData = data.IsForbiddenData;
                existingRecord.ModifiedAt = DateTime.UtcNow;
            }
            if ((existingRecord.HistoryForms == null || existingRecord.HistoryForms.Count == 0) && (data.historyForms != null && data.historyForms.Count() > 0))
            {
                existingRecord.HistoryForms = data.historyForms.Select(s => new Translation
                {
                    Id = Guid.NewGuid(),
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
            {   if(string.IsNullOrEmpty(existingRecord.SemVer))
                {
                    existingRecord.SemVer=new SemVersion(1,0,0).ToString();
                }
                SemVersion version= SemVersion.Parse(existingRecord.SemVer, SemVersionStyles.Any);
                version=version.WithMajor(version.Major+1);
                existingRecord.SemVer=version.ToString();
                await context!.SaveChangesAsync(token);
                await versionService.SaveVersionWorkflow(existingRecord.Name,existingRecord.SemVer,token);
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
  [FromServices] VersionService versionService,
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
            newWorkflow.SemVer=new SemVersion(1,0,0).ToString();
            await context!.Workflows!.AddAsync(newWorkflow,cancellationToken);

            await context.SaveChangesAsync(cancellationToken);
            
            var resultState = await InsertStateAndTransitions(request, context, cancellationToken);
            await versionService.SaveVersionWorkflow(newWorkflow.Name,newWorkflow.SemVer,cancellationToken);
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
                    Id = Guid.NewGuid(),
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
                if(string.IsNullOrEmpty(existingRecord.SemVer))
                {
                    existingRecord.SemVer=new SemVersion(1,0,0).ToString();
                }
                SemVersion version= SemVersion.Parse(existingRecord.SemVer, SemVersionStyles.Any);
                version=version.WithMajor(version.Major+1);
                existingRecord.SemVer=version.ToString();
                await context!.SaveChangesAsync(cancellationToken);
                await versionService.SaveVersionWorkflow(existingRecord.Name,existingRecord.SemVer,cancellationToken);
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
             if(string.IsNullOrEmpty(existingRecord.SemVer))
                {
                    existingRecord.SemVer=new SemVersion(1,0,0).ToString();
                }
                SemVersion version= SemVersion.Parse(existingRecord.SemVer, SemVersionStyles.Any);
                version=version.WithMajor(version.Major+1);
                existingRecord.SemVer=version.ToString();
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
             if(string.IsNullOrEmpty(existingRecord.SemVer))
                {
                    existingRecord.SemVer=new SemVersion(1,0,0).ToString();
                }
                SemVersion version= SemVersion.Parse(existingRecord.SemVer, SemVersionStyles.Any);
                version=version.WithMajor(version.Major+1);
                existingRecord.SemVer=version.ToString();
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
                                        Id = Guid.NewGuid(),
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
                                    Id = Guid.NewGuid(),
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
           [AsParameters] WorkflowSearch workflowSearch,
   CancellationToken cancellationToken
           )
    {
        var query = context!.Workflows!
            .Include(d => d.Entities)
            .Include(x => x.States).ThenInclude(s => s.Transitions).AsQueryable()
            ;

        if (!string.IsNullOrEmpty(workflowSearch.Keyword))
        {
            query = query.AsNoTracking().Where(p => p.SearchVector.Matches(EF.Functions.PlainToTsQuery("english", workflowSearch.Keyword)));
        }

        if (!string.IsNullOrEmpty(workflowSearch.WorkflowEntities))
        {
            query = query.AsNoTracking().Where(p => p.Entities.Any(t => t.Name == workflowSearch.WorkflowEntities));
        }
        query = await query.Sort<Workflow>(workflowSearch.SortColumn, workflowSearch.SortDirection);

        var workflows = query.Skip(workflowSearch.Page * workflowSearch.PageSize)
            .Take(workflowSearch.PageSize);

        if (await workflows.CountAsync(cancellationToken) > 0)
        {
            var response = workflows.Select(s => new GetWorkflowDefinition(
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
    static async ValueTask<IResult> getAllWorkflowNameWithFullTextSearch(
           [FromServices] WorkflowDBContext context,
           [AsParameters] WorkflowSearch workflowSearch,
   CancellationToken cancellationToken
           )
    {
        var query = context!.Workflows!
            .Include(d => d.Entities)
            .Include(x => x.States).ThenInclude(s => s.Transitions).AsQueryable()
            ;

        if (!string.IsNullOrEmpty(workflowSearch.Keyword))
        {
            query = query.AsNoTracking().Where(p => p.SearchVector.Matches(EF.Functions.PlainToTsQuery("english", workflowSearch.Keyword)));
        }

        if (!string.IsNullOrEmpty(workflowSearch.WorkflowEntities))
        {
            query = query.AsNoTracking().Where(p => p.Entities.Any(t => t.Name == workflowSearch.WorkflowEntities));
        }
        query = await query.Sort<Workflow>(workflowSearch.SortColumn, workflowSearch.SortDirection);
        query = query.Skip(workflowSearch.Page * workflowSearch.PageSize)
            .Take(workflowSearch.PageSize);

        var workflows = await query.Select(s => new SelectDto
        {
            Name = s.Name
        }).ToListAsync(cancellationToken);

        if (workflows.Any())
        {
            return Results.Ok(workflows);
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

    static async Task<IResult> getState(
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
     e.ToStateName!, e.UiForms.Any() ? null : e.UiForms.Select(st => new amorphie.workflow.core.Dtos.UiFormDto()
     {
         typeofUi = st.TypeofUiEnum,
         navigationType = st.Navigation,
         forms = st.Forms.Select(sf => new amorphie.workflow.core.Dtos.MultilanguageText(
         sf.Language, sf.Label)).ToArray()
     }).ToArray(),
     e.FromStateName!, e.ServiceName, e.FlowName,
     e.Flow != null ? e.Flow.Gateway : null, e.Page == null ? null
     : new PostPageDefinitionRequest(e.Page.Operation, e.Page.Type, e.Page.Pages == null || e.Page.Pages.Count == 0 ? null :
     new amorphie.workflow.core.Dtos.MultilanguageText(language!, e.Page.Pages!.FirstOrDefault(f => f.Language == language)!.Label), e.Page.Timeout),
     e.HistoryForms != null && e.HistoryForms.Count() > 0 ? e.HistoryForms.Select(s => new amorphie.workflow.core.Dtos.MultilanguageText(s.Language, s.Label)).ToArray() : null,
     e.TypeofUi, e.transitionButtonType

)).ToArray()
            ))
//    .ToList();
;
        return Results.Ok(states);
    }
    static  async Task<IResult> deleteState(
            [FromServices] WorkflowDBContext context,
             [FromServices] amorphie.workflow.service.Db.VersionService versionService,
            [FromRoute(Name = "name")] string definition,
              [FromRoute(Name = "state-name")] string state,
              CancellationToken token,
               [FromHeader(Name = "Language")] string? language = "en-EN"
        )
    {
        var existingRecord =await context.States!.Include(w => w.Titles)
        .Include(w => w.Descriptions)
         .Include(w => w.PublicForms)
          .Include(w => w.UiForms).ThenInclude(s => s.Forms)
        .Include(w => w.Transitions).ThenInclude(s => s.Titles)
        .Include(w => w.Transitions).ThenInclude(s => s.Pages)
        .Include(w => w.Transitions).ThenInclude(s => s.Forms)
        .Include(w => w.Transitions).ThenInclude(s => s.UiForms).ThenInclude(s => s.Forms)
       .FirstOrDefaultAsync(w => w.WorkflowName == definition && w.Name == state,token)
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
            Workflow? workflow=await context.Workflows.FirstOrDefaultAsync(w=>w.Name==definition,token);
            if(string.IsNullOrEmpty(workflow!.SemVer))
            {
                    workflow.SemVer=new SemVersion(1,0,0).ToString();
            }
            SemVersion version= SemVersion.Parse(workflow.SemVer, SemVersionStyles.Any);
            version=version.WithMinor(version.Minor+1);
            workflow.SemVer=version.ToString();
            await context.SaveChangesAsync(token);

            await versionService.SaveVersionWorkflow(workflow.Name,version.ToString(),token);
            return Results.Ok();
        }
        else
        {
            return Results.NoContent();
        }

    }
    static async Task<IResult> saveState(
        [FromServices] WorkflowDBContext context,
        [FromServices] VersionService versionService,
        [FromRoute(Name = "definitionname")] string definition,
        [FromBody] PostStateDefinitionRequest data,
        CancellationToken token,
        [FromHeader(Name = "Language")] string? language = "en-EN"
        )
    {
        var workflowControl =await context.Workflows!
               .FirstOrDefaultAsync(w => w.Name == definition,token)
               ;
        if (workflowControl == null)
        {
            return Results.Problem("There is no " + definition + " named flow");
        }
        var existingRecord =await context.States!.Include(s => s.Titles).Include(s => s.Transitions).Include(s => s.PublicForms)
        .Include(s => s.UiForms).ThenInclude(s => s.Forms)
               .FirstOrDefaultAsync(w => w.WorkflowName == definition && w.Name == data.name)
               ;
        if (existingRecord == null)
        {
            var existingRecordControl =await context.States!
               .FirstOrDefaultAsync(w => w.Name == data.name)
               ;
            if (existingRecordControl != null)
            {
                return Results.Problem("There is already " + data.name + " state in " + existingRecordControl.WorkflowName + " flow");
            }
            if (data!.transitions!.Any())
            {
                var controlList = data!.transitions!.Select(s => s.name).ToList();
                var existingTransitionsControl = await context.Transitions!
                              .FirstOrDefaultAsync(w => controlList.Any(a => a == w.Name),token)
                              ;
                if (existingTransitionsControl != null)
                {
                    return Results.Problem("There is already " + existingTransitionsControl.Name + " transition in " + existingTransitionsControl.FromStateName + " state");
                }
            }

            State newRecord = new State
            {
                WorkflowName = definition,
                Name = data.name,
                BaseStatus = data.baseStatus,
                CreatedAt = DateTime.UtcNow,
                CreatedByBehalfOf = Guid.NewGuid(),
                Type = data.type,
                AllowedSuffix = data.allowedSuffix,
                IsPublicForm = data.ispublicForm,
                SubWorkflowName = string.IsNullOrEmpty(data.subWorkflowName) ? null : data.subWorkflowName,
                MFAType = data.mfaType,
                InitPageName = data.type == StateType.Start ? data.initPageName : string.Empty,
                PublicForms = data.ispublicForm == true && data.publicForms.Any() && data.publicForms.First().forms.Any() ? data.publicForms.FirstOrDefault().forms.Select(s => new Translation()
                {

                    Language = s.language,
                    Label = s.label
                }).ToList() : null,
                UiForms = data.ispublicForm == true ? data.publicForms.Select(s => new amorphie.workflow.core.Models.UiForm()
                {
                    StateName = data.name,
                    TypeofUiEnum = s.typeofUi,
                    Navigation = s.navigationType,
                    Forms = s.forms.Any() ? s.forms.Select(s => new Translation()
                    {

                        Language = s.language,
                        Label = s.label
                    }).ToList() : new List<Translation>() { },
                }).ToList() : new List<amorphie.workflow.core.Models.UiForm>() { },
                Transitions = data!.transitions!.Select(x => new Transition
                {
                    Name = x.name,
                    ServiceName = x.serviceName,
                    TypeofUi = x.typeofUi,
                    Flow = string.IsNullOrEmpty(x.message) ? null : context.ZeebeMessages.FirstOrDefault(f => x.message == f.Message) == null ? new ZeebeMessage()
                    {
                        Name = x.message,
                        Message = x.message,
                        Gateway = x.gateway!,
                        CreatedAt = DateTime.UtcNow,
                        Process = definition,
                    } : context.ZeebeMessages.FirstOrDefault(f => x.message == f.Message),
                    Page = x.page == null ? null : new Page()
                    {
                        Operation = x.page!.operation,
                        Type = x.page!.type,
                        Pages = x.page.pageRoute == null ? new List<Translation>() { } : new List<Translation>(){
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
                    transitionButtonType = x.buttonType,
                    Forms = x.form == null ? new List<Translation>() { } : new List<Translation>(){
                            new Translation{
                             Language=x.form!.FirstOrDefault(f=>f.typeofUi==x.typeofUi).forms.FirstOrDefault().language,
                             Label=x.form!.FirstOrDefault(f=>f.typeofUi==x.typeofUi).forms.FirstOrDefault().label
                            }
                        },
                    UiForms = x.form == null ? new List<amorphie.workflow.core.Models.UiForm>() { } : x.form.Select(s => new amorphie.workflow.core.Models.UiForm()
                    {
                        TransitionName = x.name,
                        TypeofUiEnum = s.typeofUi,
                        Navigation = s.navigationType,
                        Forms = s.forms.Any() ? s.forms.Select(s => new Translation()
                        {

                            Language = s.language,
                            Label = s.label
                        }).ToList() : new List<Translation>() { }
                    }).ToList(),
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
                Titles = data.title != null ? new List<Translation>(){
                            new Translation{
                             Language=data.title.language,
                             Label=data.title.label
                            }
                        } : new List<Translation>() { }
            };
            if(string.IsNullOrEmpty(workflowControl!.SemVer))
            {
                workflowControl.SemVer=new SemVersion(1,0,0).ToString();
            }
            
           
            await context!.States!.AddAsync(newRecord,token);
            SemVersion version= SemVersion.Parse(workflowControl.SemVer, SemVersionStyles.Any);
            version=version.WithMinor(version.Minor+1);
            workflowControl.SemVer=version.ToString();

            // TODO : Include a parameter for the cancelation token and convert SaveChanges to SaveChangesAsync with the cancelation token.
            await context.SaveChangesAsync(token);
            await versionService.SaveVersionWorkflow(workflowControl.Name,version.ToString(),token);
            //AutoMapper a alıncak 
            // return new Response<GetStateDefinition>
            // {
            //     Data=null,
            //     Result=new Result(Status.Success,"Success Create")
            // };
            return Results.Created($"workflow/definition/>{definition}/state?state-name:" + data.name, definition);
        }
        if (existingRecord != null)
        {
            var hasChanges = false;
            if (existingRecord.BaseStatus != data.baseStatus || existingRecord.Type != data.type)
            {
                hasChanges = true;
                existingRecord.BaseStatus = data.baseStatus;
                existingRecord.Type = data.type;

            }
            if (!string.IsNullOrEmpty(data.subWorkflowName) &&
            data.type == StateType.SubWorkflow &&
            existingRecord.SubWorkflowName != data.subWorkflowName)
            {
                hasChanges = true;
                existingRecord.SubWorkflowName = data.subWorkflowName;

            }
            if (data.allowedSuffix?.Length > 0)
            {
                hasChanges = true;
                existingRecord.AllowedSuffix = data.allowedSuffix;

            }
            if (data.ispublicForm != existingRecord.IsPublicForm)
            {
                hasChanges = true;
                existingRecord.IsPublicForm = data.ispublicForm;

            }
            if (!string.IsNullOrEmpty(data.initPageName) &&
            data.type == StateType.Start &&
            existingRecord.InitPageName != data.initPageName)
            {
                hasChanges = true;
                existingRecord.InitPageName = data.initPageName;

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
            if (data.mfaType != null && data.mfaType != existingRecord.MFAType)
            {
                existingRecord.MFAType = data.mfaType;
                hasChanges = true;
            }
            if (data.publicForms != null && data.publicForms.Any())
            {
                foreach (var languageForm in data.publicForms)
                {
                    // Translation? translation = existingRecord.PublicForms.FirstOrDefault(f => f.Language == languageForm.language);
                    // if (translation != null && translation.Label != languageForm.label)
                    // {
                    //     translation.Label = languageForm.label;
                    //     hasChanges = true;
                    // }
                    // else if (translation == null)
                    // {

                    //     existingRecord.PublicForms.Add(new Translation()
                    //     {
                    //         Label = languageForm.label,
                    //         Language = languageForm.language
                    //     });
                    //     existingRecord.ModifiedAt = DateTime.UtcNow;
                    //     hasChanges = true;
                    // }
                    amorphie.workflow.core.Models.UiForm? uiForm = existingRecord.UiForms.FirstOrDefault(f => languageForm.typeofUi == f.TypeofUiEnum);
                    if (uiForm == null)
                    {
                        uiForm = new amorphie.workflow.core.Models.UiForm()
                        {
                            TypeofUiEnum = languageForm.typeofUi,
                            Navigation = languageForm.navigationType,
                            StateName = existingRecord.Name,
                            Forms = languageForm.forms.Select(s => new Translation()
                            {
                                Label = s.label,
                                Language = s.language
                            }).ToList()
                        };
                        await context.UiForms.AddAsync(uiForm,token);
                        hasChanges = true;
                    }
                    if (uiForm != null)
                    {
                        if (languageForm.forms != null && languageForm.forms.Any())
                        {
                            foreach (var languagePF in languageForm.forms)
                            {
                                Translation? translation = uiForm.Forms.FirstOrDefault(f => f.Language == languagePF.language);
                                if (translation?.Label != languagePF.label)
                                {
                                    translation.Label = languagePF.label;
                                    hasChanges = true;
                                }
                                if (translation == null)
                                {

                                    uiForm.Forms.Add(new Translation()
                                    {
                                        Label = languagePF.label,
                                        Language = languagePF.language
                                    });
                                    existingRecord.ModifiedAt = DateTime.UtcNow;
                                    hasChanges = true;
                                }
                            }
                        }
                        if (uiForm.Navigation != languageForm.navigationType)
                        {
                            hasChanges = true;
                            uiForm.Navigation = languageForm.navigationType;
                        }

                    }


                }


            }
            foreach (var req in data.transitions)
            {
                Transition? existingTransition =await context.Transitions.Include(s => s.Titles).Include(s => s.Forms).Include(s => s.Flow)
                .Include(s => s.Page).ThenInclude(t => t.Pages)
                  .Include(s => s.UiForms).ThenInclude(s => s.Forms)
                .FirstOrDefaultAsync(db => db.Name == req.name && db.FromStateName == existingRecord.Name,token);
                //Kayıdı olmayan Transition ların eklenmesi
                if (existingTransition == null)
                {
                    var existingTransitionsControl = await context.Transitions!
                           .FirstOrDefaultAsync(w => req.name == w.Name,token)
                           ;
                    if (existingTransitionsControl != null)
                    {
                        return Results.Problem("There is already " + existingTransitionsControl.Name + " transition in " + existingTransitionsControl.FromStateName + " state");
                    }
                    await context!.Transitions!.AddAsync(new Transition
                    {
                        Name = req.name,
                        ToStateName = context!.States!.FirstOrDefault(f => f.Name == req.toState) != null ? req.toState : string.Empty,
                        ToState = context!.States!.FirstOrDefault(f => f.Name == req.toState),
                        ServiceName = req.serviceName,
                        FlowName = string.IsNullOrEmpty(req.message) ? null : req.message,
                        Flow = string.IsNullOrEmpty(req.message) ? null : context.ZeebeMessages.FirstOrDefault(f => req.message == f.Message) == null ? new ZeebeMessage()
                        {
                            Name = req.message,
                            Message = req.message,
                            Gateway = req.gateway!,
                            CreatedAt = DateTime.UtcNow,
                            Process = definition
                        } : context.ZeebeMessages.FirstOrDefault(f => req.message == f.Message),
                        Titles = new List<Translation>(){
                            new Translation(){
                                Label=req.title.label,
                                Language=req.title.language
                            }
                        },
                        Forms = req.form == null ? new List<Translation>() { } : new List<Translation>(){
                            new Translation(){
                      Language=req.form!.FirstOrDefault(f=>f.typeofUi==req.typeofUi).forms.FirstOrDefault().language,
                             Label=req.form!.FirstOrDefault(f=>f.typeofUi==req.typeofUi).forms.FirstOrDefault().label
                            }
                        },
                        UiForms = req.form == null ? new List<amorphie.workflow.core.Models.UiForm>() { } : req.form.Select(s => new amorphie.workflow.core.Models.UiForm()
                        {
                            TransitionName = req.name,
                            TypeofUiEnum = s.typeofUi,
                            Navigation = s.navigationType,
                            Forms = s.forms.Select(s => new Translation()
                            {

                                Language = s.language,
                                Label = s.label
                            }).ToList()
                        }).ToList(),
                        TypeofUi = req.typeofUi,
                        transitionButtonType = req.buttonType,
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
                    },token);
                    hasChanges = true;
                }
                if (existingTransition != null)
                {
                    if (existingTransition.ToStateName != req.toState)
                    {
                        existingTransition.FlowName = req.message;
                        //Kayıdı olup update edilmesi gereken transitionlar 
                        // existingTransition.FromStateName = req.fromState!;
                        existingTransition.ToState =await context!.States!.FirstOrDefaultAsync(f => f.Name == req.toState,token);
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
                    if (existingTransition.transitionButtonType != req.buttonType)
                    {
                        existingTransition.transitionButtonType = req.buttonType;
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
                            ZeebeMessage? zeebeMessage =await context!.ZeebeMessages!.FirstOrDefaultAsync(f => f.Name == req.message,token);
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
                                await context!.ZeebeMessages.AddAsync(flow,token);
                                existingTransition.FlowName = flow.Name;
                                existingTransition.Flow = flow;
                            }
                            if (zeebeMessage != null)
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
                        // Translation? translation = existingTransition.Forms.FirstOrDefault(f => f.Language == language);
                        // if (translation != null && translation.Label != req.form.label)
                        // {
                        //     translation.Label = req.form.label;
                        //     hasChanges = true;
                        // }
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
                                    Id = Guid.NewGuid(),
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
                                await context.Pages.AddAsync(pageNew,token);
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
                                Id = Guid.NewGuid(),
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
                            await context.Pages.AddAsync(pageNew,token);
                            existingTransition.Page = pageNew;
                            existingTransition.PageId = pageNew.Id;
                            hasChanges = true;
                        }
                    }
                }

            }
            if (hasChanges)
            {
                SemVersion version= SemVersion.Parse(workflowControl.SemVer, SemVersionStyles.Any);
                version=version.WithPatch(version.Patch+1);
                workflowControl.SemVer=version.ToString();
                await context!.SaveChangesAsync(token);
                 await versionService.SaveVersionWorkflow(workflowControl.Name,version.ToString(),token);
                return Results.Ok(new PostStateDefinitionResponse(data.name));
            }
            else
            {
                return Results.StatusCode(StatusCodes.Status304NotModified);
            }
        }

        return Results.NotFound();
    }
    static async ValueTask<IResult> getWorkflowHierarchy(
   [FromServices] WorkflowDBContext context,
   [FromRoute(Name = "workflowName")] string workflowName,
   CancellationToken cancellationToken
   )
    {


        var startStates = await context.States.Where(s => s.Type == StateType.Start && s.WorkflowName == workflowName)
        .Include(s => s.Transitions).ThenInclude(s => s.ToState)
        .ToListAsync(cancellationToken);
        List<HierarchyState> hierarchyStates = new List<HierarchyState>();
        List<string> AllWorkflowStates = new List<string>();
        foreach (State startState in startStates)
        {
            WorkflowStates = new List<string>();
            hierarchyStates.Add(ChangeToHyerArchy(context, startState, cancellationToken));
            AllWorkflowStates.AddRange(WorkflowStates);
        }
        var excludeStates = await context.States.Where(s => !AllWorkflowStates.Any(a => a == s.Name) && s.WorkflowName == workflowName)
        .Include(s => s.Transitions).ThenInclude(s => s.ToState)
        .ToListAsync(cancellationToken);
        foreach (State startState in excludeStates)
        {
            WorkflowStates = new List<string>();
            hierarchyStates.Add(ChangeToHyerArchy(context, startState, cancellationToken));
            AllWorkflowStates.AddRange(WorkflowStates);
        }
        return Results.Ok(hierarchyStates);
    }
    static async ValueTask<IResult> getWorkflowHierarchyV2(
   [FromServices] WorkflowDBContext context,
   [FromRoute(Name = "workflowName")] string workflowName,
   CancellationToken cancellationToken
   )
    {


        var startStates = await context.States.Where(s => s.Type == StateType.Start && s.WorkflowName == workflowName)
        .Include(s => s.Transitions).ThenInclude(s => s.ToState)
        .ToListAsync(cancellationToken);
        List<HierarchyStateNew> hierarchyStates = new List<HierarchyStateNew>();
        List<string> AllWorkflowStates = new List<string>();
        foreach (State startState in startStates)
        {
            WorkflowStates = new List<string>();
            hierarchyStates.Add(ChangeToHyerArchyV2(context, startState, cancellationToken));
            AllWorkflowStates.AddRange(WorkflowStates);
        }
        var excludeStates = await context.States.Where(s => !AllWorkflowStates.Any(a => a == s.Name) && s.WorkflowName == workflowName)
        .Include(s => s.Transitions).ThenInclude(s => s.ToState)
        .ToListAsync(cancellationToken);
        foreach (State startState in excludeStates)
        {
            WorkflowStates = new List<string>();
            hierarchyStates.Add(ChangeToHyerArchyV2(context, startState, cancellationToken));
            AllWorkflowStates.AddRange(WorkflowStates);
        }
        return Results.Ok(hierarchyStates);
    }
    private static List<string> WorkflowStates = new List<string>();
    private static HierarchyState ChangeToHyerArchy(WorkflowDBContext context, State state, CancellationToken cancellationToken)
    {
        HierarchyState hierarchyState = new HierarchyState();
        try
        {
            if (state == null)
                return null;
            List<Transition> transitions = context.Transitions.Include(s => s.ToState).Where(w => w.FromStateName == state.Name).ToList();
            WorkflowStates.Add(state.Name);

            hierarchyState.StateName = state.Name;
            hierarchyState.Transitions = new List<HierarchyTransition>();
            if (transitions.Any())
            {
                hierarchyState.Transitions = transitions.Select(s => new HierarchyTransition
                {
                    TransitionName = s.Name,
                    ToStateName = s.ToStateName,
                    ToState = string.IsNullOrEmpty(s.ToStateName) ? null : !WorkflowStates.Any(a => a == s.ToStateName) ? ChangeToHyerArchy(context, s.ToState, cancellationToken) : null
                }).ToList();
            }

        }
        catch (Exception ex)
        {

        }

        return hierarchyState;
    }

    private static HierarchyStateNew? ChangeToHyerArchyV2(WorkflowDBContext context, State state, CancellationToken cancellationToken)
    {
        HierarchyStateNew hierarchyState = new();
        if (state == null)
            return null;

        WorkflowStates.Add(state.Name);

        hierarchyState.StateName = state.Name;
        hierarchyState.Kind = state.Kind!.ToString();
        hierarchyState.ToStates = new List<HierarchyStateNew>();

        var stateRoutes = context.StateToStates.Include(s => s.ToState).Where(p => p.FromStateName == state.Name).ToList();
        foreach (var stateRoute in stateRoutes)
        {
            HierarchyStateNew? toState;
            if (string.IsNullOrEmpty(stateRoute.ToStateName))
            {
                toState = null;
            }
            else if (!WorkflowStates.Any(a => a == stateRoute.ToStateName))
            {
                toState = ChangeToHyerArchyV2(context, stateRoute.ToState, cancellationToken);
            }
            else
            {
                toState = null;
            }
            hierarchyState.ToStates.Add(toState);
        }
        return hierarchyState;
    }
}


