using System.Text.Json.Serialization;

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

app.MapDefinitionEndpoints();
app.MapInstanceEndpoints();

app.Run();

