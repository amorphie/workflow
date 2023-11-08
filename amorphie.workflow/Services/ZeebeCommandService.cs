
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using Dapr.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;


public interface IZeebeCommandService
{
    Task<long> PublishMessage(string message, dynamic variables, string? correlationKey, string? gateway);
}


public class ZeebeCommandService : IZeebeCommandService
{
    private DaprClient _daprClinet { get; set; }

    public ZeebeCommandService(DaprClient daprClinet)
    {
        _daprClinet = daprClinet;
    }


    public async Task<long> PublishMessage(string message, dynamic variables, string? correlationKey, string? gateway)
    {

        dynamic messageData = new ExpandoObject();

        messageData.messageName = message;
        if (correlationKey is not null)
        {
            messageData.correlationKey = correlationKey;
        }

        messageData.variables = variables;
        try
        {
            var messageResult = await _daprClinet.InvokeBindingAsync<dynamic, dynamic>(gateway, "publish-message", messageData);
            return messageResult;
        }
        catch (Exception ex)
        {
            var test = ex.ToString();
            Console.WriteLine(ex.ToString());
            return 0;
        }

    }

    private record publishMessageResponse(long Key);
    private record publishMessageRequest(string MessageName, string CorrelationKey, string MessageId, string TimeToLive, dynamic Variables);
}