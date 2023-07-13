using System.Reflection;
using System.Text.Json.Serialization;
using amorphie.core.security.Extensions;
 //using amorphie.workflow;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
//using SecretExtensions;

var builder = WebApplication.CreateBuilder(args);
await builder.Configuration.AddVaultSecrets("workflow-secretstore",new string[]{"workflow-secretstore"});
var postgreSql = builder.Configuration["workflowdb"];


builder.Services.AddScoped<IPostTransactionService, PostTransactionService>();
builder.Services.AddScoped<IZeebeCommandService, ZeebeCommandService>();
//await builder.Configuration.AddVaultSecrets("user-secretstore", "user-secretstore");
//await builder.Configuration.AddVaultSecrets("user-secretstore", new string[] { "user-secretstore" });


//await builder.Configuration.AddVaultSecrets("workflow-secretstore", new string[] { "DatabaseConnections" });  

//var postgreSql = builder.Configuration["PostgreSql"];


// builder.Services.AddDbContext<WorkflowDBContext>
//     ((options) =>
//     {
//         //options.UseLazyLoadingProxies();
//         options.UseNpgsql("Host=localhost:5432;Database=workflow;Username=postgres;Password=postgres");
//     });

builder.Logging.ClearProviders();
builder.Logging.AddJsonConsole();

builder.Services.AddDaprClient();
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
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
})
.AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
;
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

app.Logger.LogInformation("Registering Routes");

app.MapDefinitionEndpoints();
app.MapInstanceEndpoints();
app.MapConsumerEndpoints();

app.Run();

