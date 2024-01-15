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
builder.Services.AddHealthChecks();
builder.Services.AddSignalR();
builder.Services.AddMvc();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.MapSubscribeHandler();
app.UseCors();
app.UseSwagger();
app.MapHealthChecks("/health");
app.UseSwaggerUI();
app.MapHub<WorkflowHub>("/hubs/workflow");
app.MapHub<MFATypeHub>("/hubs/genericHub");
app.MapSignalrEndpoints();

app.Run();