
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
using amorphie.core.Middleware.Logging;
using Prometheus;

using HealthChecks.UI.Client;
using StackExchange.Redis;
using amorphie.workflow.hub.Metric;
using amorphie.workflow.core.Extensions;



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

builder.WfAddSeriLogWithHttpLogging<WorkflowLogEnricher>();

//builder.AddSeriLogWithHttpLogging<AmorphieLogEnricher>();

builder.Services.AddSignalR(options =>
{
    options.ClientTimeoutInterval = TimeSpan.FromSeconds(30); // Example client timeout
    options.KeepAliveInterval = TimeSpan.FromSeconds(10); // Example keep-alive interval
    options.EnableDetailedErrors = true;
})
.AddMessagePackProtocol()
.AddStackExchangeRedis(redis.ToString(), options =>
{
    options.Configuration.ChannelPrefix = RedisChannel.Literal("amorphie-workflow-hub");
})
;

builder.Services.AddHealthChecks().AddNpgSql(postgreSql).AddRedis(redis.ToString(), "Redis", HealthStatus.Unhealthy, null, TimeSpan.FromSeconds(15)).AddSignalRHub(signalrHealthAdress.ToString()); ;
builder.Services.AddMvc();

builder.Services.AddDbContext<WorkflowDBContext>
    (
        options =>
        {
            options.UseNpgsql(postgreSql, b => b.MigrationsAssembly("amorphie.workflow.data"));
            if (!(builder.Environment.IsProd() || builder.Environment.IsProduction()))
            {
                options.EnableSensitiveDataLogging(true);
            }
        }
    );

builder.Services.AddSingleton<IActiveUser, PrometheusActiveUser>();

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseAllElasticApm(app.Configuration);
}

app.WfUseLoggingHandlerMiddlewares();

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
app.MapHealthChecks("/health", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.UseHttpMetrics();
app.MapMetrics();


app.UseSwaggerUI();
app.MapHub<WorkflowHub>("/hubs/workflow");
app.MapHub<MFATypeHub>("/hubs/genericHub");
app.MapSignalrEndpoints();
app.MapLongPoolingEndpoints();
app.Run();