
using System.ComponentModel.DataAnnotations;
using System.Linq;
using amorphie.core.Base;
using amorphie.core.Enums;
using amorphie.core.IBase;
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
    )).ToArray()
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
    static IResponse deleteDefinition(
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
                 .FirstOrDefault(w => w.Name == definition);

            if (existingRecord != null)
            {
                context!.Remove(existingRecord);
                context.SaveChanges();
                return new Response
                {
                    Result = new Result(Status.Success, "Successfully Delete " + definition + " workflow"),
                };
                // return Results.Ok();
            }
            else
            {
                return new Response
                {
                    Result = new Result(Status.Error, "No Content"),
                };
            }
        }
        catch (Exception ex)
        {
            return new Response
            {
                Result = new Result(Status.Error, ex.ToString()),
            };
        }


    }
    static IResponse<PostWorkflowDefinitionResponse> saveDefinition(
      [FromServices] WorkflowDBContext context,
      [FromBody] PostWorkflowDefinitionRequest data,
      [FromHeader(Name = "Language")] string? language = "en-EN"
      )
    {
        var existingRecord = context.Workflows!.Include(s => s.Entities).FirstOrDefault(w => w.Name == data.name);
        List<WorkflowEntity> entityList = new List<WorkflowEntity>();
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
                CreatedAt = DateTime.Now,
                CreatedByBehalfOf = Guid.NewGuid(),
            };
            context!.Workflows!.Add(newWorkflow);
            context.SaveChanges();
            return new Response<PostWorkflowDefinitionResponse>
            {
                Result = new Result(Status.Success, "Success Create"),
                Data = new PostWorkflowDefinitionResponse(newWorkflow.Name),
            };
        }
        else
        {
            var hasChanges = false;
            if (existingRecord.Tags != data.tags || existingRecord.WorkflowStatus != data.status)
            {
                hasChanges = true;
                existingRecord.ModifiedAt = DateTime.Now;
                existingRecord.Tags = data.tags;
                existingRecord.WorkflowStatus = data.status;
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
                return new Response<PostWorkflowDefinitionResponse>
                {
                    Result = new Result(Status.Success, "Success Update"),
                    Data = new PostWorkflowDefinitionResponse(existingRecord.Name),
                };
                // return Results.Ok(new PostWorkflowDefinitionResponse(data.name));
            }
            else
            {
                return new Response<PostWorkflowDefinitionResponse>
                {
                    Result = new Result(Status.Error, "Not Modiefied"),
                };
            }
        }
    }
    static IResponse<IQueryable<GetStateDefinition>> getState(
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
        .Take(pageSize.GetValueOrDefault(10)).Select(s => new GetStateDefinition(
            s.Name,
            s.Titles.Where(s => s.Language == language).Select(s => new MultilanguageText(s.Language, s.Label)).First(),
            s.BaseStatus!,
            s.Transitions.Select(e => new PostTransitionDefinitionRequest(
     e.Name, e.Titles.Where(s => s.Language == language).Select(s => new MultilanguageText(s.Language, s.Label)).First(),
     e.ToStateName!, e.Forms.Where(s => s.Language == language).Select(s => new MultilanguageText(s.Language, s.Label)).FirstOrDefault(),
     e.FromStateName!, e.ServiceName, e.FlowName, e.Flow != null ? e.Flow.Gateway : null,e.Page==null?null:new PostPageDefinitionRequest(e.Page.Operation,e.Page.Type,new MultilanguageText(language!,e.Page.Pages!.FirstOrDefault(f=>f.Language==language)!.Label),e.Page.Timeout)

)).ToArray()
            ))
//    .ToList();
;
        return new Response<IQueryable<GetStateDefinition>>
        {
            Data = states,
            Result = new Result(Status.Success, "Success")
        };
        //return Results.Ok(states);
    }
    static IResponse deleteState(
            [FromServices] WorkflowDBContext context,
            [FromRoute(Name = "name")] string definition,
              [FromRoute(Name = "state-name")] string state,
               [FromHeader(Name = "Language")] string? language = "en-EN"
        )
    {
        var existingRecord = context.States!.Include(w => w.Titles)
        .Include(w => w.Transitions).ThenInclude(s=>s.Titles)
        .Include(w => w.Transitions).ThenInclude(s=>s.Forms)
       .FirstOrDefault(w => w.WorkflowName == definition && w.Name == state)
       ;

        if (existingRecord != null)
        {
            context!.Remove(existingRecord);
            context.SaveChanges();
            return new Response
            {
                Result = new Result(Status.Success, "Success"),
            };
        }
        else
        {
            return new Response
            {
                Result = new Result(Status.Error, "No Content"),
            };
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
        var existingRecord = context.States!.Include(s => s.Titles).Include(s => s.Transitions)
               .FirstOrDefault(w => w.WorkflowName == definition && w.Name == data.name)
               ;
        if (existingRecord == null)
        {
            State newRecord = new State
            {
                WorkflowName = definition,
                Name = data.name,
                BaseStatus = data.baseStatus,
                CreatedAt = DateTime.Now,
                CreatedByBehalfOf = Guid.NewGuid(),
                Type = data.type,
                Transitions = data!.transitions!.Select(x => new Transition
                {
                    Name = x.name,
                    ServiceName = x.serviceName,
                    Flow = x.message == null ? null : new ZeebeMessage()
                    {
                        Name = x.message,
                        Message = x.message,
                        Gateway = x.gateway!,
                        CreatedAt = DateTime.Now,
                        Process = definition,
                    },
                    Page=x.page==null?null:new Page(){
                        Operation=x.page!.operation,
                        Type=x.page!.type,
                        Pages=new List<Translation>(){
                            new Translation{
                             Language=x.page.pages.language,
                             Label=x.page.pages.label
                            }
                        },
                        Timeout=x.page!.timeout

                    },
                    Titles = new List<Translation>(){
                            new Translation{
                             Language=x.title.language,
                             Label=x.title.label
                            }
                        },
                    Forms = x.form==null?new List<Translation>(){}:new List<Translation>(){
                            new Translation{
                             Language=x.form!.language,
                             Label=x.form!.label
                            }
                        },
                    ToState = context!.States!.FirstOrDefault(f => f.Name == x.toState),
                    ToStateName = context!.States!.FirstOrDefault(f => f.Name == x.toState) != null ? x.toState : null,
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
            };
            context!.States!.Add(newRecord);
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
            foreach (var req in data.transitions)
            {
                Transition? existingTransition = context.Transitions.Include(s => s.Titles).Include(s => s.Forms).Include(s => s.Flow)
                .Include(s => s.Page).ThenInclude(t=>t.Pages)
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
                        Forms =req.form==null?new List<Translation>(){}: new List<Translation>(){
                            new Translation(){
                                Label=req.form!.label,
                                Language=req.form!.language
                            }
                        },
                        Page=req.page==null?null:new Page(){
                        Operation=req.page!.operation,
                        Type=req.page!.type,
                        Pages=new List<Translation>(){
                            new Translation{
                             Language=req.page.pages.language,
                             Label=req.page.pages.label
                            }
                        },
                        Timeout=req.page!.timeout

                    },
                        FromStateName=req.fromState,
                        CreatedAt = DateTime.Now,
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
                                    CreatedAt = DateTime.Now,
                                    Message = req.message!,
                                    Process = definition,
                                };
                                context!.ZeebeMessages.Add(flow);
                                existingTransition.FlowName=flow.Name;
                                existingTransition.Flow=flow;
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
                    if (req.form != null)
                    {
                        Translation? translation = existingTransition.Forms.FirstOrDefault(f => f.Language == language);
                        if (translation != null && translation.Label != req.form.label)
                        {
                            translation.Label = req.form.label;
                            hasChanges = true;
                        }
                    }

                       if (req!.page!=null)
                    {
                        Page? page = existingTransition.Page;
                        if (page != null )
                        {
                          if(page.Operation!=req.page.operation)
                          {
                            existingTransition.Page!.Operation=req.page.operation;
                             hasChanges = true;
                          }
                          if(page.Type!=req.page.type)
                          {
                            existingTransition.Page!.Type=req.page.type;
                             hasChanges = true;
                          }
                           if(page.Timeout!=req.page.timeout)
                          {
                            existingTransition.Page!.Timeout=req.page.timeout;
                             hasChanges = true;
                          }
                          Translation? translation = existingTransition.Page!.Pages!.FirstOrDefault(f => f.Language == language);
                          if (translation != null && translation.Label != req.page.pages.label)
                        {
                            translation.Label = req.page.pages.label;
                            hasChanges = true;
                        }

                        }
                        else{
                            existingTransition.Page=new Page(){
                                Operation=req.page!.operation,
                        Type=req.page!.type,
                        Pages=new List<Translation>(){
                            new Translation{
                             Language=req.page.pages.language,
                             Label=req.page.pages.label
                            }
                        },
                        Timeout=req.page!.timeout
                            };
                        }
                    }
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


