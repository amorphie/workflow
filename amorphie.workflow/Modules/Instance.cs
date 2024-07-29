using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Globalization;
using amorphie.core.Base;
using amorphie.core.Enums;
using amorphie.core.Extension;
using amorphie.workflow.core.Constants;
using amorphie.workflow.core.Dtos;
using amorphie.workflow.core.Enums;
using amorphie.workflow.core.Models;
using amorphie.workflow.service.Db.Abstracts;
using amorphie.workflow.service.Filters;
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
        }).AddEndpointFilter<InstanceSchemaValidationFilter>();

        //     app.MapGet("/workflow/uiform/updatedb", UiFormFill
        //   )
        //   .Produces<GetInstanceResponse[]>(StatusCodes.Status200OK)
        //   .Produces(StatusCodes.Status404NotFound)
        //   .WithOpenApi(operation =>
        //   {


        //       operation.Tags = new List<OpenApiTag> { new() { Name = "UiForm" } };

        //       return operation;
        //   });

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

        app.MapGet("/workflow/instance/user/{workflowName}/data", getInstanceDataByUserRefAsync
         )
         .Produces<GetInstanceResponse[]>(StatusCodes.Status200OK)
         .Produces(StatusCodes.Status404NotFound)
         .WithOpenApi(operation =>
         {
             operation.Summary = "Returns requested workflow instance data";
             operation.Parameters[0].Description = "Workflow name.";

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
    static async ValueTask<IResult> InitInstance(
   [FromServices] WorkflowDBContext context,
     [FromRoute(Name = "workflowName")] string workflowName,
     [FromQuery(Name = "suffix")] string? suffix,
     [FromQuery(Name = "type")] string? type,
      [FromQuery(Name = "preInstanceId")] string? preInstanceId,
       [FromQuery(Name = "preWorkflowName")] string? preWorkflowName,
        [FromHeader(Name = "user_reference")] string? userReference,
           [FromHeader(Name = "role")] string? role,
    CancellationToken cancellationToken,
        [FromHeader(Name = "Accept-Language")] string? language = "en-EN"

)
    {

        var workflowControl = await context.Workflows.FirstOrDefaultAsync(f => f.Name == workflowName);
        if (workflowControl == null)
            return Results.NoContent();
        if (string.IsNullOrEmpty(type))
        {
            type = TypeofUiEnum.FlutterWidget.ToString().ToLower();
        }
        State? currentState = null;

        Instance? instance = null;
        if (workflowControl.IsAllowOneActiveInstance.GetValueOrDefault(false))
        {

            instance = await context.Instances.OrderByDescending(o => o.ModifiedAt).FirstOrDefaultAsync(f => f.WorkflowName == workflowName && userReference == f.UserReference);


        }
        currentState = await context.States.Where(w => ((instance != null && instance.StateName == w.Name) || instance == null && w.Type == StateType.Start) && w.WorkflowName == workflowName
&& ((string.IsNullOrEmpty(suffix)) || (!string.IsNullOrEmpty(suffix) && w.AllowedSuffix != null && w.AllowedSuffix.Any(a => a.Equals(suffix)))))
.Include(s => s.Transitions)
.Include(s => s.UiForms)
.FirstOrDefaultAsync(cancellationToken);

        if (currentState == null)
            return Results.NoContent();

        var initDto = getRecordWorkflowInit(currentState, suffix, type, language, role);

        if (instance != null)
        {
            initDto.instanceId = instance.Id.ToString();
        }

        if (initDto.transition.Count == 0)
        {
            initDto.transition.Add(new InitTransition
            {
                type = currentState.transitionButtonType.GetValueOrDefault(TransitionButtonType.Forward).ToString(),
                requireData = currentState.requireData,
                transition = currentState.Name,
                hasViewVariant = currentState.UiForms != null && currentState.UiForms.Count() > 1 ? true : false
            });
        }
        Response<dynamic> preData = await PreWorkflowData(context, preInstanceId, preWorkflowName, cancellationToken);
        if (preData.Result.Status != amorphie.core.Enums.Status.Error.ToString())
        {
            initDto.additionalData = preData.Data;
        }
        return Results.Ok(initDto);
    }
    private static async ValueTask<Response<dynamic>> PreWorkflowData(WorkflowDBContext context, string? preInstanceId, string? preWorkflowName, CancellationToken token)
    {
        if (string.IsNullOrEmpty(preInstanceId))
        {
            return new Response<dynamic>
            {
                Result = new Result(amorphie.core.Enums.Status.Error, "")
            };
        }
        List<SignalRResponseHistory> history = await getSignalRData(context, preInstanceId, token);
        SignalRResponseHistory? last = history.OrderByDescending(o => o.time).FirstOrDefault();
        if (last != null)
        {
            PostSignalRData? postSignalRData = System.Text.Json.JsonSerializer.Deserialize<PostSignalRData>(last.data);
            if (postSignalRData != null && (string.IsNullOrEmpty(preWorkflowName) || postSignalRData.workflowName == preWorkflowName))
            {
                dynamic? response = MergeEntityAdditional(postSignalRData.data, postSignalRData.additionalData);

                return new Response<dynamic>
                {
                    Data = response,
                    Result = new Result(amorphie.core.Enums.Status.Success, "")
                };
            }
        }
        return new Response<dynamic>
        {
            Result = new Result(amorphie.core.Enums.Status.Error, "")
        };

    }
    private static dynamic? MergeEntityAdditional(dynamic entityData, dynamic additionalData)
    {
        var jsonData = Newtonsoft.Json.Linq.JObject.Parse(Convert.ToString(entityData));
        var mergeAdditional = Newtonsoft.Json.Linq.JObject.Parse(Convert.ToString(additionalData));
        jsonData.Merge(mergeAdditional, new Newtonsoft.Json.Linq.JsonMergeSettings
        {
            MergeArrayHandling = Newtonsoft.Json.Linq.MergeArrayHandling.Union
        });
        return System.Text.Json.JsonSerializer.Deserialize<dynamic>(jsonData.ToString());
    }
    private static GetRecordWorkflowInit getRecordWorkflowInit(State currentState, string? suffix, string type, string language, string role)
    {
        string navigationType = amorphie.workflow.core.Helper.EnumHelper.GetDescription<NavigationType>(NavigationType.Push);
        UiForm? uiform = currentState.UiForms.FirstOrDefault(s => s.TypeofUiEnum.ToString().ToLower() == type && s.Role == role);
        if (uiform == null)
        {
            uiform = currentState.UiForms.FirstOrDefault(s => s.TypeofUiEnum.ToString().ToLower() == type);
        }
        if (uiform != null)
        {
            navigationType = amorphie.workflow.core.Helper.EnumHelper.GetDescription<NavigationType>(uiform.Navigation.GetValueOrDefault(NavigationType.Push));
        }
        var initDto = new GetRecordWorkflowInit()
        {
            state = currentState.Name,
            viewSource = currentState.IsPublicForm == true ? "state" : "transition",
            initPageName = currentState.InitPageName,
            navigation = navigationType,
            transition = currentState.Transitions.Select(t => new InitTransition()
            {
                type = currentState.transitionButtonType.GetValueOrDefault(TransitionButtonType.Forward).ToString(),
                requireData = currentState.requireData,
                transition = t.Name,
                hasViewVariant = currentState.UiForms != null && currentState.UiForms.Count() > 1 ? true : false,

            }).ToList(),
        };



        if (!string.IsNullOrEmpty(initDto.initPageName) && !string.IsNullOrEmpty(suffix))
        {
            initDto.initPageName += "-" + suffix;
        }
        return initDto;
    }
    static async ValueTask<IResult> ViewTransition(
        [FromServices] WorkflowDBContext context,
         IConfiguration configuration,
        CancellationToken cancellationToken,
        [FromRoute(Name = "transitionName")] string transitionName,

        [FromQuery] string? type,
          [FromQuery] int? json,
            [FromHeader(Name = "role")] string? role,
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

                // uiForm = transition.UiForms.FirstOrDefault(f => f.TypeofUiEnum.ToString().ToLower() == type);
                uiForm = transition.UiForms.FirstOrDefault(f => f.TypeofUiEnum.ToString().ToLower() == type
                && (role == f.Role && f.Role != null)
                );
                if (uiForm == null)
                {
                    uiForm = transition.UiForms.FirstOrDefault(f => f.TypeofUiEnum.ToString().ToLower() == type
                && (string.IsNullOrEmpty(f.Role))
                );
                }
                return await View(configuration, transitionName, type, typeof(Transition).ToString(), uiForm, language, json, string.Empty, string.Empty);
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
  [FromQuery(Name = "suffix")] string? suffix,
     [FromQuery] string? type,
        [FromQuery] int? json,
        [FromHeader(Name = "role")] string? role,
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

                if (!string.IsNullOrEmpty(suffix))
                {
                    if (state.AllowedSuffix != null && !state.AllowedSuffix.Any(a => a.Equals(suffix)))
                    {
                        return Results.Problem(suffix + " is not allowed suffix");
                    }
                    suffix = "-" + suffix;

                }
                uiForm = state.UiForms.FirstOrDefault(f => f.TypeofUiEnum.ToString().ToLower() == type
                && (role == f.Role && f.Role != null)
                );
                if (uiForm == null)
                {
                    uiForm = state.UiForms.FirstOrDefault(f => f.TypeofUiEnum.ToString().ToLower() == type
                && (string.IsNullOrEmpty(f.Role))
                );
                }
                return await View(configuration, stateName, type, typeof(State).ToString(), uiForm, language, json, string.Empty, suffix);
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
            return await View(configuration, pageName, type, typeof(Page).ToString(), null, language, json, navigation, string.Empty);

        }
        catch (Exception ex)
        {
            return Results.BadRequest("Unexpected error:" + ex.ToString());
        }
    }
    private static async ValueTask<IResult> View(IConfiguration configuration,
        string name, string type, string typeofTable, UiForm? uiForm, string? language, int? json, string navigation, string suffix)
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
                    return Results.NotFound(typeofTable + " does not have " + type + " type under your authority");
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
                name = isPage ? name : form.Label + suffix,
                type = isPage ? type : uiForm.TypeofUiEnum.ToString(),
                language = isPage ? language : form.Language,
                navigation = isPage ? navigation : uiForm.Navigation.ToString(),
                data = "latest",
                body = isPage ? amorphie.workflow.core.Helper.TemplateEngineHelper.TemplateEngineForm(name, string.Empty, templateURL, string.Empty, json)
                : string.Equals(type, TypeofUiEnum.PageUrl.ToString(), StringComparison.OrdinalIgnoreCase) ? form.Label
                : amorphie.workflow.core.Helper.TemplateEngineHelper.TemplateEngineForm(form.Label + suffix, string.Empty, templateURL, string.Empty, json)
            });

        }
        catch (Exception ex)
        {
            return Results.BadRequest("Unexpected error:" + ex.ToString());
        }
    }
    static async ValueTask<IResult> TriggerFlow(
  [FromBody] dynamic body,
  [FromRoute(Name = "transitionName")] string transitionName,
  CancellationToken cancellationToken,
  [FromServices] IPostTransactionService service,
  [FromRoute(Name = "instanceId")] Guid instanceId,
  HttpRequest request,
  [FromHeader(Name = "User")] Guid user,
  [FromHeader(Name = "Behalf-Of-User")] Guid behalOfUser
)
    {
        var result = await service.InitWithoutEntity(instanceId, transitionName, user, behalOfUser, body, request.Headers, cancellationToken);

        if (result.Result.Status == Status.Success.ToString() && transitionName == ZeebeVariableKeys.WfAddNoteStart)
        {
            return result;
        }

        if (result.Result.Status == Status.Success.ToString())
        {
            return await service.ExecuteWithoutEntity();
        }

        // if (result.StatusCode.ToString()  == "200")
        // {
        //   return await service.ExecuteWithoutEntity();
        // }
        // return result;
        if (result.Data == HttpStatusEnum.Conflict)
        {
            result.Data = null;
            return Results.Conflict(result);
        }
        if (result.Data == HttpStatusEnum.NotFound)
        {
            result.Data = null;
            return Results.NotFound(result);
        }
        result.Data = null;
        return Results.BadRequest(result);

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
                instances.Select(s => new GetInstanceResponse()
                {
                    EntityName = s.EntityName,
                    RecordId = s.RecordId.ToString(),
                    Id = s.Id,
                    WorkflowName = s.WorkflowName,
                    State = new GetStateDefinition(s.StateName, new amorphie.workflow.core.Dtos.MultilanguageText(
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
                        null,
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
                    CreatedAt = s.CreatedAt,

                    LastTransitionAt = instanceTransitionsList!.Any(w => w.InstanceId == s.Id) ?
                      instanceTransitionsList.Where(w => w.InstanceId == s.Id).OrderByDescending(s => s.CreatedAt).FirstOrDefault()!.CreatedAt :
                      DateTime.UtcNow,
                    data = instanceTransitionsList.Any(w => w.InstanceId == s.Id) ?
                    System.Text.Json.JsonSerializer.Deserialize<dynamic>(instanceTransitionsList.Where(w => w.InstanceId == s.Id).OrderByDescending(s => s.CreatedAt).FirstOrDefault()!.EntityData) :
                    null,
                    additionalData = instanceTransitionsList.Any(w => w.InstanceId == s.Id) ?
                    System.Text.Json.JsonSerializer.Deserialize<dynamic>(instanceTransitionsList.Where(w => w.InstanceId == s.Id).OrderByDescending(s => s.CreatedAt).FirstOrDefault()!.AdditionalData) :
                    null,
                    humanTasks = null

                }
                ).ToArray());
    }
    static async ValueTask<IResult> getAllInstanceWithFullTextSearch(
              [FromServices] WorkflowDBContext context,
                   [FromServices] amorphie.workflow.service.Db.HumanTaskService humanTaskService,
                [FromQuery] string? WorkflowName,
                 [FromHeader(Name = "role")] string? role,
              [AsParameters] InstanceSearch instanceSearch,

      CancellationToken cancellationToken,
           [FromHeader(Name = "Accept-Language")] string? language = "en-EN"
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
        DateTime startTime = new DateTime(1901, 1, 1);
        if (!string.IsNullOrEmpty(instanceSearch.Start))
        {
            try
            {

                startTime = Convert.ToDateTime(instanceSearch.Start);

            }
            catch (Exception)
            {
                startTime = new DateTime(1901, 1, 1);
            }
        }
        DateTime endTime = new DateTime(2099, 12, 31);
        if (!string.IsNullOrEmpty(instanceSearch.End))
        {
            try
            {

                endTime = Convert.ToDateTime(instanceSearch.End);

            }
            catch (Exception)
            {
                endTime = new DateTime(2099, 12, 31);
            }
        }
        string[] stateList = [];
        if (!string.IsNullOrEmpty(instanceSearch.State))
        {
            try
            {

                stateList = instanceSearch.State.Split(",");

            }
            catch (Exception)
            {
                stateList = [];
            }
        }
        var query = context!.InstanceTransitions!.Include(s => s.Instance).ThenInclude(s => s.Workflow).Where(w => (!isGuidSearch || (isGuidSearch && (guid == w.InstanceId)))
          && (string.IsNullOrEmpty(WorkflowName) || (!string.IsNullOrEmpty(WorkflowName) && WorkflowName == w.Instance.WorkflowName))
           && (string.IsNullOrEmpty(instanceSearch.State) || (!string.IsNullOrEmpty(instanceSearch.State) && stateList.Any(a => a == w.Instance.StateName)))
      && w.Instance.Workflow.IsForbiddenData != true
      && w.Instance.CreatedAt >= startTime && w.Instance.CreatedAt <= endTime)
          .Include(s => s.Instance).ThenInclude(s => s.State).ThenInclude(s => s.Titles)
   .Include(s => s.Instance).ThenInclude(s => s.State).ThenInclude(s => s.Transitions).ThenInclude(t => t.Forms)
    .Include(s => s.Instance).ThenInclude(s => s.State).ThenInclude(s => s.Transitions).ThenInclude(t => t.Forms)
    .Include(s => s.Instance).ThenInclude(s => s.State).ThenInclude(s => s.Transitions).ThenInclude(t => t.UiForms).ThenInclude(t => t.Forms)
   .Include(s => s.Instance).ThenInclude(s => s.State).ThenInclude(s => s.Transitions).ThenInclude(t => t.Titles)
   .Include(s => s.Instance).ThenInclude(s => s.State).ThenInclude(s => s.Transitions).ThenInclude(t => t.HistoryForms)
   .Include(s => s.Instance).ThenInclude(s => s.State).ThenInclude(s => s.Transitions).ThenInclude(t => t.Page).ThenInclude(t => t.Pages).AsQueryable()
            ;
        if (!string.IsNullOrEmpty(instanceSearch.Keyword))
        {

            query = query.AsNoTracking().Where(p => p.SearchVector.Matches(EF.Functions.PlainToTsQuery("english", instanceSearch.Keyword)));
        }
        if (instanceSearch.KeywordList != null && instanceSearch.KeywordList.Any())
        {
            foreach (var item in instanceSearch.KeywordList)
            {
                query = query.AsNoTracking().Where(p => EF.Functions.JsonContains(p.EntityData, item) || EF.Functions.JsonContains(p.AdditionalData, item));
            }

        }

        if (await query.CountAsync() > 0)
        {
            var queryList = await query.ToListAsync(cancellationToken);
            var response = queryList.GroupBy(s => s.Instance,
              (s, group) => new GetInstanceResponse()
              {
                  EntityName = s.EntityName
                ,
                  RecordId = s.RecordId.ToString(),
                  Id = s.Id,
                  WorkflowName = s.WorkflowName,
                  State = new GetStateDefinition(s.StateName,

                    s.State != null && s.State.Titles != null && s.State.Titles.Any() ? new amorphie.workflow.core.Dtos.MultilanguageText(
                    s.State.Titles.FirstOrDefault()!.Language!, s.State.Titles.FirstOrDefault()!.Label
                    ) : null,

                    s.State.BaseStatus,
                    s.State.Transitions.Select(t => new PostTransitionDefinitionRequest(
                        t.Name,

                        t.Titles != null && t.Titles.Any() ? new amorphie.workflow.core.Dtos.MultilanguageText(
                            t.Titles.FirstOrDefault()!.Language!, t.Titles.FirstOrDefault()!.Label) : null,

                        t.ToStateName,
                       //null,
                       t.UiForms != null && t.UiForms.Any() ? t.UiForms.Select(st => new amorphie.workflow.core.Dtos.UiFormDto()
                       {
                           typeofUi = st.TypeofUiEnum,
                           navigationType = st.Navigation,
                           forms = st.Forms.Select(sf => new amorphie.workflow.core.Dtos.MultilanguageText(
                           sf.Language, sf.Label)).ToArray()
                       }).ToArray() : null,
                       null,
                        t.FromStateName,
                        t.ServiceName,
                        t.FlowName,
                        null,
                          t.Page == null ? null :
                       new PostPageDefinitionRequest(t.Page.Operation, t.Page.Type, t.Page.Pages != null && t.Page.Pages.Any() ? null : t.Page.Pages!.Select(s => new amorphie.workflow.core.Dtos.MultilanguageText(s.Language, s.Label)).FirstOrDefault(), t.Page.Timeout)
                       , null
                       , t.TypeofUi, t.transitionButtonType
                    )).ToArray()
                    ),
                  CreatedAt = s.CreatedAt,
                  LastTransitionAt = group.Max(s => s.CreatedAt),
                  data = string.IsNullOrEmpty(group.OrderByDescending(o => o.CreatedAt).FirstOrDefault()!.EntityData) ? new { } : JsonParse(group.OrderByDescending(o => o.CreatedAt).FirstOrDefault()!.EntityData),
                  additionalData = string.IsNullOrEmpty(group.OrderByDescending(o => o.CreatedAt).FirstOrDefault()!.AdditionalData) ? new { } : JsonParse(group.OrderByDescending(o => o.CreatedAt).FirstOrDefault()!.AdditionalData),
                  humanTasks = null,
                  isHumanTask = context.HumanTasks.FirstOrDefault(f => f.InstanceId == s.Id && f.Status == HumanTaskStatus.Pending && f.State == s.StateName) == null ? false : true,
                  viewSource = s.State.IsPublicForm == false ? amorphie.workflow.core.Helper.EnumHelper.GetDescription<ViewSourceEnum>((ViewSourceEnum)ViewSourceEnum.Transition) :
                    amorphie.workflow.core.Helper.EnumHelper.GetDescription<ViewSourceEnum>((ViewSourceEnum)ViewSourceEnum.State)

              });

            var responseSortModel = await response.AsQueryable<GetInstanceResponse>().Sort<GetInstanceResponse>(instanceSearch.SortColumn, instanceSearch.SortDirection);
            response = responseSortModel.AsEnumerable();
            var returnModel = response.Skip(instanceSearch.Page * instanceSearch.PageSize)
         .Take(instanceSearch.PageSize).ToList();
            return Results.Ok(returnModel);
        }


        return Results.NoContent();
    }
    private static dynamic JsonParse(string data)
    {
        try
        {
            return System.Text.Json.JsonSerializer.Deserialize<dynamic>(data);
        }
        catch (Exception)
        {
            return new { };
        }

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
         [FromQuery] string? transitionName

  )
    {
        List<SignalRResponseHistory> response = await getSignalRData(context, instanceId.ToString(), cancellationToken);
        return await PrepareInstanceDataAsync(response, latest, latestPayload, firstPayload, transitionName);


    }
    static async Task<IResult> getInstanceDataByUserRefAsync(
      [FromServices] WorkflowDBContext context,
      [FromRoute(Name = "workflowName")] string workflowName,
       [FromHeader(Name = "user_reference")] string? userReference,
      CancellationToken cancellationToken

  )
    {
        List<SignalRResponseHistory> response = await getSignalRDataByUserReference(context, workflowName, userReference, cancellationToken);
        return await PrepareInstanceDataAsync(response, null, null, null, null);
    }

    static async Task<IResult> PrepareInstanceDataAsync(
  List<SignalRResponseHistory> response,
   bool? latest,
   bool? latestPayload,
   bool? firstPayload,
     string? transitionName
)
    {
        if (latest == null && latestPayload == null && firstPayload == null && string.IsNullOrEmpty(transitionName))
        {
            latest = true;
        }
        if (latest.HasValue && latest.Value)
        {
            return Results.Ok(response.FirstOrDefault());
        }
        if (latestPayload.HasValue && latestPayload.Value)
        {
            try
            {
                if (response.Count > 1)
                {
                    return Results.Ok(response.Skip(1).FirstOrDefault());
                }
                return Results.Ok(response.FirstOrDefault());

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
                return Results.Ok(response.OrderBy(o => o.time).FirstOrDefault());
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
                string transitionControl = "\"transitionName\":\"" + transitionName + "\"";
                return Results.Ok(response.Find(w => w.data.Contains(transitionControl)));

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
        List<SignalRResponseHistory> response = await getSignalRData(context, instanceId, cancellationToken);
        if (!response.Any())
        {
            return Results.NotFound();
        }
        return Results.Ok(response);

    }
    private async static Task<List<SignalRResponseHistory>> getSignalRData(WorkflowDBContext context, string instanceId, CancellationToken cancellationToken)
    {
        Instance instanceControl = await context.Instances.Include(i => i.Workflow).FirstOrDefaultAsync(f => f.Id.ToString() == instanceId);
        if (instanceControl == null || instanceControl.Workflow.IsForbiddenData.GetValueOrDefault(false))
        {
            return new List<SignalRResponseHistory>();
        }
        return await GetSignalRHistory(context, instanceControl, cancellationToken);
    }
    private async static Task<List<SignalRResponseHistory>> getSignalRDataByUserReference(WorkflowDBContext context, string workflowName, string userReference, CancellationToken cancellationToken)
    {
        var instanceControl = await context.Instances.Include(i => i.Workflow)
        .OrderByDescending(p => p.CreatedAt).FirstOrDefaultAsync(f => f.UserReference == userReference && f.WorkflowName == workflowName);
        if (instanceControl == null || instanceControl.Workflow.IsForbiddenData.GetValueOrDefault(false))
        {
            return new List<SignalRResponseHistory>();
        }
        return await GetSignalRHistory(context, instanceControl, cancellationToken);
    }
    private async static Task<List<SignalRResponseHistory>> GetSignalRHistory(WorkflowDBContext context, Instance instanceControl, CancellationToken cancellationToken)
    {
        List<amorphie.workflow.core.Models.SignalR.SignalRData> signalrHistoryList = await context.SignalRResponses.Where(w => w.InstanceId == instanceControl.Id.ToString()
             && (w.subject == EventInfos.WorkerCompleted || w.subject == EventInfos.TransitionCompleted)

             )
             .OrderBy(o => o.CreatedAt).ToListAsync(cancellationToken);
        if (signalrHistoryList == null)
        {
            return new List<SignalRResponseHistory>();
        }
        if (signalrHistoryList != null && signalrHistoryList.Any())
        {
            string fromStateName = string.Empty;
            List<SignalRResponseHistory> response = signalrHistoryList.Select(s =>
            {
                var temp = ObjectMapper.Mapper.Map<SignalRResponseHistory>(s);
                temp.data = System.Text.Json.JsonSerializer.Deserialize<dynamic>(s.data);
                try
                {
                    temp.toStateName = temp.data.GetProperty("state").ToString();
                }
                catch (Exception)
                {
                    temp.toStateName = string.Empty;
                }
                if (!string.IsNullOrEmpty(fromStateName))
                {
                    temp.fromStateName = fromStateName;
                }
                if (string.IsNullOrEmpty(fromStateName))
                {
                    try
                    {
                        string transitionName = temp.data.GetProperty("transition").ToString();
                        Transition? transition = context.Transitions.FirstOrDefault(f => f.Name == transitionName);
                        if (transition != null)
                        {
                            temp.fromStateName = transition.FromStateName;

                        }
                        fromStateName = temp.toStateName;
                    }
                    catch (Exception)
                    {
                        temp.fromStateName = string.Empty;
                    }
                }

                //temp.toStateName=temp.data.state;
                temp.userReference = instanceControl.UserReference;
                temp.userName = instanceControl.FullName;
                return temp;
            }).OrderByDescending(t => t.time).ToList();
            return response;
        }
        return new List<SignalRResponseHistory>();
    }
}

