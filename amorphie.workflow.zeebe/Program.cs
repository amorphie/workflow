using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using amorphie.workflow.core.ExceptionHandler;
using amorphie.workflow.service.Zeebe;
using amorphie.workflow.zeebe.Modules;
using Dapr.Client;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Elastic.Apm.NetCoreAll;
using amorphie.workflow.service.Db;
using amorphie.core.Identity;
using amorphie.core.Extension;
using amorphie.workflow.core.Extensions;


var builder = WebApplication.CreateBuilder(args);

var daprClient = new DaprClientBuilder().Build();

await builder.Configuration.AddVaultSecrets("workflow-secretstore", new[] { "workflow-secretstore" });
var postgreSql = builder.Configuration["workflowdb"];
builder.Services.AddScoped<amorphie.core.Identity.IBBTIdentity, amorphie.core.Identity.FakeIdentity>();
//builder.Services.AddDaprClient();
builder.Services.AddDaprClient(conf => conf.UseJsonSerializationOptions(new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, PropertyNameCaseInsensitive = false, Encoder = JavaScriptEncoder.Create(UnicodeRanges.All) }));
builder.Logging.ClearProviders();
builder.Logging.AddJsonConsole();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IZeebeCommandService, ZeebeCommandService>();
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
builder.Services.AddSwaggerGen();

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

builder.Services.AddHealthChecks().AddNpgSql(postgreSql);
builder.Services.AddHttpClient("httpWorkerService")
.ConfigurePrimaryHttpMessageHandler((c) =>
     new HttpClientHandler()
     {
         ClientCertificateOptions = ClientCertificateOption.Manual,
         ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, cetChain, policyErrors) =>
             {
                 return true;
             }
     }
   );
builder.Services.Configure<ApiBehaviorOptions>(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    });
builder.Services.AddValidatorsFromAssemblyContaining<WorkerBodyValidator>(includeInternalTypes: true);

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
{
    options.SerializerOptions.PropertyNameCaseInsensitive = false;
    options.SerializerOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All);
});

////Request and Response logging purpose
builder.WfAddSeriLogWithHttpLogging<WorkflowLogEnricher>();

//builder.AddSeriLogWithHttpLogging<AmorphieLogEnricher>();

builder.Services.AddScoped<IBBTIdentity, FakeIdentity>();
//Add Bussiness Services
builder.Services.AddBussinessServices();
var app = builder.Build();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
if (!app.Environment.IsDevelopment())
{
    app.UseAllElasticApm(app.Configuration);
}
app.WfUseLoggingHandlerMiddlewares();
app.AddZeebeWorkerMiddleware(zeebeGateway: "workflow-zeebe-command");

using var scope = app.Services.CreateScope();
var db = scope.ServiceProvider.GetRequiredService<WorkflowDBContext>();
db.Database.Migrate();

app.UseCloudEvents();
app.UseRouting();
app.MapSubscribeHandler();
app.UseCors();


app.UseSwagger();
app.UseSwaggerUI();
app.MapHealthChecks("/health");
// app.UseWhen(context => context.Request.Path.StartsWithSegments("/amorphie-workflow"), appBuilder =>
// {
// });
app.MapStateManagerEndpoints();
app.MapHttpServiceManagerEndpoints();
app.MapAccountFlowManagerEndpoints();
app.MapExporterStateManagerEndpoints();
app.MapSimpleStateManagerManagerEndpoints();
app.Run();
