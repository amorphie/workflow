
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using amorphie.core.Base;
using amorphie.core.Enums;
using amorphie.core.IBase;
using amorphie.workflow.core.Dtos.Consumer;
using amorphie.workflow.core.Enums;
using Dapr.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using StackExchange.Redis;

public static class ConsumerModule
{
    // TODO :  Move this configuration to the vault.
    public static void MapConsumerEndpoints(this WebApplication app)
    {

        app.MapGet("/workflow/consumer/{entity}/record/{recordId}/transition", getTransitions)
           .Produces<GetRecordWorkflowAndTransitionsResponse>(StatusCodes.Status200OK)
           .WithOpenApi(operation =>
           {
               operation.Summary = "Returns available workflows and related transitions for given record.";
               operation.Tags = new List<OpenApiTag> { new() { Name = "Consumer BFF" } };

               return operation;
           });

        app.MapPost("/workflow/consumer/{entity}/record/{recordId}/transition/{transition}", postTransition)
            .Produces<ConsumerPostTransitionResponse>(StatusCodes.Status200OK)
            .Produces<ConsumerPostTransitionResponse>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status404NotFound)
            .WithOpenApi(operation =>
            {
                operation.Summary = "Triggers transition for existing workflow instance or creates new one.";
                operation.Tags = new List<OpenApiTag> { new() { Name = "Consumer BFF" } };

                operation.Responses["200"].Description = "Instance triggered successfully in existing instance.";
                operation.Responses["201"].Description = "Workflow started successfully with new instance.";
                operation.Responses["404"].Description = "No suitable transaction found for entity or record.";

                return operation;
            });

        app.MapGet("/workflow/consumer/{entity}/record/{recordId}/history/", getHistory)
            .Produces<GetRecordHistoryResponse>(StatusCodes.Status200OK)
            .WithOpenApi(operation =>
            {
                operation.Summary = "Returns record workflow history.";
                operation.Tags = new List<OpenApiTag> { new() { Name = "Consumer BFF" } };

                return operation;
            });

    }
    private static string TemplateEngineFormWithoutJson(string templateName, string entityData, string templateUrlFromVault, string? transitionName)
    {
        var responseDynamic = TemplateEngineForm(templateName, entityData, templateUrlFromVault, transitionName, amorphie.workflow.core.Enums.JsonEnum.NotJson.GetHashCode());
        if (responseDynamic == null)
        {
            return string.Empty;
        }
        return Convert.ToString(responseDynamic);
    }

     private static dynamic? TemplateEngineForm(string templateName, string entityData, string templateUrlFromVault, string? transitionName, int? json)
    {
        string form = string.Empty;

        // TODO : Use refit rather than httpclient and consider resiliency.
        var clientHttp = new HttpClient();
        var response = new HttpResponseMessage();
        string entityDataAfterHistory = entityData;
        if (!string.IsNullOrEmpty(transitionName))
        {
            var dynamicObject = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(entityData)!;
            dynamicObject.transitionNameHeader = transitionName;
            entityDataAfterHistory = Newtonsoft.Json.JsonConvert.SerializeObject(dynamicObject);
        }


        amorphie.workflow.core.Dtos.TemplateEngineRequest request = new amorphie.workflow.core.Dtos.TemplateEngineRequest()
        {
            RenderId = Guid.NewGuid(),
            Name = templateName,
            RenderData = entityDataAfterHistory,
            RenderDataForLog = entityDataAfterHistory,
            ProcessName = "Workflow Get Transition",
            ItemId = string.Empty,
            Action = "TemplateEngineForm",
            Identity = string.Empty,
            Customer = "",
            IsSchribanRender=false
        };
        var serializeRequest = JsonSerializer.Serialize(request);
        try
        {

            response = clientHttp.PostAsync(templateUrlFromVault, new StringContent(serializeRequest, System.Text.Encoding.UTF8, "application/json")).Result;
            var twiceSerialize = response!.Content!.ReadAsStringAsync().Result;
            form = Newtonsoft.Json.JsonConvert.DeserializeObject<string>(twiceSerialize)!;
            form = ReplaceDropdown(form);
            //builder.Configuration["DAPR_SECRET_STORE_NAME"]
        }
        catch (Exception ex)
        {
            form = string.Empty;
        }
        if (string.IsNullOrEmpty(form))
            return new { };
        if (JsonEnum.Json.GetHashCode() == json)
            return System.Text.Json.JsonSerializer.Deserialize<dynamic>(form);
        else return form;
    }
   
    private static string ReplaceDropdown(string form)
    {
        //
        int startindex = 0;
        int selectCount = 0;
        while (form.Contains("\"type\": \"select\"") && (form.Contains("\"dataSrc\": \"url\"")))
        {
            selectCount++;
            var regexDataSrc = new System.Text.RegularExpressions.Regex(System.Text.RegularExpressions.Regex.Escape("\"dataSrc\": \"url\","));
            form = regexDataSrc.Replace(form, "\"dataSrc\": \"json\",", 1);
            string data = "\"data\": {";
            string formIndexStart = form.Substring(startindex);
            int indexofUrlStart = formIndexStart.IndexOf("\"url\": \"http");
            startindex = indexofUrlStart + startindex;
            string AfterUrl = form.Substring(startindex + 8);
            int indexofUrlEndSub = AfterUrl.IndexOf("\"");
            string OnlyUrl = AfterUrl.Substring(0, indexofUrlEndSub);
            var clientHttp = new HttpClient();
            var response = clientHttp.GetAsync(OnlyUrl).Result;
            response.EnsureSuccessStatusCode();
            string responseBody = response.Content.ReadAsStringAsync().Result;
            form = form.Insert(startindex, " \"json\":" + responseBody + " ,");
            startindex += responseBody.Length + 23 + indexofUrlEndSub;
        }

        return form;
    }
    static async Task<IResponse<GetRecordWorkflowAndTransitionsResponse>> getTransitions(
           [FromServices] WorkflowDBContext dbContext,
           [FromRoute(Name = "entity")] string entity,
           [FromRoute(Name = "recordId")] Guid recordId,
           [FromServices] DaprClient client,
            IConfiguration configuration,
            CancellationToken token,
           [FromHeader(Name = "Accept-Language")] string language = "tr-TR",
           [FromQuery][Range(0, 1)] int? json = 0

       )
    {
        // TODO: Include a parameter for the cancelation token and convert all ToList objects to ToListAsync with the cancelation token.
        //**************************//
        // load all workflows available to entity
        var workflows =await  dbContext.WorkflowEntities!
                .Where(e => e.Name == entity)
                .Include(e => e.Workflow)
                    .ThenInclude(w => w.Titles.Where(l => l.Language == language))
                .Include(e => e.Workflow)
                    .ThenInclude(w => w.States)
                    .ThenInclude(s => s.Titles.Where(l => l.Language == language))
                     .Include(e => e.Workflow)
                    .ThenInclude(w => w.States)
                    .ThenInclude(s => s.PublicForms.Where(l => l.Language == language))
                .Include(e => e.Workflow)
                    .ThenInclude(w => w.States)
                    .ThenInclude(s => s.Transitions)
                    .ThenInclude(t => t.Titles.Where(l => l.Language == language))
                     .Include(e => e.Workflow)
                    .ThenInclude(w => w.States)
                    .ThenInclude(s => s.Transitions)
                    .ThenInclude(t => t.ToState)
                .Include(e => e.Workflow)
                    .ThenInclude(w => w.States)
                    .ThenInclude(s => s.Transitions)
                    .ThenInclude(t => t.Forms.Where(l => l.Language == language))
                    .Include(e => e.Workflow)
                    .ThenInclude(w => w.States)
                    .ThenInclude(s => s.Transitions)
                    .ThenInclude(t => t.Page)
                    .ThenInclude(t => t.Pages)
                .ToListAsync(token);


        if (json == null)
            json = amorphie.workflow.core.Enums.JsonEnum.NotJson.GetHashCode();

        var stateManagerWorkflow = workflows.Where(item => item.IsStateManager == true).FirstOrDefault();

        // load all active workflows of record.
        var instanceRecords =await dbContext.Instances.Where(i => i.EntityName == entity && i.RecordId == recordId && i.BaseStatus != StatusType.Completed).ToListAsync(token);

        var response = new GetRecordWorkflowAndTransitionsResponse();
        var templateURL = configuration["templateEngineUrl"]!.ToString();
        string lastTransitionEntitydata = string.Empty;
        if (stateManagerWorkflow != null)
        {
            var stateManagerInstace = instanceRecords.Where(i => i.WorkflowName == stateManagerWorkflow.WorkflowName).FirstOrDefault();

            if (stateManagerInstace != null)
            {
                InstanceTransition lastTransition = await dbContext.InstanceTransitions
                .Where(f => f.InstanceId == stateManagerInstace.Id)
                .OrderByDescending(o => o.CreatedAt).FirstAsync(token);
                lastTransitionEntitydata = lastTransition.EntityData;
                State? state = await dbContext.States.FirstOrDefaultAsync(s => s.Name == stateManagerInstace.StateName,token);
                response.StateManager = workflows.Where(item => item.IsStateManager == true).Select(item =>
                  new GetRecordWorkflowAndTransitionsResponse.StateManagerWorkflow
                  {
                      Name = item.Workflow.Name,
                      Title = item.Workflow.Titles.First().Label,
                      Status = stateManagerInstace.StateName,
                      IsPublicForm = state?.IsPublicForm.GetValueOrDefault(false),
                      PublicForm = state?.IsPublicForm != true ? null :
                     TemplateEngineForm(state?.PublicForms!.FirstOrDefault(f => f.Language == language)!.Label!, lastTransition.EntityData, templateURL, string.Empty, json),
                      Transitions = item.Workflow.States.FirstOrDefault(s => s.Name == stateManagerInstace.StateName)?.Transitions.Where(w => w.ToState == null || w.ToState.Type != StateType.Fail).Select(t =>
                          new GetRecordWorkflowAndTransitionsResponse.Transition
                          {
                              Name = t.Name,
                              Type = string.IsNullOrEmpty(t.TypeofUi.ToString()) ? amorphie.workflow.core.Enums.TypeofUiEnum.Formio.ToString() : t.TypeofUi.ToString(),
                              Title = t.Titles.FirstOrDefault() == null ? string.Empty : t.Titles.First().Label,
                              Form = state?.IsPublicForm == true ? string.Empty : t.TypeofUi == amorphie.workflow.core.Enums.TypeofUiEnum.PageUrl ? t.Page == null ? string.Empty : t.Page!.Pages!.FirstOrDefault() == null ? string.Empty : t.Page!.Pages!.First().Label
                              : t.Forms.FirstOrDefault() == null ? string.Empty : TemplateEngineForm(t.Forms.First().Label, lastTransition.EntityData, templateURL, string.Empty, json)
                          }).ToArray()
                  }
                      ).FirstOrDefault();
            }
            else
            {
                // Return start state transitions
                response.StateManager = workflows.Where(item => item.IsStateManager == true).Select(item =>
                   new GetRecordWorkflowAndTransitionsResponse.StateManagerWorkflow
                   {
                       Name = item.Workflow.Name,
                       Title = item.Workflow.Titles.First().Label,
                       IsPublicForm = item.Workflow.States.FirstOrDefault(s => s.Type == StateType.Start)?.IsPublicForm.GetValueOrDefault(false),
                       PublicForm = item.Workflow.States.FirstOrDefault(s => s.Type == StateType.Start)?.IsPublicForm != true ? null :
                       TemplateEngineForm(item.Workflow.States.FirstOrDefault(s => s.Type == StateType.Start)?.PublicForms!.FirstOrDefault(f => f.Language == language)!.Label!, string.Empty, templateURL, string.Empty, json),
                       Transitions = item.Workflow.States.FirstOrDefault(s => s.Type == StateType.Start)!.Transitions!.Where(w => w.ToState == null || w.ToState.Type != StateType.Fail).Select(t =>
                           new GetRecordWorkflowAndTransitionsResponse.Transition
                           {
                               Name = t.Name,
                               Type = string.IsNullOrEmpty(t.TypeofUi.ToString()) ? amorphie.workflow.core.Enums.TypeofUiEnum.Formio.ToString() : t.TypeofUi.ToString(),

                               Title = t.Titles.FirstOrDefault() == null ? string.Empty : t.Titles.FirstOrDefault()!.Label,
                               Form = item.Workflow.States.FirstOrDefault(s => s.Type == StateType.Start)?.IsPublicForm == true ? string.Empty : t.TypeofUi == amorphie.workflow.core.Enums.TypeofUiEnum.PageUrl ? t.Page == null ? string.Empty : t.Page!.Pages!.FirstOrDefault() == null ? string.Empty : t.Page!.Pages!.First().Label
                               : t.Forms.FirstOrDefault() == null ? string.Empty : TemplateEngineForm(t.Forms.FirstOrDefault()!.Label, string.Empty, templateURL, string.Empty, json)
                           }).ToArray()
                   }
                       ).FirstOrDefault();
            }
        }

        response.AvailableWorkflows = workflows.Where(item => item.IsStateManager == false).Select(item =>
                new GetRecordWorkflowAndTransitionsResponse.Workflow
                {
                    Name = item.Workflow.Name,
                    Title = item.Workflow.Titles.First().Label,
                    IsPublicForm = item.Workflow.States.Where(s => s.Type == StateType.Start).First()?.IsPublicForm.GetValueOrDefault(false),
                    PublicForm = item.Workflow.States.Where(s => s.Type == StateType.Start).First()?.IsPublicForm != true ? null :
                    TemplateEngineForm(item.Workflow.States.Where(s => s.Type == StateType.Start).First()?.PublicForms!.FirstOrDefault(f => f.Language == language)!.Label!, string.Empty, templateURL, string.Empty, json),
                    Transitions = item.Workflow.States.Where(s => s.Type == StateType.Start).First().Transitions.Where(w => w.ToState == null || w.ToState.Type != StateType.Fail).Select(t =>
                        new GetRecordWorkflowAndTransitionsResponse.Transition
                        {
                            Name = t.Name,
                            Type = string.IsNullOrEmpty(t.TypeofUi.ToString()) ? amorphie.workflow.core.Enums.TypeofUiEnum.Formio.ToString() : t.TypeofUi.ToString(),

                            Title = t.Titles.FirstOrDefault() == null ? string.Empty : t.Titles.First().Label,
                            Form = t.TypeofUi == amorphie.workflow.core.Enums.TypeofUiEnum.PageUrl ? t.Page == null ? string.Empty : t.Page!.Pages!.FirstOrDefault() == null ? string.Empty : t.Page!.Pages!.First().Label
                            : t.Forms.FirstOrDefault() == null ? string.Empty : TemplateEngineForm(t.Forms.First().Label, lastTransitionEntitydata, templateURL, string.Empty, json)
                        }).ToArray()
                }
            ).ToArray();
        if (instanceRecords.Any())
        {
            response.RunningWorkflows = instanceRecords.Where(w => w.Workflow.Entities.Any(a => a.IsStateManager == false)).Select(item =>
    new GetRecordWorkflowAndTransitionsResponse.RunningWorkflow
    {
        InstanceId = item.Id,
        Name = item.Workflow.Name,
        Title = item.Workflow.Titles.First().Label,
        IsPublicForm = item.Workflow.States.Where(s => s.Type == StateType.Start).First()?.IsPublicForm.GetValueOrDefault(false),
        PublicForm = item.Workflow.States.Where(s => s.Type == StateType.Start).First()?.IsPublicForm != true ? null :
        TemplateEngineForm(item.Workflow.States.Where(s => s.Type == StateType.Start).First()?.PublicForms!.FirstOrDefault(f => f.Language == language)!.Label!, string.Empty, templateURL, string.Empty, json),
        Transitions = item.State.Transitions.Where(w => w.ToState == null || w.ToState.Type != StateType.Fail).Select(t =>
            new GetRecordWorkflowAndTransitionsResponse.Transition
            {
                Name = t.Name,
                Type = string.IsNullOrEmpty(t.TypeofUi.ToString()) ? amorphie.workflow.core.Enums.TypeofUiEnum.Formio.ToString() : t.TypeofUi.ToString(),
                Title = t.Titles.FirstOrDefault() == null ? string.Empty : t.Titles.First(f => f.Language == language).Label,
                Form = t.TypeofUi == amorphie.workflow.core.Enums.TypeofUiEnum.PageUrl ? t.Page == null ? string.Empty : t.Page!.Pages!.FirstOrDefault() == null ? string.Empty : t.Page!.Pages!.First().Label
                : t.Forms.FirstOrDefault() == null ? string.Empty : TemplateEngineForm(t.Forms.First(f => f.Language == language).Label, dbContext.InstanceTransitions.OrderBy(o => o.CreatedAt)
                .FirstOrDefault(f => f.InstanceId == item.Id)!.EntityData, templateURL, string.Empty, json)
            }).ToArray()
    }
).ToArray();
        }


        return new Response<GetRecordWorkflowAndTransitionsResponse>
        {
            Data = response,
            Result = new Result(Status.Success, "Success")
        };
        // return Results.Ok(response);
    }

    static async Task<IResponse> postTransition(
            [FromServices] WorkflowDBContext dbContext,
            [FromHeader(Name = "User")] Guid user,
            [FromHeader(Name = "Behalf-Of-User")] Guid behalOfUser,
            [FromRoute(Name = "entity")] string entity,
            [FromRoute(Name = "recordId")] Guid recordId,
            [FromRoute(Name = "transition")] string transition,
            [FromBody] ConsumerPostTransitionRequest data,
            [FromServices] IPostTransactionService service,
            IConfiguration configuration,
            [FromServices] DaprClient client,
             HttpRequest request,
             CancellationToken cancellationToken
        )
    {
        var result = await service.Init(entity, recordId, transition, user, behalOfUser, data, request.Headers,cancellationToken);
        var templateURL = configuration["templateEngineUrl"];
        if (result.Result.Status == Status.Success.ToString())
        {
            result = await service.Execute();
        }

        return result;
    }


    static async Task<IResponse<GetRecordHistoryResponse>> getHistory(
         [FromRoute(Name = "entity")] string entity,
         [FromRoute(Name = "recordId")] Guid recordId,
          [FromServices] WorkflowDBContext dbContext,
          IConfiguration configuration,
           CancellationToken token,
           [FromHeader(Name = "Accept-Language")] string language = "en-EN"
     )
    {

        var templateURL = configuration["templateEngineUrl"]!.ToString();
        var response = new GetRecordHistoryResponse();
        try
        {
            //
            var instanceRecords =await dbContext.Instances.Where(i => i.EntityName == entity && i.RecordId == recordId).Include(s => s.Workflow).ThenInclude(t => t.Entities)
            .Include(s => s.Workflow).ThenInclude(t => t.HistoryForms).ToListAsync(token);



            response.StateManager = instanceRecords.Where(item => item.BaseStatus == StatusType.Completed && item.Workflow.Entities.Any(a => a.IsStateManager == true)).Select(item =>
               new GetRecordHistoryResponse.Workflow(item.WorkflowName, dbContext.InstanceTransitions.Where(w => w.InstanceId == item.Id).Select(ITransaction =>
               new GetRecordHistoryResponse.Transition(ITransaction.TransitionName!,
                ITransaction.FromStateName, ITransaction.ToStateName, ITransaction.StartedAt == null ? ITransaction.CreatedAt : ITransaction.StartedAt, ITransaction.FinishedAt, ITransaction.CreatedBy,
                   dbContext.Transitions.Include(s => s.HistoryForms).FirstOrDefault(f => f.Name == ITransaction.TransitionName && f.HistoryForms != null && f.HistoryForms.Count() > 0) != null ?
                TemplateEngineFormWithoutJson(dbContext.Transitions.Include(s => s.Forms).FirstOrDefault(f => f.Name == ITransaction.TransitionName)!.HistoryForms.FirstOrDefault(f => f.Language == language)!.Label,
                 ITransaction.EntityData, templateURL, dbContext.Transitions.Include(s => s.Titles).FirstOrDefault(f => f.Name == ITransaction.TransitionName)!.Titles!.FirstOrDefault(f => f.Language == language)!.Label) :
                  dbContext.Transitions.Include(s => s.FromState).ThenInclude(t => t.Workflow).FirstOrDefault(f => f.Name == ITransaction.TransitionName)!.FromState!.Workflow!.HistoryForms != null
       && dbContext.Transitions.Include(s => s.FromState).ThenInclude(t => t.Workflow).FirstOrDefault(f => f.Name == ITransaction.TransitionName)!.FromState!.Workflow!.HistoryForms.Count() > 0
       ? TemplateEngineFormWithoutJson(dbContext.Transitions.Include(s => s.FromState).ThenInclude(t => t.Workflow).FirstOrDefault(f => f.Name == ITransaction.TransitionName)!.FromState!.Workflow!.HistoryForms!.FirstOrDefault(f => f.Language == language)!.Label, ITransaction.EntityData, templateURL
       , dbContext.Transitions.Include(s => s.Titles).FirstOrDefault(f => f.Name == ITransaction.TransitionName)!.Titles!.FirstOrDefault(f => f.Language == language)!.Label) :

                TemplateEngineFormWithoutJson((dbContext.Transitions.Include(s => s.Forms).FirstOrDefault(f => f.Name == ITransaction.TransitionName))!.Forms.FirstOrDefault(f => f.Language == language)!.Label,
                 ITransaction.EntityData, templateURL
                 , dbContext.Transitions.Include(s => s.Titles).FirstOrDefault(f => f.Name == ITransaction.TransitionName)!.Titles!.FirstOrDefault(f => f.Language == language)!.Label)
               )
               {

               }).ToList())
               {
                   InstanceId = item.Id
               }
                   ).FirstOrDefault();

            response.RunningWorkflows = instanceRecords.Where(item => item.BaseStatus != StatusType.Completed).Select(item =>
      new GetRecordHistoryResponse.Workflow(item.WorkflowName, dbContext.InstanceTransitions.Where(w => w.InstanceId == item.Id).Select(ITransaction =>
      new GetRecordHistoryResponse.Transition(ITransaction.TransitionName!, ITransaction.FromStateName, ITransaction.ToStateName,
      ITransaction.StartedAt == null ? ITransaction.CreatedAt : ITransaction.StartedAt, ITransaction.FinishedAt,
       ITransaction.CreatedBy,
        dbContext.Transitions.Include(s => s.HistoryForms).FirstOrDefault(f => f.Name == ITransaction.TransitionName && f.HistoryForms != null && f.HistoryForms.Count() > 0) != null ?
                TemplateEngineFormWithoutJson(dbContext.Transitions.Include(s => s.Forms).FirstOrDefault(f => f.Name == ITransaction.TransitionName)!.HistoryForms.FirstOrDefault(f => f.Language == language)!.Label,
                 ITransaction.EntityData, templateURL,
                   dbContext.Transitions.Include(s => s.Titles).FirstOrDefault(f => f.Name == ITransaction.TransitionName)!.Titles!.FirstOrDefault(f => f.Language == language)!.Label) :
       dbContext.Transitions.Include(s => s.FromState).ThenInclude(t => t.Workflow).FirstOrDefault(f => f.Name == ITransaction.TransitionName)!.FromState!.Workflow!.HistoryForms != null
       && dbContext.Transitions.Include(s => s.FromState).ThenInclude(t => t.Workflow).FirstOrDefault(f => f.Name == ITransaction.TransitionName)!.FromState!.Workflow!.HistoryForms.Count() > 0 ?
       TemplateEngineFormWithoutJson(dbContext.Transitions.Include(s => s.FromState).ThenInclude(t => t.Workflow).FirstOrDefault(f => f.Name == ITransaction.TransitionName)!.FromState!.Workflow!.HistoryForms!.FirstOrDefault(f => f.Language == language)!.Label, ITransaction.EntityData, templateURL
       , dbContext.Transitions.Include(s => s.Titles).FirstOrDefault(f => f.Name == ITransaction.TransitionName)!.Titles!.FirstOrDefault(f => f.Language == language)!.Label) :

                TemplateEngineFormWithoutJson((dbContext.Transitions.Include(s => s.Forms).FirstOrDefault(f => f.Name == ITransaction.TransitionName))!.Forms.FirstOrDefault(f => f.Language == language)!.Label,
                 ITransaction.EntityData, templateURL
                 , dbContext.Transitions.Include(s => s.Titles).FirstOrDefault(f => f.Name == ITransaction.TransitionName)!.Titles!.FirstOrDefault(f => f.Language == language)!.Label)
                 )
      {

      }).ToList())
      {
          InstanceId = item.Id
      }
          ).ToList();
            response.CompletedWorkflows = instanceRecords.Where(item => item.BaseStatus == StatusType.Completed).Select(item =>
       new GetRecordHistoryResponse.Workflow(item.WorkflowName, dbContext.InstanceTransitions.Where(w => w.InstanceId == item.Id).Select(ITransaction =>
       new GetRecordHistoryResponse.Transition(ITransaction.TransitionName!, ITransaction.FromStateName, ITransaction.ToStateName,
       ITransaction.StartedAt == null ? ITransaction.CreatedAt : ITransaction.StartedAt, ITransaction.FinishedAt, ITransaction.CreatedBy,
          dbContext.Transitions.Include(s => s.Forms).FirstOrDefault(f => f.Name == ITransaction.TransitionName && f.HistoryForms != null && f.HistoryForms.Count() > 0) != null ?
                TemplateEngineFormWithoutJson(dbContext.Transitions.Include(s => s.Forms).FirstOrDefault(f => f.Name == ITransaction.TransitionName)!.HistoryForms.FirstOrDefault(f => f.Language == language)!.Label,
                 ITransaction.EntityData, templateURL, string.Empty) :
           dbContext.Transitions.Include(s => s.FromState).ThenInclude(t => t.Workflow).FirstOrDefault(f => f.Name == ITransaction.TransitionName)!.FromState!.Workflow!.HistoryForms != null
       && dbContext.Transitions.Include(s => s.FromState).ThenInclude(t => t.Workflow).FirstOrDefault(f => f.Name == ITransaction.TransitionName)!.FromState!.Workflow!.HistoryForms.Count() > 0 ?
       TemplateEngineFormWithoutJson(dbContext.Transitions.Include(s => s.FromState).ThenInclude(t => t.Workflow).FirstOrDefault(f => f.Name == ITransaction.TransitionName)!.FromState!.Workflow!.HistoryForms!.FirstOrDefault(f => f.Language == language)!.Label, ITransaction.EntityData, templateURL, string.Empty) :

                TemplateEngineFormWithoutJson((dbContext.Transitions.Include(s => s.Forms).FirstOrDefault(f => f.Name == ITransaction.TransitionName))!.Forms.FirstOrDefault(f => f.Language == language)!.Label,
                 ITransaction.EntityData, templateURL, string.Empty)
                 )
       {

       }).ToList())
       {
           InstanceId = item.Id
       }
           ).ToList();



        }
        catch (Exception ex)
        {
            return new Response<GetRecordHistoryResponse>
            {
                Result = new Result(Status.Error, "Unexpected Error:" + ex.ToString())
            };
        }
        return new Response<GetRecordHistoryResponse>
        {
            Data = response,
            Result = new Result(Status.Success, "Success")
        };

    }


    private static void postTransitionNoFlowNotInstance(Transition transition) { }
    private static void postTransitionNoFlowHasInstance(Transition transition) { }
    private static void postTransitionHasFlowHasInstance(Transition transition) { }
    private static void postTransitionHasFlowNoInstance(Transition transition) { }
}

// TODO : Move this objects to core project

public record GetRecordWorkflowAndTransitionsResponse
{
    public StateManagerWorkflow? StateManager { get; set; }
    public ICollection<RunningWorkflow>? RunningWorkflows { get; set; }
    public ICollection<Workflow>? AvailableWorkflows { get; set; }


    public record Workflow
    {
        public string? Name { get; set; }
        public string? Title { get; set; }
        public ICollection<Transition>? Transitions { get; set; }
        public dynamic? PublicForm { get; set; }
        public bool? IsPublicForm { get; set; }
    }

    public record StateManagerWorkflow : Workflow
    {
        public string? Status { get; set; }
    }

    public record RunningWorkflow : Workflow
    {
        public Guid InstanceId { get; set; }
    }

    public record Transition
    {
        public string? Name { get; set; }
        public string? Title { get; set; }
        public dynamic? Form { get; set; }
        public string? Type { get; set; }
    }
}

public record ConsumerPostTransitionResponse(
    string? newStatus,
    Dictionary<string, dynamic> fieldUpdates,
    string? signalRHub,
    string? signalRHubToken
    );



public record GetRecordHistoryResponse
{
    public Workflow? StateManager { get; set; }
    public ICollection<Workflow>? RunningWorkflows { get; set; }
    public ICollection<Workflow>? CompletedWorkflows { get; set; }

    public record Workflow
    {
        public Guid InstanceId { get; init; }
        public string Name { get; init; }
        public ICollection<Transition> Transitions { get; init; }

        public Workflow(string name, ICollection<Transition> transitions) => (Name, Transitions) = (name, transitions);
    }

    public record Transition
    {
        public string Name { get; init; }
        public string FromState { get; init; }
        public string ToState { get; init; }

        public DateTime? CalledAt { get; init; }
        public DateTime? FinishedAt { get; init; }
        public Guid CalledBy { get; init; }
        public string FormSchema { get; init; }
        public Transition(string name, string fromState, string toState, DateTime? calledAt, DateTime? finishedAt, Guid calledBy, string formSchema) => (Name, FromState, ToState, CalledAt, FinishedAt, CalledBy, FormSchema) = (name, fromState, toState, calledAt, finishedAt, calledBy, formSchema);
    }
}

public record GetRecordHistoryDetailResponse
{
    public ICollection<Transition> Transitions { get; set; }

    public GetRecordHistoryDetailResponse(ICollection<Transition> transitions) => (Transitions) = (transitions);


    public record Transition
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string FromState { get; init; }
        public string ToState { get; init; }
        public string FormSchema { get; init; }

        public ICollection<Event> Events { get; init; }

        public SubmitDataSet SubmitData { get; init; }
        public ResponseDataSet ResponseData { get; init; }

        public DateTime CalledAt { get; init; }
        public DateTime CompletedAt { get; init; }
        public Guid CalledBy { get; init; }

        public Transition(Guid id,
            string name,
            string fromState,
            string toState,
            string formSchema,
            ICollection<Event> events,
            SubmitDataSet submitData,
            ResponseDataSet responseData,
            DateTime ralledAt,
            DateTime completedAt,
            Guid calledBy
        ) => (Name, FromState, ToState, FormSchema, Events, SubmitData, ResponseData, CalledAt, CompletedAt, CalledBy) = (name, fromState, toState, formSchema, events, submitData, responseData, ralledAt, completedAt, calledBy);



        public record SubmitDataSet
        {
            public string? EntityData { get; init; }
            public string? FormData { get; init; }
            public string? AdditionalData { get; init; }
        }

        public record ResponseDataSet
        {
            public string? FieldUpdates { get; init; }
            public string? Status { get; init; }
        }

        public record Event
        {
            public Guid Id { get; init; }
            public string Name { get; init; }

            public DateTime ExecutedAt { get; init; }
            public int Duration { get; init; }

            public Dictionary<string, string>? InputData { get; init; }
            public Dictionary<string, string>? OutputData { get; init; }
            public Dictionary<string, string>? Details { get; init; }

            public Event(
                Guid id,
                string name,
                DateTime executedAt,
                int duration,
                Dictionary<string, string>? inputData,
                Dictionary<string, string>? outputData,
                Dictionary<string, string>? details
                ) => (Id, Name, ExecutedAt, Duration, InputData, OutputData, Details) = (id, name, executedAt, duration, inputData, outputData, details);
        }
    }
}