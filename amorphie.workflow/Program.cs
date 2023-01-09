using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);


builder.Logging.ClearProviders();
builder.Logging.AddJsonConsole();

builder.Services.AddDaprClient();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.UseAllOfToExtendReferenceSchemas();
    c.UseAllOfForInheritance();
    c.UseOneOfForPolymorphism();
});

builder.Services.AddControllers().AddJsonOptions(options =>
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

var app = builder.Build();


app.UseCloudEvents();
app.UseRouting();
app.MapSubscribeHandler();


app.UseSwagger();
app.UseSwaggerUI();

app.Logger.LogInformation("Registering Routes");

app.MapGet("/workflow/definition", () => { })
      .WithOpenApi(operation =>
      {
          operation.Summary = "Returns queried wortflow definitions.";
          return operation;
      })
      .Produces<GetWorkflowDefinition[]>(StatusCodes.Status200OK)
      .Produces(StatusCodes.Status204NoContent);

app.MapGet("/workflow/definition/{name}/states", () => { })
      .WithOpenApi(operation =>
      {
          operation.Summary = "Returns queried wortflows state and transition definitions.";
          return operation;
      })
      .Produces<GetStateDefinition[]>(StatusCodes.Status200OK)
      .Produces(StatusCodes.Status204NoContent);

app.MapPut("/workflow/instance/{name}", ([FromBody] PostInstanceRequest data) => { })
      .WithOpenApi(operation =>
      {
          operation.Summary = "Always creates a new instance of worklfow";
          return operation;
      })
      .Produces<PostInstanceResponse>(StatusCodes.Status200OK)
      .Produces(StatusCodes.Status204NoContent);


app.MapGet("/workflow/instance", (string? entity, Guid? entityId, GetInstanceType? filter) => { })
      .WithOpenApi(operation =>
      {
          operation.Summary = "Return requested workflow instance(s)";
          operation.Parameters[2].Description = "Enum :  All, Completed, Running, Suspended";


          return operation;
      })
      .Produces<GetInstanceResponse[]>(StatusCodes.Status200OK)
      .Produces(StatusCodes.Status204NoContent);


app.MapGet("/workflow/instance/{instance-id}", ([FromRoute(Name = "instance-id")] Guid instanceId) => { })
      .WithOpenApi(operation =>
      {
          operation.Summary = "Return requested workflow instance";
          return operation;
      })
      .Produces<GetInstanceResponse[]>(StatusCodes.Status200OK)
      .Produces(StatusCodes.Status204NoContent);


app.MapPatch("/workflow/instance/{instance-id}/transaction/{transition}", ([FromRoute(Name = "instance-id")] Guid instanceId, [FromRoute(Name = "transition")] string transition, [FromBody] PatchTransitionRequest data ) => { })
      .WithOpenApi(operation =>
      {
          operation.Summary = "Trigger transition of instance";
          return operation;
      })
      .Produces<PatchTransitionResponse>(StatusCodes.Status200OK)
      .Produces(StatusCodes.Status204NoContent);

app.MapGet("/workflow/instance/{instance-id}/event", ([FromRoute(Name = "instance-id")] Guid instanceId) => { })
      .WithOpenApi(operation =>
      {
          operation.Summary = "Return events of workflow instance";
          return operation;
      })
      .Produces<GetInstanceEventResponse[]>(StatusCodes.Status200OK)
      .Produces(StatusCodes.Status204NoContent);

app.Run();

