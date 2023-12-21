using System.IdentityModel.Tokens.Jwt;
using System.Security.Principal;
using System.Text;
using System.Text.Json;
using amorphie.workflow.core.Dtos;
using amorphie.workflow.hub;
using amorphie.workflow.hub.Module;
using Dapr.Client;
using IdentityModel.AspNetCore.OAuth2Introspection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
var daprClient = new DaprClientBuilder().Build();

builder.Services.AddControllers();
builder.Services.AddDaprClient();
builder.Logging.ClearProviders();
builder.Logging.AddJsonConsole();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

// builder.Services.AddAuthentication(OAuth2IntrospectionDefaults.AuthenticationScheme)
//     .AddOAuth2Introspection(options =>
//     {
//         options.IntrospectionEndpoint = "http://localhost:3000/introspect";

//         options.ClientId = "ClientId";
//         options.ClientSecret = "ClientSecret";

//         options.SkipTokensWithDots = false;

//         options.Events = new OAuth2IntrospectionEvents
//         {
//             OnTokenValidated = async context =>
//             {
//                 var path = context.HttpContext.Request.Path;

//                 var accessToken = context.Request.Query["access_token"];

//                 if (!string.IsNullOrEmpty(accessToken) &&
//                     (path.StartsWithSegments("/hubs/")))
//                 {
//                     // Read the token out of the query string
//                     context.SecurityToken = accessToken;
//                 }
//                 await Task.CompletedTask;
//             }
//         };
//     });

builder.Services.AddAuthorization();
// builder.Services.AddSignalR();

builder.Services.AddSignalR().AddMessagePackProtocol();
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
app.UseCors();
app.UseSwagger();
app.UseSwaggerUI();

app.MapHub<WorkflowHub>("/hubs/workflow");
app.MapHub<MFATypeHub>("/hubs/genericHub");
app.MapSignalrEndpoints();
// app.MapPost("/sendMessage",

// async Task<IResult> (IHubContext <WorkflowHub> hubContext,PostSignalRData data) =>
// {
//     Console.WriteLine("Hub veri gönderildi:"+data.eventInfo+" " +DateTime.Now);
//       string jsonString = JsonSerializer.Serialize(data);
//      await hubContext.Clients.Group(data.UserId.ToString()).SendAsync("SendMessage", jsonString);
//    // await hubContext.Clients.All.SendAsync("SendMessage", jsonString);
//     return Results.Ok("");
// });

app.Use((context, next) =>
{
    Console.WriteLine("Middleware Header----------");
    foreach (var item in context.Request.Headers)
    {

        Console.WriteLine(item.Key + ":" + item.Value);
    }
    Console.WriteLine("---------------------");
    return next(context);
});

app.Run();