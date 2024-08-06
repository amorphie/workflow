using System.Dynamic;
using amorphie.core.Base;
using amorphie.core.Enums;
using amorphie.workflow.core.Constants;
using Dapr.Client;
using amorphie.workflow.core.Extensions;
using System.Text.Json.Nodes;
namespace amorphie.workflow.service.Zeebe
{
    public interface IZeebeCommandService
    {
        Task<long> PublishMessage(string message, dynamic variables, string? correlationKey);
        Task<long> PublishMessage(string message, dynamic variables, string? correlationKey, string? gateway);
        Task<Result> ThrowError(string gateway, long processInstanceKey, long jobKey, string errorCode = "500", string errorMessage = "Bussines Error");
        Task<Result> SetErrorAsVariable(string gateway, long jobKey, string errorCode, string errorMessageString = "Bussines Error");

    }

    public class ZeebeCommandService : IZeebeCommandService
    {
        private DaprClient _daprClient { get; set; }

        public ZeebeCommandService(DaprClient daprClinet)
        {
            _daprClient = daprClinet;
        }

        public async Task<long> PublishMessage(string message, dynamic variables, string? correlationKey)
        {
            //TODO : Move gateway to environment
            string zeebeGateway = "workflow-zeebe-command";
            return await PublishMessage(message, variables, correlationKey, zeebeGateway);
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
                JsonObject messageResult = await _daprClient.InvokeBindingAsync<dynamic, JsonObject>(gateway, "publish-message", messageData);
                long responseValue = Convert.ToInt64(messageResult["key"].ToString());
                return responseValue;
            }
            catch (Exception)
            {
                throw new Exception("Zeebe is unresponsive");
            }
        }

        public async Task<Result> ThrowError(string gateway, long processInstanceKey, long jobKey, string errorCode, string errorMessage = "Bussines Error")
        {

            ThrowErrorRequest messageData = new(jobKey, errorCode, errorMessage);
            try
            {
                await SetErrorAsVariable(gateway, processInstanceKey, errorCode, errorMessage);
                await _daprClient.InvokeBindingAsync(gateway, ZeebeCommands.ThrowError, messageData);
                return new Result(Status.Success, "", "");
            }
            catch (Exception ex)
            {
                return new Result(Status.Error, $"Problem occurred while throwing the zeebe error. Original error: {errorCode} {errorMessage} -- ThrowError Exception: {ex.Message}");
            }

        }
        public async Task<Result> SetVariables(string gateway, long processInstanceKey, dynamic variables)
        {
            SetVariableRequest messageData = new(processInstanceKey, variables);
            try
            {
                await _daprClient.InvokeBindingAsync(gateway, ZeebeCommands.SetVariables, messageData);
                return new Result(Status.Success, "", "");
            }
            catch (Exception ex)
            {
                return new Result(Status.Error, $"Problem occurred while setting variables. Exception: {ex}");
            }

        }
        public async Task<Result> SetErrorAsVariable(string gateway, long processInstanceKey, string errorCode, string errorMessageString = "Bussines Error")
        {
            dynamic variables = new Dictionary<string, dynamic>();
            var errorMessage = errorMessageString.TryDeserialize();

            variables.Add("ThrownError", new { errorCode, errorMessage });

            SetVariableRequest messageData = new(processInstanceKey, variables);
            try
            {
                await _daprClient.InvokeBindingAsync(gateway, ZeebeCommands.SetVariables, messageData);
                return new Result(Status.Success, "", "");
            }
            catch (Exception ex)
            {
                return new Result(Status.Error, $"Problem occurred while setting error as variable. Original error: {errorCode} {errorMessageString} -- ThrowError Exception: {ex}");
            }

        }
        private record publishMessageResponse(long Key);
        private record publishMessageRequest(string MessageName, string CorrelationKey, string MessageId, string TimeToLive, dynamic Variables);
        private record ThrowErrorRequest(long JobKey, string ErrorCode, string ErrorMessage);
        private record SetVariableRequest(long ElementInstanceKey, dynamic Variables);
    }
}