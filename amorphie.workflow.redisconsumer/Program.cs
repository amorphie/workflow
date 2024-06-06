using amorphie.core.Extension;
using amorphie.workflow.redisconsumer;
using Microsoft.EntityFrameworkCore;
using Serilog;
using StackExchange.Redis;
using amorphie.workflow.service.Db;
using amorphie.workflow.service.Zeebe;
using amorphie.workflow.service.Db.Abstracts;
var builder = WebApplication.CreateBuilder(args);

await builder.Configuration.AddVaultSecrets("workflow-secretstore", new[] { "workflow-secretstore" });

var postgreSql = builder.Configuration["workflowdb"];
var redisEndPoint = builder.Configuration["redisEndPoints"];
StateHelper.HubUrl = builder.Configuration["hubUrl"] ?? "";

builder.Services.AddDaprClient();
builder.Services.AddSingleton<IDatabase>(cfg =>
{
    IConnectionMultiplexer multiplexer = ConnectionMultiplexer.Connect(redisEndPoint);
    return multiplexer.GetDatabase();
});
builder.Services.AddDbContext<WorkflowDBContext>(options => options.UseNpgsql(postgreSql, b => b.MigrationsAssembly("amorphie.workflow.data")), ServiceLifetime.Singleton, ServiceLifetime.Singleton);

//builder.Services.AddHostedService<IndividiualReadWorker>();
//builder.Services.AddHostedService<StreamCleanerWorker>();


builder.Services.AddHostedService<IndividiualReadWorkerUsingProto>();


//Add Bussiness Services
builder.Services.AddSingleton<IZeebeCommandService, ZeebeCommandService>();
builder.Services.AddSingleton<IInstanceService, InstanceService>();
builder.Services.AddSingleton<IInstanceTransitionService, InstanceTransitionService>();


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Logging.ClearProviders();
builder.Host.UseSerilog((_, serviceProvider, loggerConfiguration) =>
        {
            loggerConfiguration
                .ReadFrom.Configuration(builder.Configuration);
        });
var app = builder.Build();
app.Logger.LogInformation("Starting Amorphie Workflow Redis Consumer application...");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.MapGet("/ping", () =>
{
    return "pong";
})
.WithName("ping");

app.Run();


