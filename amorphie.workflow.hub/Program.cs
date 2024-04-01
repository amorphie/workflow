
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using amorphie.core.Extension;
using amorphie.workflow.core.ExceptionHandler;
using amorphie.workflow.hub;
using amorphie.workflow.hub.Module;
using Dapr.Client;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Elastic.Apm.NetCoreAll;
using Microsoft.Extensions.Diagnostics.HealthChecks;

using HealthChecks.UI.Client;
using StackExchange.Redis;


var builder = WebApplication.CreateBuilder(args);
//builder.Configuration.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", false, true);

var daprClient = new DaprClientBuilder().Build();
await builder.Configuration.AddVaultSecrets("workflow-secretstore", new[] { "workflow-secretstore" });
var postgreSql = builder.Configuration["workflowdb"];
var redis = builder.Configuration["redisEndpointsWithoutComma"];
var signalrHealthAdress = builder.Configuration["signalrHealthAdress"];

builder.Services.AddControllers();
//builder.Services.AddDaprClient();
builder.Services.AddDaprClient(conf => conf.UseJsonSerializationOptions(new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, PropertyNameCaseInsensitive = false, Encoder = JavaScriptEncoder.Create(UnicodeRanges.All) }));
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


builder.AddSeriLogWithHttpLogging<WorkflowCustomEnricher>();

builder.Services.AddSignalR(options =>
{
    options.MaximumParallelInvocationsPerClient = 50;

})
.AddStackExchangeRedis(redis.ToString(), options => {
      options.Configuration.ChannelPrefix = "AmorphieWorkflowSignalR";
  })
;

builder.Services.AddHealthChecks().AddNpgSql(postgreSql).AddRedis(redis.ToString(),"Redis", HealthStatus.Unhealthy,null, TimeSpan.FromSeconds(15)).AddSignalRHub(signalrHealthAdress.ToString());;
builder.Services.AddMvc();

builder.Services.AddDbContext<WorkflowDBContext>
    (options => options.UseNpgsql(postgreSql, b => b.MigrationsAssembly("amorphie.workflow.data")));
var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseAllElasticApm(app.Configuration);
}
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
app.MapHealthChecks("/health",new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions{
    ResponseWriter=UIResponseWriter.WriteHealthCheckUIResponse
});
app.UseSwaggerUI();
app.MapHub<WorkflowHub>("/hubs/workflow");
app.MapHub<MFATypeHub>("/hubs/genericHub");
app.MapSignalrEndpoints();
app.MapLongPoolingEndpoints();
app.Run();