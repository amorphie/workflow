using Microsoft.AspNetCore.SignalR;
namespace amorphie.workflow.hub;
public class MFATypeHub : Hub
{
    ILogger<WorkflowHub> _logger;
    public MFATypeHub(ILogger<WorkflowHub> logger)
    {
        _logger = logger;
    }
    public async override Task<Task> OnConnectedAsync()
    {
        _logger.LogInformation($"Client try to  Connect: {Context.ConnectionId}");
        var httpCtx = Context.GetHttpContext();
        string HeaderDeviceID = httpCtx.Request.Query["X-Device-Id"].ToString();
        if (string.IsNullOrEmpty(HeaderDeviceID))
        {
            HeaderDeviceID = httpCtx.Request.Query["x-device-id"].ToString();
        }
        if (string.IsNullOrEmpty(HeaderDeviceID))
        {
            throw new Exception("X-Device-Id can not be null");
        }
        string HeaderToken = httpCtx.Request.Query["X-Token-Id"].ToString();
        if (string.IsNullOrEmpty(HeaderToken))
        {
            HeaderToken = httpCtx.Request.Query["x-token-id"].ToString();
        }
        if (string.IsNullOrEmpty(HeaderToken))
        {
            throw new Exception("X-Token-Id can not be null");
        }

        string GroupName = HeaderDeviceID + HeaderToken;
        await Groups.AddToGroupAsync(Context.ConnectionId, GroupName);
        return base.OnConnectedAsync();
    }
    public override Task OnDisconnectedAsync(Exception? exception)
    {
        _logger.LogInformation($"Client Disconnected: {Context.ConnectionId}, disconnect time: {DateTime.UtcNow}");
        _logger.LogInformation(exception?.ToString());
        return base.OnDisconnectedAsync(exception);
    }
}