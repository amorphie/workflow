using System.Dynamic;
using amorphie.core.Base;
using amorphie.core.Enums;
using amorphie.workflow.core.Constants;
using Dapr.Client;
using Microsoft.AspNetCore.Http;
namespace amorphie.workflow.service.Zeebe
{
    public interface IZeebeCommandService
    {
        Task<long> PublishMessage(string message, dynamic variables, string? correlationKey, string? gateway);
        Task<Result> ThrowError(string gateway, long jobKey, string errorCode = "500", string errorMessage = "Bussines Error");

    }

    public class ZeebeCommandService : IZeebeCommandService
    {
        private DaprClient _daprClient { get; set; }

        public ZeebeCommandService(DaprClient daprClinet)
        {
            _daprClient = daprClinet;
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
                var messageResult = await _daprClient.InvokeBindingAsync<dynamic, dynamic>(gateway, "publish-message", messageData);
                return messageResult;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public async Task<Result> ThrowError(string gateway, long jobKey, string errorCode, string errorMessage = "Bussines Error")
        {

            ThrowErrorRequest messageData = new(jobKey, errorCode, errorMessage);
            try
            {
                await _daprClient.InvokeBindingAsync(gateway, ZeebeCommands.ThrowError, messageData);
                return new Result(Status.Success, "", "");
            }
            catch (Exception ex)
            {
                return new Result(Status.Error, $"Problem occurred while thowing the zeebe error. Original error: {errorCode} {errorMessage} -- ThrowError Exception: {ex.Message}");
            }

        }
        private record publishMessageResponse(long Key);
        private record publishMessageRequest(string MessageName, string CorrelationKey, string MessageId, string TimeToLive, dynamic Variables);
        private record ThrowErrorRequest(long JobKey, string ErrorCode, string ErrorMessage);
    }
}