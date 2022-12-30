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

app.MapGet("/workflow/definition/states", () => { })
      .WithOpenApi(operation =>
      {
          operation.Summary = "Returns queried wortflow definitions.";
          return operation;
      })
      .Produces<GetZeebeWorkflowDefinition>(StatusCodes.Status200OK)
      .Produces(StatusCodes.Status204NoContent);

app.Run();
