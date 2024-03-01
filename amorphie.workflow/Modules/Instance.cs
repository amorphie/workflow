
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
        app.MapGet("/workflow/instance/get", getAllInstance)
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
        app.MapGet("/workflow/instance/workflow/{workflowName}/init", InitInstance)
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
        app.MapGet("/workflow/instance/transition/{transitionName}/view", ViewTransition)
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
        app.MapGet("/workflow/instance/state/{stateName}/view", ViewState)
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
        app.MapGet("/workflow/instance/page/{pageName}/view", ViewPage)
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
        app.MapPost("/workflow/instance/{instanceId}/transition/{transitionName}", TriggerFlow)
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

        app.MapGet("/workflow/uiform/updatedb", UiFormFill
      )
      .Produces<GetInstanceResponse[]>(StatusCodes.Status200OK)
      .Produces(StatusCodes.Status404NotFound)
      .WithOpenApi(operation =>
      {


          operation.Tags = new List<OpenApiTag> { new() { Name = "UiForm" } };

          return operation;
      });

        app.MapGet("/workflow/instance/{instanceId}/transition", getTransitionByInstanceAsync
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
        app.MapGet("/workflow/instance/{instanceId}/data", getInstanceDataAsync
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
        app.MapGet("/workflow/instance/{instanceId}/history", getHistoryByInstanceAsync
    )
    .Produces<SignalRResponsePublic[]>(StatusCodes.Status200OK)
    .Produces(StatusCodes.Status404NotFound)
    .WithOpenApi(operation =>
    {
        operation.Summary = "Returns requested workflow instance history";
        operation.Parameters[0].Description = "Workflow instance id.";

        operation.Tags = new List<OpenApiTag> { new() { Name = "InstanceWorkflow" } };

        operation.Responses["200"].Description = "Instances history information returned.";
        operation.Responses["404"].Description = "No instance found.";
        return operation;
    });

    }
    static async Task<IResult> UiFormFill(
       [FromServices] WorkflowDBContext dbContext,
        CancellationToken cancellationToken
 )
    {
        bool change = false;
        var transitions = await dbContext.Transitions.Where(s => !s.UiForms.Any()).Include(s => s.Page).Include(s => s.Forms).Include(s => s.UiForms).ThenInclude(t => t.Forms).ToListAsync(cancellationToken);
        if (transitions.Any())
        {
            foreach (Transition transition in transitions)
            {
                if (!transition.UiForms.Any() && transition.Forms.Any())
                {
                    change = true;
                    UiForm uiFormAdd = new UiForm()
                    {
                        TypeofUiEnum = transition.TypeofUi != null ? transition.TypeofUi : TypeofUiEnum.Formio,
                        Forms = transition.Forms.Select(s => new Translation()
                        {
                            Language = s.Language,
                            Label = s.Label
                        }).ToList(),
                        TransitionName = transition.Name,
                        Navigation = transition.Page == null ? NavigationType.PushReplacement : transition.Page.Type == PageType.Popup ? NavigationType.PopUp : NavigationType.PushReplacement,
                        Id = Guid.NewGuid()
                    };
                    dbContext.UiForms.Add(uiFormAdd);

                }
            }
        }

        var states = await dbContext.States.Where(s => s.IsPublicForm == true && !s.UiForms.Any()).Include(s => s.PublicForms).Include(s => s.UiForms).ThenInclude(t => t.Forms).ToListAsync(cancellationToken);
        if (states.Any())
        {
            foreach (State state in states)
            {
                if (!state.UiForms.Any() && state.PublicForms.Any())
                {
                    change = true;
                    UiForm uiFormAdd = new UiForm()
                    {
                        TypeofUiEnum = TypeofUiEnum.FlutterWidget,
                        Forms = state.PublicForms.Select(s => new Translation()
                        {
                            Language = s.Language,
                            Label = s.Label
                        }).ToList(),
                        StateName = state.Name,
                        Navigation = NavigationType.PushReplacement,
                        Id = Guid.NewGuid()
                    };
                    dbContext.UiForms.Add(uiFormAdd);

                }
            }
        }

        if (change)
            dbContext.SaveChanges();
        return Results.Ok();
    }
    static async ValueTask<IResult> InitInstance(
   [FromServices] WorkflowDBContext context,
     [FromRoute(Name = "workflowName")] string workflowName,
     [FromQuery(Name = "suffix")] string? suffix,
    CancellationToken cancellationToken

)
    {
        var query = await context.States.Where(w => w.WorkflowName == workflowName && w.Type == StateType.Start)
        .Include(s => s.Transitions).Select(s => new GetRecordWorkflowInit()
        {
            state = s.Name,
            viewSource = s.IsPublicForm == true ? "state" : "transition",
            initPageName = s.InitPageName,
            transition = s.Transitions.Select(t => new InitTransition()
            {
                type = t.transitionButtonType.GetValueOrDefault(TransitionButtonType.Forward).ToString(),
                requireData = t.requireData,
                transition = t.Name,

                hasViewVariant = t.UiForms.Any() && t.UiForms.Count() > 1 ? true : false
            }).ToList(),
        }).FirstOrDefaultAsync(cancellationToken);
        if (query == null)
            return Results.NoContent();
        if (!string.IsNullOrEmpty(query.initPageName) && !string.IsNullOrEmpty(suffix))
        {
            query.initPageName += "-" + suffix;
        }
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
                return await View(configuration, transitionName, type, typeof(Transition).ToString(), uiForm, language, json, string.Empty);
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
                return await View(configuration, stateName, type, typeof(State).ToString(), uiForm, language, json, string.Empty);
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
    static async ValueTask<IResult> ViewPage(
 [FromServices] WorkflowDBContext context,
  IConfiguration configuration,
 CancellationToken cancellationToken,
 [FromRoute(Name = "pageName")] string pageName,

 [FromQuery] string? type,
    [FromQuery] int? json,
    [FromHeader(Name = "InstanceId")] string instanceId,
 [FromHeader(Name = "Accept-Language")] string language = "en-EN"
)
    {
        try
        {
            string navigation = string.Empty;
            var pageControl = await context.SignalRResponses.Where(w => w.InstanceId == instanceId && pageName == w.pageUrl).FirstOrDefaultAsync(cancellationToken);
            if (pageControl == null)
                navigation = amorphie.workflow.core.Helper.EnumHelper.GetDescription<NavigationType>(NavigationType.PushReplacement);
            // return Results.BadRequest("There is no " + pageName + " page for " + instanceId);
            if (pageControl != null)
                navigation = pageControl.navigationType;
            return await View(configuration, pageName, type, typeof(Page).ToString(), null, language, json, navigation);

        }
        catch (Exception ex)
        {
            return Results.BadRequest("Unexpected error:" + ex.ToString());
        }
    }
    private static async ValueTask<IResult> View(IConfiguration configuration,
        string name, string type, string typeofTable, UiForm? uiForm, string? language, int? json, string navigation)
    {
        try
        {
            Translation? form = new Translation();
            if (json == null)
                json = amorphie.workflow.core.Enums.JsonEnum.Json.GetHashCode();
            if (typeofTable != typeof(Page).ToString())
            {
                if (uiForm == null)
                {
                    return Results.NotFound(typeofTable + " does not have " + type + " type");
                }
                form = uiForm.Forms.FirstOrDefault(f => f.Language == language);
                if (form == null && language != "en-EN")
                {

                    string defaultLanguage = "en-EN";
                    form = uiForm.Forms.FirstOrDefault(f => f.Language == defaultLanguage);
                    if (form == null)
                        return Results.NotFound(name + " " + typeofTable + ", type " + type + " does not exist " + language + " body. Check the Accept-Language header.");
                }
                if (form == null && language == "en-EN")
                {
                    return Results.NotFound(name + " " + typeofTable + ", type " + type + " does not exist " + language + " body. Check the Accept-Language header.");
                }
            }
            bool isPage = false;
            if (typeofTable == typeof(Page).ToString())
            {
                isPage = true;
            }
            var templateURL = configuration["templateEngineUrl"]!.ToString();

            return Results.Ok(new ViewTransitionModel()
            {
                name = isPage ? name : form.Label,
                type = isPage ? type : uiForm.TypeofUiEnum.ToString(),
                language = isPage ? language : form.Language,
                navigation = isPage ? navigation : uiForm.Navigation.ToString(),
                data = "latest",
                body = isPage ? amorphie.workflow.core.Helper.TemplateEngineHelper.TemplateEngineForm(name, string.Empty, templateURL, string.Empty, json)
                : string.Equals(type, TypeofUiEnum.PageUrl.ToString(), StringComparison.OrdinalIgnoreCase) ? form.Label
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
    static async Task<IResult> getAllInstance(
        [FromServices] WorkflowDBContext context,
        [FromQuery] string? entity,
         [FromQuery] string? workflowName,
         [FromQuery] Guid? recordId,
          [FromQuery] GetInstanceStatusType? status,
           [FromQuery] string? SortColumn,
           [FromQuery] SortDirectionEnum? SortDirection,
           CancellationToken cancellationToken,
           [FromQuery][Range(0, 100)] int? page = 0,
        [FromQuery][Range(5, 100)] int? pageSize = 10,
         [FromHeader(Name = "Language")] string? language = "en-EN"
    )
    {
        // TODO : Include a parameter for the cancelation token and convert all ToList objects to ToListAsync with the cancelation token.
        var query = context.Instances!.Include(s => s.Workflow)
   .Where(w => (string.IsNullOrEmpty(entity) || w.EntityName == entity) && (!recordId.HasValue || w.RecordId == recordId) &&
   (string.IsNullOrEmpty(workflowName) || w.WorkflowName == workflowName)
    && !w.Workflow.IsForbiddenData != true)
    .Include(s => s.State).ThenInclude(s => s.Titles)
   .Include(s => s.State).ThenInclude(s => s.Transitions).ThenInclude(t => t.Forms)
    .Include(s => s.State).ThenInclude(s => s.Transitions).ThenInclude(t => t.Forms)
    .Include(s => s.State).ThenInclude(s => s.Transitions).ThenInclude(t => t.UiForms).ThenInclude(t => t.Forms)
   .Include(s => s.State).ThenInclude(s => s.Transitions).ThenInclude(t => t.Titles)
   .Include(s => s.State).ThenInclude(s => s.Transitions).ThenInclude(t => t.HistoryForms)
   .Include(s => s.State).ThenInclude(s => s.Transitions).ThenInclude(t => t.Page).ThenInclude(t => t.Pages).AsQueryable()
   ;

        if (!string.IsNullOrEmpty(SortColumn))
            query = await query.Sort<Instance>(SortColumn, SortDirection.GetValueOrDefault(0));
        var instances = await query.Skip(page.GetValueOrDefault(0) * pageSize.GetValueOrDefault(10))
         .Take(pageSize.GetValueOrDefault(10))
         .ToListAsync(cancellationToken);
        var instanceTransitionsList = await context.InstanceTransitions.Where(s => query.Any(q => q.Id == s.InstanceId)).ToListAsync(cancellationToken);
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
                        t.UiForms != null && t.UiForms.Count() > 0 ? null : t.UiForms.Select(st => new amorphie.workflow.core.Dtos.UiFormDto()
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

                      instanceTransitionsList!.Any(w => w.InstanceId == s.Id) ?
                      instanceTransitionsList.Where(w => w.InstanceId == s.Id).OrderByDescending(s => s.CreatedAt).FirstOrDefault()!.CreatedAt :
                      DateTime.UtcNow,
                    instanceTransitionsList.Any(w => w.InstanceId == s.Id) ?
                    System.Text.Json.JsonSerializer.Deserialize<dynamic>(instanceTransitionsList.Where(w => w.InstanceId == s.Id).OrderByDescending(s => s.CreatedAt).FirstOrDefault()!.EntityData) :
                    null
                    )
                ).ToArray());
    }
    static async ValueTask<IResult> getAllInstanceWithFullTextSearch(
              [FromServices] WorkflowDBContext context,
                [FromQuery] string? workflowName,
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

        var query = context!.Instances!.Include(s => s.Workflow).Where(w => (!isGuidSearch || (isGuidSearch && (guid == w.Id || guid == w.RecordId)))
          && (string.IsNullOrEmpty(workflowName) || (!string.IsNullOrEmpty(workflowName) && workflowName == w.WorkflowName))
      && w.Workflow.IsForbiddenData != true)
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

        var instances = await query.Skip(instanceSearch.Page * instanceSearch.PageSize)
            .Take(instanceSearch.PageSize).ToListAsync(cancellationToken);
        var instanceTransitionsList = await context.InstanceTransitions.Where(s => query.Any(q => q.Id == s.InstanceId)).ToListAsync(cancellationToken);
        if (instances.Count > 0)
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
                      instanceTransitionsList.Any(w => w.InstanceId == s.Id) ?
                      instanceTransitionsList.Where(w => w.InstanceId == s.Id).OrderByDescending(s => s.CreatedAt).FirstOrDefault()!.CreatedAt :
                      DateTime.UtcNow,
                    instanceTransitionsList.Any(w => w.InstanceId == s.Id) ?
                    System.Text.Json.JsonSerializer.Deserialize<dynamic>(instanceTransitionsList.Where(w => w.InstanceId == s.Id).OrderByDescending(s => s.CreatedAt).FirstOrDefault()!.EntityData) :
                    null

                    )
                ).ToList();


            return Results.Ok(response);
        }

        return Results.NoContent();
    }

    static async Task<IResult> getTransitionByInstanceAsync(
         [FromServices] WorkflowDBContext context,
         [FromRoute(Name = "instanceId")] Guid instanceId,
         CancellationToken cancellationToken,
            [FromHeader(Name = "Accept-Language")] string? language = "en-EN"
     )
    {
        var instance = await context.Instances!.Include(s => s.State).ThenInclude(s => s.Transitions).ThenInclude(s => s.UiForms)
        .Include(s => s.State).ThenInclude(s => s.SubWorkflow).ThenInclude(s => s.States).ThenInclude(s => s.Transitions).ThenInclude(s => s.UiForms)
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
                              transition = instance.State.Type != StateType.SubWorkflow ? instance.State.Transitions.Select(t => new InitTransition()
                              {
                                  requireData = t.requireData,
                                  transition = t.Name,
                                  type = t.transitionButtonType.GetValueOrDefault(TransitionButtonType.Forward).ToString(),
                                  hasViewVariant = t.UiForms.Any() && t.UiForms.Count() > 1 ? true : false
                              }).ToList() :
                              instance.State.SubWorkflow?.States.Where(w => w.Type == StateType.Start)
                              .FirstOrDefault()?.Transitions.Select(t => new InitTransition()
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
        var instance = await context.Instances!.Include(s => s.Workflow).Include(s => s.State).ThenInclude(s => s.Transitions).Where(s => s.WorkflowName != null)
   .FirstOrDefaultAsync(w => w.Id == instanceId && w.Workflow!.IsForbiddenData != true, cancellationToken)
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
        if (latest.HasValue && latest.Value)
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
        if (latestPayload.HasValue && latestPayload.Value)
        {
            try
            {
                instanceTransition = await context.InstanceTransitions.Where(w => w.InstanceId == instanceId).OrderBy(c => c.CreatedAt).Reverse()
                .Skip(1).FirstOrDefaultAsync(cancellationToken);
                if (instanceTransition == null)
                {
                    return Results.NotFound("Instance does not have last transition");
                }
                try
                {
                    return Results.Ok(System.Text.Json.JsonSerializer.Deserialize<dynamic>(instanceTransition.EntityData));
                }
                catch (Exception)
                {

                    return Results.Ok(instanceTransition.EntityData);
                }

            }
            catch (Exception ex)
            {
                return Results.Problem("Try latest instead of latest-payload");
            }
        }
        if (firstPayload.HasValue && firstPayload.Value)
        {
            try
            {
                instanceTransition = await context.InstanceTransitions.Where(w => w.InstanceId == instanceId).OrderBy(c => c.CreatedAt)
                .FirstOrDefaultAsync(cancellationToken);
                if (instanceTransition == null)
                {
                    return Results.NotFound("Instance does not have a transition");
                }
                try
                {
                    return Results.Ok(System.Text.Json.JsonSerializer.Deserialize<dynamic>(instanceTransition.EntityData));
                }
                catch (Exception)
                {

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
                try
                {
                    return Results.Ok(System.Text.Json.JsonSerializer.Deserialize<dynamic>(instanceTransition.EntityData));
                }
                catch (Exception)
                {

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
    static async Task<IResult> getHistoryByInstanceAsync(
        [FromServices] WorkflowDBContext context,
        [FromRoute(Name = "instanceId")] string instanceId,
        CancellationToken cancellationToken,
           [FromHeader(Name = "Accept-Language")] string? language = "en-EN"
    )
    {
        Instance instanceControl = await context.Instances.Include(i => i.Workflow).FirstOrDefaultAsync(f => f.Id.ToString() == instanceId);
        if (instanceControl == null)
        {
            return Results.NotFound();
        }
        if (instanceControl.Workflow.IsForbiddenData.GetValueOrDefault(false))
        {
            return Results.Problem(instanceControl.WorkflowName + " is forbidden to get history");
        }
        List<amorphie.workflow.core.Models.SignalR.SignalRData> signalrHistoryList = await context.SignalRResponses.Where(w => w.InstanceId == instanceId
             && (w.subject == "worker-completed" || w.subject == "transition-completed")
             && w.routeChange == true
             )
             .OrderByDescending(o => o.CreatedAt).ToListAsync(cancellationToken);
        if (signalrHistoryList == null)
        {
            return Results.NotFound();
        }
        if (signalrHistoryList != null && signalrHistoryList.Any())
        {

            List<SignalRResponsePublic> response = signalrHistoryList.Select(s =>
            {
                var temp = ObjectMapper.Mapper.Map<SignalRResponsePublic>(s);
                temp.data = System.Text.Json.JsonSerializer.Deserialize<dynamic>(s.data);
                return temp;
            }).ToList();
            return Results.Ok(response);
        }
        return Results.NotFound();

    }
}

