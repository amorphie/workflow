using System.Drawing.Text;
using amorphie.workflow.hub.Metric;
using Microsoft.AspNetCore.SignalR;
namespace amorphie.workflow.hub;
public class MFATypeHub : Hub
{
    ILogger<WorkflowHub> _logger;
    IActiveUser _activeUser;
    public MFATypeHub(ILogger<WorkflowHub> logger, IActiveUser activeUser)
    {
       _logger = logger;

        _activeUser= activeUser;
    }
    public async override Task<Task> OnConnectedAsync()
    {
        _logger.LogInformation($"Client try to  Connect: {Context.ConnectionId}");

        (string HeaderDeviceID,string HeaderToken) = CheckQueryParams();

        string GroupName = HeaderDeviceID + HeaderToken;
        await Groups.AddToGroupAsync(Context.ConnectionId, GroupName);

        _activeUser.Increment();
        return base.OnConnectedAsync();
    }
    public override Task OnDisconnectedAsync(Exception? exception)
    {
         _activeUser.Decrement();
        _logger.LogInformation($"Client Disconnected: {Context.ConnectionId}, disconnect time: {DateTime.UtcNow}");
        _logger.LogInformation(exception?.ToString());
        return base.OnDisconnectedAsync(exception);
    }

private (string,string) CheckQueryParams()
{
       var param = Context.GetHttpContext().Request.Query;
        string HeaderDeviceID = param["X-Device-Id"].ToString();
        if (string.IsNullOrEmpty(HeaderDeviceID))
        {
            HeaderDeviceID = param["x-device-id"].ToString();
        }
        if (string.IsNullOrEmpty(HeaderDeviceID))
        {
            throw new Exception("X-Device-Id can not be null");
        }
        string HeaderToken = param["X-Token-Id"].ToString();
        if (string.IsNullOrEmpty(HeaderToken))
        {
            HeaderToken = param["x-token-id"].ToString();
        }
        if (string.IsNullOrEmpty(HeaderToken))
        {
            throw new Exception("X-Token-Id can not be null");
        }
        return (HeaderDeviceID,HeaderToken);
}
private (string,string) CheckHeaderParams()
{
       var param = Context.GetHttpContext().Request.Headers;
        string HeaderDeviceID = param["X-Device-Id"].ToString();
        if (string.IsNullOrEmpty(HeaderDeviceID))
        {
            HeaderDeviceID = param["x-device-id"].ToString();
        }
        if (string.IsNullOrEmpty(HeaderDeviceID))
        {
            throw new Exception("X-Device-Id can not be null");
        }
        string HeaderToken = param["X-Token-Id"].ToString();
        if (string.IsNullOrEmpty(HeaderToken))
        {
            HeaderToken = param["x-token-id"].ToString();
        }
        if (string.IsNullOrEmpty(HeaderToken))
        {
            throw new Exception("X-Token-Id can not be null");
        }
        return (HeaderDeviceID,HeaderToken);
}

}