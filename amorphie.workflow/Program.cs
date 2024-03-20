using System.Text.Json.Serialization;
using amorphie.workflow.core.Mapper;
using System.Reflection;
using amorphie.core.Extension;
using amorphie.core.Identity;
using FluentValidation;
using amorphie.workflow.core.ExceptionHandler;
using Microsoft.EntityFrameworkCore;
using amorphie.workflow.service.Zeebe;
using amorphie.workflow.Modules;
using amorphie.workflow;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using Elastic.Apm.NetCoreAll;
using Dapr.Client;
using amorphie.workflow.service.Db;
using amorphie.workflow.core.Token;

// DaprClient daprClient = new DaprClientBuilder()
//      //.UseHttpEndpoint("http://127.0.0.1:42010")
//      //.UseGrpcEndpoint("http://127.0.0.1:42011")
//     .Build();
var builder = WebApplication.CreateBuilder(args);
await builder.Configuration.AddVaultSecrets("workflow-secretstore", new[] { "workflow-secretstore" });

var postgreSql = builder.Configuration["workflowdb"];


builder.Services.AddScoped<IPostTransactionService, PostTransactionService>();
builder.Services.AddScoped<IZeebeCommandService, ZeebeCommandService>();

builder.Logging.ClearProviders();
builder.Services.AddHealthChecks();
builder.Logging.AddJsonConsole();
builder.Services.AddScoped<IBBTIdentity, FakeIdentity>();
//builder.Services.AddDaprClient();
builder.Services.AddDaprClient(conf => conf.UseJsonSerializationOptions(new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, PropertyNameCaseInsensitive = false, Encoder = JavaScriptEncoder.Create(UnicodeRanges.All) }));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.UseAllOfToExtendReferenceSchemas();
    c.UseAllOfForInheritance();
    c.UseOneOfForPolymorphism();
    c.CustomSchemaIds(s => s.FullName?.Replace("+", "."));

    // Add self documentation
    string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);

    // Add data documentation
    xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.data.xml";
    xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});
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
var assemblies = new Assembly[]
                {
                     typeof(PageComponentValidator).Assembly, typeof(PageComponentMapper).Assembly
                };

builder.Services.AddValidatorsFromAssemblies(assemblies);
builder.Services.AddAutoMapper(assemblies);
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
})
.AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddDbContext<WorkflowDBContext>
    (options => options.UseNpgsql(postgreSql, b => b.MigrationsAssembly("amorphie.workflow.data")));

//Add Bussiness Services
builder.Services.AddBussinessServices();

////Request and Response logging purpose
var headersToBeLogged = new List<string>
{
    "sec-ch-ua",
};
builder.AddSeriLogWithHttpLogging<WorkflowCustomEnricher>(headersToBeLogged);

var app = builder.Build();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
app.UseAllElasticApm(app.Configuration);
using var scope = app.Services.CreateScope();
var db = scope.ServiceProvider.GetRequiredService<WorkflowDBContext>();
db.Database.Migrate();
app.MapHealthChecks("/health");
app.UseExceptionMiddleware();

app.UseCloudEvents();
app.UseRouting();
app.MapSubscribeHandler();
app.UseCors();

//Configure the HTTP request pipeline.
if (!app.Environment.IsProduction())
{
    app.UseHttpLogging();
}
app.UseSwagger();
app.UseSwaggerUI();

app.MapDefinitionEndpoints();
app.MapInstanceEndpoints();
//V2 on heavy construction :)
app.MapDefinitionV2Endpoints();
app.MapInstanceV2Endpoints();
app.MapStateEndpoints();
app.MapMigrateModuleEndpoints();

app.MapConsumerEndpoints();
app.MapAuthorizeEndpoints();
try
{
    app.Logger.LogInformation("Starting Amorphie Workflow application...");
    app.AddRoutes();
    app.Run();
}
catch (Exception ex)
{
    app.Logger.LogCritical(ex, "Aplication is terminated unexpectedly ");
}
