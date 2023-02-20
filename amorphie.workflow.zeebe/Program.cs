using Dapr.Client;

var builder = WebApplication.CreateBuilder(args);

var daprClient = new DaprClientBuilder().Build();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
