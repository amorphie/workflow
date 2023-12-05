
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq.Expressions;
using System.Text.Json;
using System.Text.Json.Serialization;
using amorphie.core.Base;
using amorphie.core.Enums;
using amorphie.core.Extension;
using amorphie.workflow.core.Dtos;
using amorphie.workflow.core.Enums;
using amorphie.workflow.core.Models;
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
        app.MapGet("/workflow/instance/search", getAllInstanceWithFullTextSearch)
        .Produces<GetInstanceResponse[]>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status204NoContent)
        .WithOpenApi(operation =>
        {
            operation.Summary = "Return queried workflow instance(s)";
            operation.Parameters[5].Description = "Enum :  OrderByDescending=>1,OrderBy=>0";

            operation.Tags = new List<OpenApiTag> { new() { Name = "Instance" } };

            operation.Responses["200"].Description = "One or more instances found.";
            operation.Responses["204"].Description = "No instance found.";

            return operation;
        });
        app.MapGet("/workflow/{workflowName}/init", InitInstance)
            .Produces<GetRecordWorkflowInit>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status204NoContent)
            .WithOpenApi(operation =>
            {
                operation.Summary = "Return queried workflow instance(s)";
                operation.Tags = new List<OpenApiTag> { new() { Name = "InstanceWorkflow" } };

                operation.Responses["200"].Description = "One or more instances found.";
                operation.Responses["204"].Description = "No instance found.";

                return operation;
            });
        app.MapGet("/amorphie/transition/{transitionName}/view", ViewTransition)
           .Produces<GetInstanceResponse[]>(StatusCodes.Status200OK)
           .Produces(StatusCodes.Status204NoContent)
           .WithOpenApi(operation =>
           {
               operation.Summary = "Return queried workflow instance(s)";
               operation.Tags = new List<OpenApiTag> { new() { Name = "InstanceWorkflow" } };

               operation.Responses["200"].Description = "One or more instances found.";
               operation.Responses["204"].Description = "No instance found.";

               return operation;
           });
        app.MapGet("/amorphie/state/{stateName}/view", ViewState)
        .Produces<GetInstanceResponse[]>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status204NoContent)
        .WithOpenApi(operation =>
        {
            operation.Summary = "Return queried workflow instance(s)";
            operation.Tags = new List<OpenApiTag> { new() { Name = "InstanceWorkflow" } };

            operation.Responses["200"].Description = "One or more instances found.";
            operation.Responses["204"].Description = "No instance found.";

            return operation;
        });
        app.MapPost("/amorphie/instance/{instanceId}/transition/{transitionName}", TriggerFlow)
        .Produces<GetInstanceResponse[]>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status204NoContent)
        .WithOpenApi(operation =>
        {
            operation.Summary = "Return queried workflow instance(s)";
            operation.Tags = new List<OpenApiTag> { new() { Name = "InstanceWorkflow" } };

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

        app.MapGet("/amorphie/instance/{instanceId}/transition", getTransitionByInstanceAsync
            )
            .Produces<GetInstanceResponse[]>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi(operation =>
            {
                operation.Summary = "Returns requested workflow instance";
                operation.Parameters[0].Description = "Workflow instance id.";

                operation.Tags = new List<OpenApiTag> { new() { Name = "InstanceWorkflow" } };

                operation.Responses["200"].Description = "Instances information returned.";
                operation.Responses["404"].Description = "No instance found.";
                return operation;
            });
        app.MapGet("/amorphie/instance/{instanceId}/data", getInstanceDataAsync
         )
         .Produces<GetInstanceResponse[]>(StatusCodes.Status200OK)
         .Produces(StatusCodes.Status404NotFound)
         .WithOpenApi(operation =>
         {
             operation.Summary = "Returns requested workflow instance";
             operation.Parameters[0].Description = "Workflow instance id.";

             operation.Tags = new List<OpenApiTag> { new() { Name = "InstanceWorkflow" } };

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

        // app.MapPost("/workflow/instance/{instance-id}/transaction/{transition}", (
        //     [FromRoute(Name = "instance-id")] Guid instanceId,
        //     [FromRoute(Name = "transition")] string transition,
        //     [FromBody] PostTransitionRequest data) =>
        // { })
        //     .Produces<PostTransitionResponse>(StatusCodes.Status200OK)
        //       .Produces(StatusCodes.Status404NotFound)
        //       .WithOpenApi(operation =>
        //       {
        //           operation.Summary = "Triggers transition of instance";
        //           operation.Tags = new List<OpenApiTag> { new() { Name = "Instance" } };

        //           operation.Responses["200"].Description = "Instance triggered successfully.";
        //           operation.Responses["404"].Description = "Instance or eligable transition not found.";

        //           return operation;
        //       });
    }
    static async ValueTask<IResult> InitInstance(
   [FromServices] WorkflowDBContext context,
     [FromRoute(Name = "workflowName")] string workflowName,
    CancellationToken cancellationToken

)
    {
        var query = await context.States.Where(w => w.WorkflowName == workflowName && w.Type == StateType.Start)
        .Include(s => s.Transitions).Select(s => new GetRecordWorkflowInit()
        {
            state = s.Name,
            viewSource = s.IsPublicForm == true ? "state" : "transition",
            transition = s.Transitions.Select(t => new InitTransition()
            {
                requireData = t.requireData,
                transition = t.Name,
                hasViewVariant = t.UiForms.Any() && t.UiForms.Count() > 1 ? true : false
            }).ToList(),
        }).FirstOrDefaultAsync(cancellationToken);
        if (query == null)
            return Results.NoContent();
        return Results.Ok(query);
    }
    static async ValueTask<IResult> ViewTransition(
        [FromServices] WorkflowDBContext context,
         IConfiguration configuration,
        CancellationToken cancellationToken,
        [FromRoute(Name = "transitionName")] string transitionName,

        [FromQuery] string? type,
          [FromQuery] int? json,
        [FromHeader(Name = "Accept-Language")] string language = "en-EN"
    )
    {
        try
        {

            UiForm? uiForm;
            type = type.ToLower(new CultureInfo("en-US", false));

            Transition? transition = await context.Transitions.Include(s => s.UiForms).ThenInclude(t => t.Forms).FirstOrDefaultAsync(f => f.Name == transitionName, cancellationToken);
            if (transition != null)
            {

                uiForm = transition.UiForms.FirstOrDefault(f => f.TypeofUiEnum.ToString().ToLower() == type);
                return await View(configuration, transitionName, type, typeof(Transition).ToString(), uiForm, language, json);
            }
            if (transition == null)
            {
                return Results.NotFound("Transition does not exist");
            }
            return Results.NotFound();
        }
        catch (Exception ex)
        {
            return Results.BadRequest("Unexpected error:" + ex.ToString());
        }
    }
    static async ValueTask<IResult> ViewState(
     [FromServices] WorkflowDBContext context,
      IConfiguration configuration,
     CancellationToken cancellationToken,
     [FromRoute(Name = "stateName")] string stateName,

     [FromQuery] string? type,
        [FromQuery] int? json,
     [FromHeader(Name = "Accept-Language")] string language = "en-EN"
 )
    {
        try
        {

            UiForm? uiForm;
            type = type.ToLower(new CultureInfo("en-US", false));

            State? state = await context.States.Include(s => s.UiForms).ThenInclude(t => t.Forms).FirstOrDefaultAsync(f => f.Name == stateName, cancellationToken);
            if (state != null)
            {

                uiForm = state.UiForms.FirstOrDefault(f => f.TypeofUiEnum.ToString().ToLower() == type);
                return await View(configuration, stateName, type, typeof(State).ToString(), uiForm, language, json);
            }
            if (state == null)
            {
                return Results.NotFound("State does not exist");
            }
            return Results.NotFound();
        }
        catch (Exception ex)
        {
            return Results.BadRequest("Unexpected error:" + ex.ToString());
        }
    }

    private static async ValueTask<IResult> View(IConfiguration configuration,
        string name, string type, string typeofTable, UiForm? uiForm, string? language, int? json)
    {
        try
        {
            if (json == null)
                json = amorphie.workflow.core.Enums.JsonEnum.Json.GetHashCode();
            if (uiForm == null)
            {
                return Results.NotFound(typeofTable + " does not have " + type + " type");
            }
            Translation? form = uiForm.Forms.FirstOrDefault(f => f.Language == language);
            if (form == null)
            {
                return Results.NotFound(name + " " + typeofTable + ", type " + type + " does not exist " + language + " body. Check the Accept-Language header.");
            }
            var templateURL = configuration["templateEngineUrl"]!.ToString();

            return Results.Ok(new ViewTransitionModel()
            {
                name = form.Label,
                type = uiForm.TypeofUiEnum.ToString(),
                language = form.Language,
                navigation = uiForm.Navigation.ToString(),
                data = "latest",
                body = string.Equals(type, TypeofUiEnum.PageUrl.ToString(), StringComparison.OrdinalIgnoreCase) ? form.Label
                : amorphie.workflow.core.Helper.TemplateEngineHelper.TemplateEngineForm(form.Label, string.Empty, templateURL, string.Empty, json)
            });

        }
        catch (Exception ex)
        {
            return Results.BadRequest("Unexpected error:" + ex.ToString());
        }
    }
    static async ValueTask<amorphie.core.IBase.IResponse> TriggerFlow(
  [FromServices] WorkflowDBContext context,
  IConfiguration configuration,
  CancellationToken cancellationToken,
  [FromServices] IPostTransactionService service,
  [FromRoute(Name = "transitionName")] string transitionName,
  [FromRoute(Name = "instanceId")] Guid instanceId,
  HttpRequest request,
    [FromBody] dynamic body,
  [FromHeader(Name = "User")] Guid user,
  [FromHeader(Name = "Behalf-Of-User")] Guid behalOfUser,
  [FromHeader(Name = "Accept-Language")] string language = "en-EN"
)
    {

        var result = await service.InitWithoutEntity(instanceId, transitionName, user, behalOfUser, body, request.Headers, cancellationToken);
        if (result.Result.Status == Status.Success.ToString())
        {
            result = await service.ExecuteWithoutEntity();
        }

        return result;

    }
    static IResult getAllInstance(
        [FromServices] WorkflowDBContext context,
        [FromQuery] string? entity,
         [FromQuery] string? workflowName,
         [FromQuery] Guid? recordId,
          [FromQuery] GetInstanceStatusType? status,
           [FromQuery][Range(0, 100)] int? page = 0,
        [FromQuery][Range(5, 100)] int? pageSize = 10,
         [FromHeader(Name = "Language")] string? language = "en-EN"
    )
    {
        // TODO : Include a parameter for the cancelation token and convert all ToList objects to ToListAsync with the cancelation token.
        var query = context.Instances!
   .Where(w => (string.IsNullOrEmpty(entity) || w.EntityName == entity) && (!recordId.HasValue || w.RecordId == recordId) &&
   (string.IsNullOrEmpty(workflowName) || w.WorkflowName == workflowName)).Include(s => s.State).ThenInclude(s => s.Titles)
   .Include(s => s.State).ThenInclude(s => s.Transitions).ThenInclude(t => t.Forms)
    .Include(s => s.State).ThenInclude(s => s.Transitions).ThenInclude(t => t.Forms)
    .Include(s => s.State).ThenInclude(s => s.Transitions).ThenInclude(t => t.UiForms).ThenInclude(t => t.Forms)
   .Include(s => s.State).ThenInclude(s => s.Transitions).ThenInclude(t => t.Titles)
   .Include(s => s.State).ThenInclude(s => s.Transitions).ThenInclude(t => t.HistoryForms)
   .Include(s => s.State).ThenInclude(s => s.Transitions).ThenInclude(t => t.Page).ThenInclude(t => t.Pages)
   ;

        var instances = query.Skip(page.GetValueOrDefault(0) * pageSize.GetValueOrDefault(10))
         .Take(pageSize.GetValueOrDefault(10)).OrderBy(o => o.CreatedAt)
         .ToList();
        return Results.Ok(
                instances.Select(s => new GetInstanceResponse(
                   s.EntityName,
                   s.RecordId.ToString(),
                   s.Id,
                   s.WorkflowName,
                   new GetStateDefinition(s.StateName, new amorphie.workflow.core.Dtos.MultilanguageText(
                    language!, s.State.Titles.FirstOrDefault(f => f.Language == language)!.Label
                    ),
                    s.State.BaseStatus,
                    s.State.Transitions.Select(t => new PostTransitionDefinitionRequest(
                        t.Name,
                        new amorphie.workflow.core.Dtos.MultilanguageText(
                            language!, t.Titles.FirstOrDefault(f => f.Language == language)!.Label),
                        t.ToStateName!,
                        t.UiForms.Any() ? null : t.UiForms.Select(st => new amorphie.workflow.core.Dtos.UiFormDto()
                        {
                            typeofUi = st.TypeofUiEnum,
                            navigationType = st.Navigation,
                            forms = st.Forms.Select(sf => new amorphie.workflow.core.Dtos.MultilanguageText(
                            sf.Language, sf.Label)).ToArray()
                        }).ToArray(),
                        t.FromStateName,
                        t.ServiceName,
                        t.FlowName,
                        null,
                        t.Page == null ? null :
                       new PostPageDefinitionRequest(t.Page.Operation, t.Page.Type, t.Page.Pages == null || t.Page.Pages.Count == 0 ? null : new amorphie.workflow.core.Dtos.MultilanguageText(language!, t.Page.Pages!.FirstOrDefault(f => f.Language == language)!.Label), t.Page.Timeout)
                       , t.HistoryForms.Any() ? t.HistoryForms.Select(s => new amorphie.workflow.core.Dtos.MultilanguageText(s.Language, s.Label)).ToArray() : null
                       , t.TypeofUi, t.transitionButtonType
                    )).ToArray()
                    ),
                   s.CreatedAt,
                   DateTime.Now//Buradaki değer ne olacak?

                    )
                ).ToArray());
    }
    static async ValueTask<IResult> getAllInstanceWithFullTextSearch(
              [FromServices] WorkflowDBContext context,
              [AsParameters] InstanceSearch instanceSearch,
      CancellationToken cancellationToken
              )
    {
        Guid guid;
        bool isGuidSearch = false;
        try
        {

            isGuidSearch = Guid.TryParse(instanceSearch.Keyword, out guid);

        }
        catch (Exception)
        {
            guid = Guid.NewGuid();
            isGuidSearch = false;
        }
        var query = context!.Instances!.Where(w => !isGuidSearch || (isGuidSearch && (guid == w.Id || guid == w.RecordId)))
          .Include(s => s.State).ThenInclude(s => s.Titles)
   .Include(s => s.State).ThenInclude(s => s.Transitions).ThenInclude(t => t.Forms)
    .Include(s => s.State).ThenInclude(s => s.Transitions).ThenInclude(t => t.Forms)
    .Include(s => s.State).ThenInclude(s => s.Transitions).ThenInclude(t => t.UiForms).ThenInclude(t => t.Forms)
   .Include(s => s.State).ThenInclude(s => s.Transitions).ThenInclude(t => t.Titles)
   .Include(s => s.State).ThenInclude(s => s.Transitions).ThenInclude(t => t.HistoryForms)
   .Include(s => s.State).ThenInclude(s => s.Transitions).ThenInclude(t => t.Page).ThenInclude(t => t.Pages).AsQueryable()
            ;

        if (!string.IsNullOrEmpty(instanceSearch.Keyword))
        {
            query = query.AsNoTracking().Where(p => p.SearchVector.Matches(EF.Functions.PlainToTsQuery("english", instanceSearch.Keyword)));
        }
        query = await query.Sort<Instance>(instanceSearch.SortColumn, instanceSearch.SortDirection);
        // if (!string.IsNullOrEmpty(instanceSearch.SortColumn))
        // {
        //         var queryExpr = query.Expression;
        //         var parameter=Expression.Parameter(typeof(Instance),"p");
        //         var property=typeof(Instance).GetProperties().FirstOrDefault(p => string.Equals(p.Name, instanceSearch.SortColumn, StringComparison.OrdinalIgnoreCase));
        //         if(property==null)
        //         {
        //             return  Results.NotFound("Property:"+instanceSearch.SortColumn+" not found");
        //         }
        //         var propertyAccess=Expression.MakeMemberAccess(parameter,property);
        //         var expression=Expression.Lambda(propertyAccess,parameter);
        //         queryExpr = Expression.Call(typeof(Queryable), instanceSearch.SortColumnType.ToString(), new Type[] { typeof(Instance), property.PropertyType}, queryExpr, Expression.Quote(expression));
        //         query=query.Provider.CreateQuery<Instance>(queryExpr); 

        // }
        var instances = query.Skip(instanceSearch.Page * instanceSearch.PageSize)
            .Take(instanceSearch.PageSize);

        if (await instances.CountAsync(cancellationToken) > 0)
        {
            var response = instances.Select(s => new GetInstanceResponse(
                   s.EntityName,
                   s.RecordId.ToString(),
                   s.Id,
                   s.WorkflowName,
                   new GetStateDefinition(s.StateName, new amorphie.workflow.core.Dtos.MultilanguageText(
                    s.State.Titles.FirstOrDefault()!.Language!, s.State.Titles.FirstOrDefault()!.Label
                    ),
                    s.State.BaseStatus,
                    s.State.Transitions.Select(t => new PostTransitionDefinitionRequest(
                        t.Name,
                        new amorphie.workflow.core.Dtos.MultilanguageText(
                            t.Titles.FirstOrDefault()!.Language!, t.Titles.FirstOrDefault()!.Label),
                        t.ToStateName!,
                        t.UiForms.Any() ? null : t.UiForms.Select(st => new amorphie.workflow.core.Dtos.UiFormDto()
                        {
                            typeofUi = st.TypeofUiEnum,
                            navigationType = st.Navigation,
                            forms = st.Forms.Select(sf => new amorphie.workflow.core.Dtos.MultilanguageText(
                            sf.Language, sf.Label)).ToArray()
                        }).ToArray(),
                        t.FromStateName,
                        t.ServiceName,
                        t.FlowName,
                        null,
                        t.Page == null ? null :
                       new PostPageDefinitionRequest(t.Page.Operation, t.Page.Type, t.Page.Pages.Any() ? null : t.Page.Pages!.Select(s => new amorphie.workflow.core.Dtos.MultilanguageText(s.Language, s.Label)).FirstOrDefault(), t.Page.Timeout)
                       , t.HistoryForms.Any() ? t.HistoryForms.Select(s => new amorphie.workflow.core.Dtos.MultilanguageText(s.Language, s.Label)).ToArray() : null
                       , t.TypeofUi, t.transitionButtonType
                    )).ToArray()
                    ),
                   s.CreatedAt,
                   DateTime.Now//Buradaki değer ne olacak?

                    )
                ).ToArray();


            return Results.Ok(response);
        }

        return Results.NoContent();
    }

    static async Task<IResult> getInstance(
          [FromServices] WorkflowDBContext context,
          [FromRoute(Name = "instance-id")] Guid instanceId,
          CancellationToken cancellationToken,
             [FromHeader(Name = "Language")] string? language = "en-EN"
      )
    {
        var instance = await context.Instances!
   .FirstOrDefaultAsync(w => w.Id == instanceId, cancellationToken)
   ;
        if (instance == null)
        {
            return Results.NotFound();
        }
        if (instance != null)
        {
            return Results.Ok(
                          new GetInstanceResponse(
                             instance!.EntityName,
                             instance!.RecordId.ToString(),
                             instance.Id,
                             instance.WorkflowName,
                             new GetStateDefinition(instance.StateName, new amorphie.workflow.core.Dtos.MultilanguageText(
                              language!, instance.State.Titles.FirstOrDefault(f => f.Language == language)!.Label
                              ),
                              instance.State.BaseStatus,
                              instance.State.Transitions.Select(t => new PostTransitionDefinitionRequest(
                                  t.Name,
                                  new amorphie.workflow.core.Dtos.MultilanguageText(
                                      language!, t.Titles.FirstOrDefault(f => f.Language == language)!.Label),
                                  t.ToStateName!,
                                    t.UiForms.Any() ? null : t.UiForms.Select(st => new amorphie.workflow.core.Dtos.UiFormDto()
                                    {
                                        typeofUi = st.TypeofUiEnum,
                                        navigationType = st.Navigation,
                                        forms = st.Forms.Select(sf => new amorphie.workflow.core.Dtos.MultilanguageText(
                                        sf.Language, sf.Label)).ToArray()
                                    }).ToArray(),
                                  t.FromStateName,
                                  t.ServiceName,
                                  t.FlowName,
                                  null,
                                 t.Page == null ? null :
                       new PostPageDefinitionRequest(t.Page.Operation, t.Page.Type, t.Page.Pages == null || t.Page.Pages.Count == 0 ? null : new amorphie.workflow.core.Dtos.MultilanguageText(language!, t.Page.Pages!.FirstOrDefault(f => f.Language == language)!.Label), t.Page.Timeout)
                              , t.HistoryForms.Any() ? t.HistoryForms.Select(s => new amorphie.workflow.core.Dtos.MultilanguageText(s.Language, s.Label)).ToArray() : null
                              , t.TypeofUi, t.transitionButtonType
                              )).ToArray()
                              ),
                             instance.CreatedAt,
                             DateTime.Now//Buradaki değer ne olacak?

                              )
                          );
        }
        return Results.NotFound();

    }
    static async Task<IResult> getTransitionByInstanceAsync(
      [FromServices] WorkflowDBContext context,
      [FromRoute(Name = "instanceId")] Guid instanceId,
      CancellationToken cancellationToken,
         [FromHeader(Name = "Accept-Language")] string? language = "en-EN"
  )
    {
        var instance = await context.Instances!.Include(s => s.State).ThenInclude(s => s.Transitions).ThenInclude(s => s.UiForms)
   .FirstOrDefaultAsync(w => w.Id == instanceId, cancellationToken)
   ;
        if (instance == null)
        {
            return Results.NotFound();
        }
        if (instance != null)
        {
            return Results.Ok(
                          new InstanceStateTransitions()
                          {
                              state = instance.StateName,
                              baseState = instance.BaseStatus.ToString(),
                              viewSource = instance.State.IsPublicForm == true ? "state" : "transition",
                              transition = instance.State.Transitions.Select(t => new InitTransition()
                              {
                                  requireData = t.requireData,
                                  transition = t.Name,
                                  type = t.transitionButtonType.GetValueOrDefault(TransitionButtonType.Forward).ToString(),
                                  hasViewVariant = t.UiForms.Any() && t.UiForms.Count() > 1 ? true : false
                              }).ToList()

                          }
                          );
        }
        return Results.NotFound();

    }
    static async Task<IResult> getInstanceDataAsync(
      [FromServices] WorkflowDBContext context,
      [FromRoute(Name = "instanceId")] Guid instanceId,
      CancellationToken cancellationToken,
       [FromQuery] bool? latest,
       [FromQuery(Name = "latest-payload")] bool? latestPayload,
       [FromQuery(Name = "first-payload")] bool? firstPayload,
         [FromQuery] string? transitionName,
         [FromHeader(Name = "Accept-Language")] string? language = "en-EN"

  )
    {
        var instance = await context.Instances!.Include(s => s.State).ThenInclude(s => s.Transitions)
   .FirstOrDefaultAsync(w => w.Id == instanceId, cancellationToken)
   ;
        InstanceTransition? instanceTransition;
        if (instance == null)
        {
            return Results.NotFound("Instance:" + instanceId + " not found");
        }

        if (latest == null && latestPayload == null & firstPayload == null && string.IsNullOrEmpty(transitionName))
        {
            latest = true;
        }
        if (latest.GetValueOrDefault(false))
        {
            instanceTransition = await context.InstanceTransitions.Where(w => w.InstanceId == instanceId).OrderByDescending(c => c.CreatedAt)
            .FirstOrDefaultAsync(cancellationToken);
            if (instanceTransition == null)
            {
                return Results.NotFound("Instance does not have a transition");
            }
            try
            {
                return Results.Ok(System.Text.Json.JsonSerializer.Deserialize<dynamic>(instanceTransition.EntityData));
            }
            catch (Exception ex)
            {

            }
            return Results.Ok(instanceTransition.EntityData);
        }
        if (latestPayload.GetValueOrDefault(false))
        {
            try
            {
                instanceTransition = await context.InstanceTransitions.Where(w => w.InstanceId == instanceId).OrderBy(c => c.CreatedAt).Reverse()
                .Skip(1).FirstOrDefaultAsync(cancellationToken);
                if (instanceTransition == null)
                {
                    return Results.NotFound("Instance does not have last transition");
                }
                var serializeResponse = System.Text.Json.JsonSerializer.Deserialize<dynamic>(instanceTransition.EntityData);
                if (serializeResponse != null)
                    return Results.Ok(serializeResponse);
                if (serializeResponse == null)
                {
                    //if data can not deserialize return entitydata without deserialize
                    return Results.Ok(instanceTransition.EntityData);
                }
            }
            catch (Exception ex)
            {
                return Results.Problem("Try latest instead of latest-payload");
            }
        }
        if (firstPayload.GetValueOrDefault(false))
        {
            try
            {
                instanceTransition = await context.InstanceTransitions.Where(w => w.InstanceId == instanceId).OrderBy(c => c.CreatedAt)
                .FirstOrDefaultAsync(cancellationToken);
                if (instanceTransition == null)
                {
                    return Results.NotFound("Instance does not have a transition");
                }
                var serializeResponse = System.Text.Json.JsonSerializer.Deserialize<dynamic>(instanceTransition.EntityData);
                if (serializeResponse != null)
                    return Results.Ok(serializeResponse);
                if (serializeResponse == null)
                {
                    //if data can not deserialize return entitydata without deserialize
                    return Results.Ok(instanceTransition.EntityData);
                }
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.ToString());
            }
        }
        if (!string.IsNullOrEmpty(transitionName))
        {
            try
            {
                instanceTransition = await context.InstanceTransitions.Where(w => w.InstanceId == instanceId && transitionName == w.TransitionName)
                .FirstOrDefaultAsync(cancellationToken);
                if (instanceTransition == null)
                {
                    return Results.NotFound("Transition " + transitionName + " is not found");
                }
                var serializeResponse = System.Text.Json.JsonSerializer.Deserialize<dynamic>(instanceTransition.EntityData);
                if (serializeResponse != null)
                    return Results.Ok(serializeResponse);
                if (serializeResponse == null)
                {
                    //if data can not deserialize return entitydata without deserialize
                    return Results.Ok(instanceTransition.EntityData);
                }
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.ToString());
            }
        }
        return Results.Problem("Try latest,latest-payload or first-payload");


    }
    static IResult getInstanceTransactions(
       [FromServices] WorkflowDBContext context,
      [FromRoute(Name = "instance-id")] Guid instanceId,
            [FromQuery] int page,
            [FromQuery] int pageSize,
          [FromHeader(Name = "Language")] string? language = "en-EN"
   )
    {
        // TODO : Include a parameter for the cancelation token and convert all ToList objects to ToListAsync with the cancelation token.
        var query = context.InstanceTransitions!.Include(i => i.Instance)
   .Where(w => w.InstanceId == instanceId);
        var instances = query.Skip(page * pageSize)
              .Take(pageSize)
              .ToList();
        return Results.Ok(instances.Select(it => new GetInstanceTransitionHistoryResponse(
it.Id,
it.FromStateName,
it.ToStateName,
context!.Transitions.FirstOrDefault(f => f.ToStateName == it.ToStateName && f.FromStateName == it.ToStateName)!.Name,
it.EntityData,
it.FormData!,
it.CreatedAt,
context!.InstanceEvents.Where(w => w.InstanceTransitionId == it.Id).Select(s => new GetInstanceEventHistoryResponse(
        s.Id,
        s.Id.ToString(),
        new Dictionary<string, string>(),
        s.InputData.Split(';', System.StringSplitOptions.None)
        .Select(part => part.Split('=', System.StringSplitOptions.None))
        .Where(part => part.Length == 2)
        .ToDictionary(sp => sp[0], sp => sp[1]),
        s.OutputData.Split(';', System.StringSplitOptions.None)
        .Select(part => part.Split('=', System.StringSplitOptions.None))
        .Where(part => part.Length == 2)
        .ToDictionary(sp => sp[0], sp => sp[1]),
        s.CreatedAt
    )).ToArray()
        )).ToArray());
    }
}

