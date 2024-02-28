using amorphie.core.Extension;
using amorphie.workflow.redisconsumer;
using Dapr.Client;
using Microsoft.EntityFrameworkCore;
using Serilog;
using StackExchange.Redis;
// Log.Logger = new LoggerConfiguration()

//     .CreateLogger();
var builder = WebApplication.CreateBuilder(args);

await builder.Configuration.AddVaultSecrets("workflow-secretstore", new[] { "workflow-secretstore" });

var postgreSql = builder.Configuration["workflowdb"];
var redisEndPoint = builder.Configuration["redisEndPoints"];


// Console.WriteLine("postgreSql " + postgreSql);
// Console.WriteLine("redisEndPoint " + redisEndPoint);
var configurationOptions = new ConfigurationOptions
{
    EndPoints =
    {
        redisEndPoint
    }
};
builder.Services.AddDaprClient();
builder.Services.AddSingleton<IDatabase>(cfg =>
{
    IConnectionMultiplexer multiplexer = ConnectionMultiplexer.Connect(configurationOptions);
    return multiplexer.GetDatabase();
});
builder.Services.AddDbContext<WorkflowDBContext>(options => options.UseNpgsql(postgreSql, b => b.MigrationsAssembly("amorphie.workflow.data")), ServiceLifetime.Singleton, ServiceLifetime.Singleton);

builder.Services.AddHostedService<BulkReadWorker>();
builder.Services.AddHostedService<StreamCleanerWorker>();

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
app.Logger.LogInformation("Starting Amorphie Workflow Redis Consumer application..." + postgreSql);
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


