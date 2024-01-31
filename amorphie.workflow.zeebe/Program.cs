using amorphie.core.security.Extensions;
using amorphie.workflow.service.Zeebe;
using amorphie.workflow.zeebe.Modules;
using Dapr.Client;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var daprClient = new DaprClientBuilder().Build();

// builder.Services.AddDbContext<WorkflowDBContext>
//     ((options) =>
//     {
//         options.UseNpgsql("Host=localhost:5432;Database=workflow;Username=postgres;Password=postgres");
//     });
await builder.Configuration.AddVaultSecrets("workflow-secretstore", new[] { "workflow-secretstore" });
var postgreSql = builder.Configuration["workflowdb"];
builder.Services.AddDaprClient();
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
    (options => options.UseNpgsql(postgreSql, b => b.MigrationsAssembly("amorphie.workflow.data")));
builder.Services.AddHealthChecks();
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

var app = builder.Build();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
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
app.UseWhen(context => context.Request.Path.StartsWithSegments("/amorphie-workflow"), appBuilder =>
{
    app.AddZeebeWorkerMiddleware(zeebeGateway: "workflow-zeebe-command");
});
app.MapStateManagerEndpoints();
app.MapHttpServiceManagerEndpoints();
app.MapAccountFlowManagerEndpoints();
app.MapExporterStateManagerEndpoints();
app.Run();
