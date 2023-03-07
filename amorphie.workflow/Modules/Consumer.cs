
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

public static class ConsumerModule
{
    public static void MapConsumerEndpoints(this WebApplication app)
    {

        app.MapGet("/workflow/consumer/{entity}/record/{recordid}/transition", getTransitions)
           .Produces<GetRecordWorkflowAndTransitionsResponse>(StatusCodes.Status200OK)
           .WithOpenApi(operation =>
           {
               operation.Summary = "Returns available workflows and related transitions for given record.";
               operation.Tags = new List<OpenApiTag> { new() { Name = "Consumer BFF" } };

               return operation;
           });

        app.MapPost("/workflow/consumer/{entity}/record/{recordid}/transition/{transition}", postTransition)
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

        app.MapGet("/workflow/consumer/{entity-id}/record/{record-id}/history/", getHistory)
            .Produces<GetRecordHistoryResponse>(StatusCodes.Status200OK)
            .WithOpenApi(operation =>
            {
                operation.Summary = "Returns record workflow history.";
                operation.Tags = new List<OpenApiTag> { new() { Name = "Consumer BFF" } };

                return operation;
            });

        app.MapGet("/workflow/consumer/{entity-id}/record/{record-id}/history/{instance-id}", getHistoryDetail)
            .Produces<GetRecordHistoryDetailResponse>(StatusCodes.Status200OK)
            .WithOpenApi(operation =>
            {
                operation.Summary = "Return the instance with full detailed history.";
                operation.Tags = new List<OpenApiTag> { new() { Name = "Consumer BFF" } };

                return operation;
            });
    }

    static IResult getTransitions(
           [FromServices] WorkflowDBContext dbContext,
           [FromRoute(Name = "entity")] string entity,
           [FromRoute(Name = "recordId")] Guid recordId,
           [FromHeader(Name = "Accept-Language")] string language = "tr-TR"
       )
    {
        // load all workflows available to entity
        var workflows = dbContext.WorkflowEntities!
                .Where(e => e.Name == entity)
                .Include(e => e.Workflow)
                    .ThenInclude(w => w.Titles.Where(l => l.Language == language))
                .Include(e => e.Workflow)
                    .ThenInclude(w => w.States)
                    .ThenInclude(s => s.Titles.Where(l => l.Language == language))
                .Include(e => e.Workflow)
                    .ThenInclude(w => w.States)
                    .ThenInclude(s => s.Transitions)
                    .ThenInclude(t => t.Titles.Where(l => l.Language == language))
                .Include(e => e.Workflow)
                    .ThenInclude(w => w.States)
                    .ThenInclude(s => s.Transitions)
                    .ThenInclude(t => t.Forms.Where(l => l.Language == language))
                .ToList();

        var stateManagerWorkflow = workflows.Where(item => item.IsStateManager == true).FirstOrDefault();

        // load all active workflows of record.
        var instanceRecords = dbContext.Instances.Where(i => i.EntityName == entity && i.RecordId == recordId && i.BaseStatus != BaseStatusType.Completed).ToList();

        var response = new GetRecordWorkflowAndTransitionsResponse();
        //response.IsStateRecordRegistered = instanceRecords.Count > 0;

        if (stateManagerWorkflow != null)
        {
            var stateManagerInstace = instanceRecords.Where(i => i.WorkflowName == stateManagerWorkflow.Name).FirstOrDefault();

            if (stateManagerInstace != null)
            {

                response.StateManager = workflows.Where(item => item.IsStateManager == true).Select(item =>
                  new GetRecordWorkflowAndTransitionsResponse.StateManagerWorkflow
                  {
                      Name = item.Workflow.Name,
                      Title = item.Workflow.Titles.First().Label,
                      Status = stateManagerInstace.StateName,
                      Transitions = item.Workflow.States.FirstOrDefault(s => s.Name == stateManagerInstace.StateName)?.Transitions.Select(t =>
                          new GetRecordWorkflowAndTransitionsResponse.Transition
                          {
                              Name = t.Name,
                              Title = t.Titles.First().Label,
                              Form = t.Forms.First().Label
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
                       Transitions = item.Workflow.States.FirstOrDefault(s => s.Type == StateType.Start)!.Transitions!.Select(t =>
                           new GetRecordWorkflowAndTransitionsResponse.Transition
                           {
                               Name = t.Name,
                               Title = t.Titles.FirstOrDefault()==null?string.Empty: t.Titles.FirstOrDefault()!.Label,
                               Form = t.Forms.FirstOrDefault()==null?string.Empty:t.Forms.FirstOrDefault()!.Label
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
                    Transitions = item.Workflow.States.Where(s => s.Type == StateType.Start).First().Transitions.Select(t =>
                        new GetRecordWorkflowAndTransitionsResponse.Transition
                        {
                            Name = t.Name,
                            Title = t.Titles.First().Label,
                            Form = t.Forms.First().Label
                        }).ToArray()
                }
            ).ToArray();


        return Results.Ok(response);
    }

    static IResult postTransition(
            [FromServices] WorkflowDBContext dbContext,
            [FromHeader(Name = "User")] Guid user,
            [FromHeader(Name = "Behalf-Of-User")] Guid behalOfUser,
            [FromRoute(Name = "entity")] string entity,
            [FromRoute(Name = "recordId")] Guid recordId,
            [FromRoute(Name = "transition")] string transition,
            [FromBody] ConsumerPostTransitionRequest data,
            [FromServices] IPostTransactionService service
        )
    {
        var result = service.Init(entity, recordId, transition, user, behalOfUser, data);

        if (result == Results.Empty)
        {
            result = service.Execute();
        }

        return result;
    }


    static IResult getHistory(
         [FromRoute(Name = "entity-id")] Guid entityId,
         [FromRoute(Name = "record-id")] Guid recordId
     )
    {
        return Results.Ok();
    }


    static IResult getHistoryDetail(
         [FromRoute(Name = "entity-id")] Guid entityId,
         [FromRoute(Name = "record-id")] Guid recordId,
         [FromRoute(Name = "instance-id")] Guid instanceId
     )
    {
        return Results.Ok();
    }


    private static void postTransitionNoFlowNotInstance(Transition transition) { }
    private static void postTransitionNoFlowHasInstance(Transition transition) { }
    private static void postTransitionHasFlowHasInstance(Transition transition) { }
    private static void postTransitionHasFlowNoInstance(Transition transition) { }
}


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
        public string? Form { get; set; }
    }
}


public record ConsumerPostTransitionRequest
{

    public dynamic EntityData { get; set; } = default!;
    public dynamic? FormData { get; set; }
    public dynamic? AdditionalData { get; set; }
    public bool GetSignalRHub { get; set; }

}

public record ConsumerPostTransitionResponse(
    string? newStatus,
    Dictionary<string, dynamic> fieldUpdates,
    string? signalRHub,
    string? signalRHubToken
    );



public record GetRecordHistoryResponse
{
    public Workflow? StateManager { get; init; }
    public Workflow? RunningWorkflows { get; init; }
    public Workflow? CompletedWorkflows { get; init; }

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

        public DateTime CalledAt { get; init; }
        public Guid CalledBy { get; init; }

        public Transition(string name, string fromState, string toState, DateTime calledAt, Guid calledBy) => (Name, FromState, ToState, CalledAt, CalledBy) = (name, fromState, toState, calledAt, calledBy);
    }
}

public record GetRecordHistoryDetailResponse
{
    public string Name { get; init; }
    public ICollection<Transition> Transitions { get; init; }

    public GetRecordHistoryDetailResponse(string name, ICollection<Transition> transitions) => (Name, Transitions) = (name, transitions);


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

