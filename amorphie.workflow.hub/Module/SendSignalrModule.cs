using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using amorphie.workflow.core.Dtos;
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
        Console.WriteLine("Hub veri gönderildi:" + data.eventInfo + " " + DateTime.Now);
        string jsonString = JsonSerializer.Serialize(data);
        // await hubContext.Clients.Group(data.UserId.ToString()).SendAsync("SendMessage", jsonString);
        await hubContext.Clients.All.SendAsync("SendMessage", jsonString);
        return Results.Ok("");
    }
    static async Task<IResult> SendMessagePublic(
     IHubContext<MFATypeHub> hubContext,
     SignalRRequest data,
      [FromHeader(Name = "X-Device-Id")] string? deviceId,
         [FromHeader(Name = "X-Token-Id")] string? tokenId
      )
    {
        Console.WriteLine("Public hub veri geldi:" + data.source + " device:" + deviceId + " " + "token:" + tokenId);
        SignalRResponsePublic response = ObjectMapper.Mapper.Map<SignalRResponsePublic>(data);
        response.time = DateTime.UtcNow;
        string jsonString = JsonSerializer.Serialize(data);
        await hubContext.Clients.Group(deviceId + tokenId).SendAsync("SendMessage", jsonString);
        return Results.Ok("");
    }
    static async Task<IResult> SendMessagePrivate(IHubContext<MFATypeHub> hubContext,
     SignalRRequest data,
     [FromHeader(Name = "A-Customer")] string? customer,
      [FromHeader(Name = "X-Device-Id")] string? deviceId,
      [FromHeader(Name = "X-Token-Id")] string? tokenId)
    {
        Console.WriteLine("Private hub veri geldi:" + data.source + " device:" + deviceId + " token:"
         + tokenId + " " + " customer:" + customer + DateTime.Now);
        SignalRResponsePublic response = ObjectMapper.Mapper.Map<SignalRResponsePublic>(data);
        response.time = DateTime.UtcNow;
        response.deviceId = deviceId;
        string jsonString = JsonSerializer.Serialize(data);
        await hubContext.Clients.Group(deviceId + tokenId + customer).SendAsync("SendMessage", jsonString);
        return Results.Ok("");
    }


}


