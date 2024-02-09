
using amorphie.core.Extension;
using amorphie.workflow.hub;
using amorphie.workflow.hub.Module;
using Dapr.Client;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.EntityFrameworkCore;
using Serilog;


var builder = WebApplication.CreateBuilder(args);
//builder.Configuration.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", false, true);

var daprClient = new DaprClientBuilder().Build();
await builder.Configuration.AddVaultSecrets("workflow-secretstore", new[] { "workflow-secretstore" });
var postgreSql = builder.Configuration["workflowdb"];

builder.Services.AddControllers();
builder.Services.AddDaprClient();
builder.Logging.ClearProviders();
builder.Logging.AddJsonConsole();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.WithOrigins("*")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All;
    logging.RequestHeaders.Add("sec-ch-ua");
    logging.MediaTypeOptions.AddText("application/javascript");
    logging.RequestBodyLogLimit = 4096;
    logging.ResponseBodyLogLimit = 4096;
    logging.CombineLogs = true;
});
builder.Services.AddSignalR(options =>
{
    options.MaximumParallelInvocationsPerClient = 50;

});

builder.Services.AddHealthChecks();
builder.Services.AddMvc();
// var conf = builder.Configuration as IConfigurationRoot;
// Log.Logger = new LoggerConfiguration()
// .ReadFrom.Configuration(conf)
// .CreateLogger();

// //builder.Logging.ClearProviders();

// builder.Host.UseSerilog(Log.Logger, true);
builder.AddSeriLog();
builder.Services.AddDbContext<WorkflowDBContext>
    (options => options.UseNpgsql(postgreSql, b => b.MigrationsAssembly("amorphie.workflow.data")));
var app = builder.Build();
app.UseHttpLogging();
Log.Information("Amorphie Workflow Hub Starting");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.MapSubscribeHandler();
app.UseCors();
app.UseSwagger();
app.MapHealthChecks("/health");
app.UseSwaggerUI();
app.MapHub<WorkflowHub>("/hubs/workflow");
app.MapHub<MFATypeHub>("/hubs/genericHub");
app.MapSignalrEndpoints();
app.MapLongPoolingEndpoints();
app.Run();