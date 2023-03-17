using System.IdentityModel.Tokens.Jwt;
using System.Security.Principal;
using System.Text;
using Dapr.Client;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.IdentityModel.Tokens;


var builder = WebApplication.CreateBuilder(args);
var daprClient = new DaprClientBuilder().Build();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDaprClient();
builder.Logging.ClearProviders();
builder.Logging.AddJsonConsole();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

byte[] JwtKey = Encoding.ASCII.GetBytes("thisissupersecretthisissupersecretthisissupersecrethisissupersecrett");
string JwtIssuer = "https://transaction.amorphie.burgan.com.tr/";
string JwtAudience = "https://transaction.amorphie.burgan.com.tr/";
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
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.Events = new JwtBearerEvents
    {
        OnMessageReceived = (context) =>
        {
            var accessToken = context.Request.Query["access_token"];

            var path = context.HttpContext.Request.Path;
            if (!string.IsNullOrEmpty(accessToken) &&
                (path.StartsWithSegments("/workflow")))
            {
                context.Token = accessToken;
            }
            return Task.CompletedTask;
        },
        OnTokenValidated = async context =>
        {
            var loggerFactory = context.HttpContext.RequestServices.GetRequiredService<ILoggerFactory>();
            var logger = loggerFactory.CreateLogger("JwtBearerEvents");
            logger.LogInformation($"Token validated{context}");
            logger.LogInformation($"Token validated{context.Principal?.Identity?.Name}");

            string? transactionId = context.Principal?.Identity?.Name;

            if (string.IsNullOrEmpty(transactionId))
            {
                context.Fail(new Exception("Token does not contain transaction id."));
                return;
            }

            var stateStoreName = builder.Configuration["DAPR_STATE_STORE_NAME"];
            var tokenStatus = await daprClient.GetStateAsync<GetTokenRequest>(stateStoreName, transactionId);
            tokenStatus.LastValidatedAt = DateTime.Now;
            await daprClient.SaveStateAsync<GetTokenRequest>(stateStoreName, transactionId, tokenStatus);

            return;
        }
    };

    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = JwtIssuer,
        ValidAudience = JwtAudience,
        IssuerSigningKey = new SymmetricSecurityKey(JwtKey),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true
    };
});
builder.Services.AddAuthorization();
builder.Services.AddSingleton<IUserIdProvider, NameUserIdProvider>();
builder.Services.AddSignalR();
builder.Services.AddMvc();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCloudEvents();
app.UseRouting();
app.MapSubscribeHandler();
app.UseSwagger();
app.UseSwaggerUI();
app.MapPost("/security/create-token",
[AllowAnonymous] async (GetTokenRequest data,HttpContext context,IConfiguration configuration) =>
{

    var loggerFactory = context.RequestServices.GetRequiredService<ILoggerFactory>();
    var logger = loggerFactory.CreateLogger("JwtBearerEvents");
    logger.LogInformation("Hub Create Token Started");
    var stateStoreName = configuration["DAPR_STATE_STORE_NAME"];
    logger.LogInformation("Hub Dapr State Retrieved");
    var tokenHandler = new JwtSecurityTokenHandler();
    var tokenDescriptor = new SecurityTokenDescriptor
    {
        // User and key of principal is Transaction ID forever.
        Subject = new GenericIdentity(data.InstanceId.ToString()),
        Issuer = JwtIssuer,
        Audience = JwtAudience,
        Claims = new Dictionary<string, object> {
            { "instanceId", data.InstanceId },
            { "definitionId", data.WorkflowEntity! },
            { "user", data.User },
            { "scope", data.Scope! },
            { "client", data.Client! },
            { "reference", data.Reference! } },
        Expires = DateTime.UtcNow.AddSeconds(3600),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(JwtKey), SecurityAlgorithms.HmacSha256Signature)
    };
    var token =string.Empty;

    try
    {
   token = tokenHandler.WriteToken(
        tokenHandler.CreateToken(tokenDescriptor)
        );
    }
    catch(Exception ex)
    {
        var test=ex.ToString();
    }
  


    await daprClient.SaveStateAsync<GetTokenRequest>(
        stateStoreName,
        data.InstanceId.ToString(),
        new GetTokenRequest { Token = token, InstanceId = data.InstanceId, WorkflowEntity = data.WorkflowEntity, Scope = data.Scope, Client = data.Client, User = data.User, Reference = data.Reference, TTL = data.TTL, ExpiryAt = tokenDescriptor.Expires },
        metadata: new Dictionary<string, string> { { "ttlInSeconds", $"{data.TTL}" } }
        );


    return Results.Ok(token);
});
app.MapPost("/workflow/publish-status",
[AllowAnonymous] async Task<IResult> (PostPublishStatusRequest data, IHubContext<WorkflowHub> hubContext) =>
{
    try
    {
    await hubContext.Clients.User(data.id.ToString()).SendAsync("on-status-changed", data.status, data.reason, data.details);

    }
    catch(Exception ex)
    {

    }


    return Results.Ok("");
});
app.MapHub<WorkflowHub>("/workflow/hub");
app.Run();
[Authorize]
public class WorkflowHub : Hub
{
    ILogger<WorkflowHub> _logger;


    public WorkflowHub(ILogger<WorkflowHub> logger)
    {
        _logger = logger;
    }
    public override Task OnConnectedAsync()
    {
        _logger.LogInformation($"Client Connected: {Context.ConnectionId}, user id : {Context?.User?.Identity?.Name}, user ident: {this.Context?.UserIdentifier}");
        return base.OnConnectedAsync();
    }

}

public class NameUserIdProvider : IUserIdProvider
{
    public string GetUserId(HubConnectionContext connection) => 
    (connection?.User?.Identity?.Name ?? "");
}