using amorphie.core.security.Extensions;
using Dapr.Client;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var daprClient = new DaprClientBuilder().Build();

// builder.Services.AddDbContext<WorkflowDBContext>
//     ((options) =>
//     {
//         options.UseNpgsql("Host=localhost:5432;Database=workflow;Username=postgres;Password=postgres");
//     });
await builder.Configuration.AddVaultSecrets("workflow-secretstore", new string[] { "workflow-secretstore" });
var postgreSql = builder.Configuration["workflowdb"];
builder.Services.AddDaprClient();
builder.Logging.ClearProviders();
builder.Logging.AddJsonConsole();
builder.Services.AddEndpointsApiExplorer();

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

app.MapStateManagerEndpoints();

app.Run();
