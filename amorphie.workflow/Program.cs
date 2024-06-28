using System.Text.Json.Serialization;
using amorphie.workflow.core.Mapper;
using System.Reflection;
using amorphie.core.Extension;
using amorphie.core.Identity;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using amorphie.workflow.service.Zeebe;
using amorphie.workflow.Modules;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using Elastic.Apm.NetCoreAll;
using amorphie.workflow.service.Db;
using amorphie.workflow;
using amorphie.core.Middleware.Logging;

var builder = WebApplication.CreateBuilder(args);
await builder.Configuration.AddVaultSecrets("workflow-secretstore", new[] { "workflow-secretstore" });

var postgreSql = builder.Configuration["workflowdb"];



builder.Services.AddScoped<IPostTransactionService, PostTransactionService>();
builder.Services.AddScoped<IZeebeCommandService, ZeebeCommandService>();

builder.Logging.ClearProviders();
// builder.Services.AddHealthChecks();,
builder.Services.AddHealthChecks().AddNpgSql(postgreSql);
builder.Logging.AddJsonConsole();
builder.Services.AddScoped<IBBTIdentity, FakeIdentity>();
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

//Add Bussiness Services
builder.Services.AddBussinessServices();

////Request and Response logging purpose
builder.AddSeriLogWithHttpLogging<AmorphieLogEnricher>();


var app = builder.Build();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

if (!app.Environment.IsDevelopment())
{
    app.UseAllElasticApm(app.Configuration);
}
app.UseLoggingHandlerMiddlewares();

using var scope = app.Services.CreateScope();
var db = scope.ServiceProvider.GetRequiredService<WorkflowDBContext>();
db.Database.Migrate();
app.MapHealthChecks("/health");

app.UseCloudEvents();
app.UseRouting();
app.MapSubscribeHandler();
app.UseCors();


app.UseSwagger();
app.UseSwaggerUI();

app.MapDefinitionEndpoints();
app.MapInstanceEndpoints();
app.MapStateEndpoints();
app.MapTransferModuleEndpoints();
app.MapComponentTransferModuleEndpoints();
app.MapHumanTaskModuleEndpoints();
app.MapAuthorizeEndpoints();
app.MapDMLEndpoints();
app.MapSchemaValidatorEndpoints();
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
