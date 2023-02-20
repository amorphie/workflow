using Dapr.Client;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var daprClient = new DaprClientBuilder().Build();

builder.Services.AddDbContext<WorkflowDBContext>
    ((options) =>
    {
        options.UseNpgsql("Host=localhost:5432;Database=workflow;Username=postgres;Password=postgres");
    });

builder.Services.AddDaprClient();
builder.Logging.ClearProviders();
builder.Logging.AddJsonConsole();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCloudEvents();
app.UseRouting();
app.MapSubscribeHandler();
app.UseSwagger();
app.UseSwaggerUI();

app.MapStateManagerEndpoints();

app.Run();
