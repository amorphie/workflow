using System.Dynamic;
using amorphie.workflow.core.Constants;
using Dapr.Client;
namespace amorphie.workflow.service.Zeebe
{
    public interface IZeebeCommandService
    {
        Task<long> PublishMessage(string message, dynamic variables, string? correlationKey, string? gateway);
        Task ThrowError(string gateway, long jobKey, string errorCode = "500", string errorMessage = "Bussines Error");

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
            catch (Exception ex)
            {
                var test = ex.ToString();
                Console.WriteLine(ex.ToString());
                return 0;
            }
        }

        public async Task ThrowError(string gateway, long jobKey, string errorCode, string errorMessage = "Bussines Error")
        {

            ThrowErrorRequest messageData = new(jobKey, errorCode, errorMessage);
            try
            {
                await _daprClient.InvokeBindingAsync(gateway, ZeebeCommands.ThrowError, messageData);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ThrowError Exception" + ex.ToString());
            }

        }
        private record publishMessageResponse(long Key);
        private record publishMessageRequest(string MessageName, string CorrelationKey, string MessageId, string TimeToLive, dynamic Variables);
        private record ThrowErrorRequest(long JobKey, string ErrorCode, string ErrorMessage);
    }
}