using System.Text.Json;
using amorphie.workflow.core.Dtos;
using amorphie.workflow.core.Models.SignalR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace amorphie.workflow.hub.Module;

public static class SendSignalrModule
{
    public static void MapSignalrEndpoints(this WebApplication app)
    {
        app.MapPost("/sendMessage", SendMessage);
        app.MapPost("/sendMessage/public", SendMessagePublic);
        app.MapPost("/sendMessage/private", SendMessagePrivate);
    }
    static async Task<IResult> SendMessage(IHubContext<WorkflowHub> hubContext, PostSignalRData data)
    {
        string jsonString = JsonSerializer.Serialize(data);
        // await hubContext.Clients.Group(data.UserId.ToString()).SendAsync("SendMessage", jsonString);
        await hubContext.Clients.All.SendAsync("SendMessage", jsonString);
        return Results.Ok("");
    }
    static async Task<IResult> SendMessagePublic(
     IHubContext<MFATypeHub> hubContext,
     [FromServices] WorkflowDBContext dbContext,
     SignalRRequest data,
      CancellationToken cancellationToken,
      [FromHeader(Name = "X-Device-Id")] string? deviceId,
         [FromHeader(Name = "X-Token-Id")] string? tokenId,
         [FromHeader(Name = "X-Request-Id")] string? requestId
      )
    {
        SignalRResponsePublic response = ObjectMapper.Mapper.Map<SignalRResponsePublic>(data);
        response.time = DateTime.UtcNow;
        response.deviceId = deviceId;
        SignalRData dbData = ObjectMapper.Mapper.Map<SignalRData>(response);
        dbData.tokenId = tokenId;
        string jsonString = JsonSerializer.Serialize(data);
        await hubContext.Clients.Group(deviceId + tokenId).SendAsync("SendMessage", jsonString);
        SaveSignalRData(dbData, cancellationToken, dbContext);
        return Results.Ok("");
    }
    static async Task<IResult> SendMessagePrivate(IHubContext<MFATypeHub> hubContext,
      [FromServices] WorkflowDBContext dbContext,
     SignalRRequest data,
     CancellationToken cancellationToken,
     [FromHeader(Name = "A-Customer")] string? customer,
      [FromHeader(Name = "X-Device-Id")] string? deviceId,
      [FromHeader(Name = "X-Token-Id")] string? tokenId)
    {
        SignalRResponsePublic response = ObjectMapper.Mapper.Map<SignalRResponsePublic>(data);
        response.time = DateTime.UtcNow;
        response.deviceId = deviceId;

        SignalRData dbData = ObjectMapper.Mapper.Map<SignalRData>(response);
        dbData.tokenId = tokenId;
        string jsonString = JsonSerializer.Serialize(data);

        await hubContext.Clients.Group(deviceId + tokenId + customer).SendAsync("SendMessage", jsonString);
        SaveSignalRData(dbData, cancellationToken, dbContext);
        return Results.Ok("");
    }
    private static async Task SaveSignalRData(SignalRData data, CancellationToken cancellationToken, WorkflowDBContext dbContext)
    {
        await dbContext.SignalRResponses.AddAsync(data, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }



}