using System.Drawing.Text;
using amorphie.workflow.hub.Metric;
using Elastic.Apm.Api;
using Microsoft.AspNetCore.SignalR;
namespace amorphie.workflow.hub;
public class MFATypeHub : Hub
{
    ILogger<WorkflowHub> _logger;
    IActiveUser _activeUser;
    private ITransaction transaction;
    public MFATypeHub(ILogger<WorkflowHub> logger, IActiveUser activeUser)
    {
        transaction = Elastic.Apm.Agent.Tracer.CurrentTransaction ?? Elastic.Apm.Agent.Tracer.StartTransaction("MFATypeHub", ApiConstants.TypeUnknown);
        _logger = logger;

        _activeUser = activeUser;
    }
    public async override Task<Task> OnConnectedAsync()
    {
        _logger.LogInformation($"Client try to  Connect: {Context.ConnectionId}");
        transaction.SetLabel("ConnectionId", Context.ConnectionId);

        (string HeaderDeviceID, string HeaderToken) = CheckHeaderParams();

        string GroupName = HeaderDeviceID + HeaderToken;
        await Groups.AddToGroupAsync(Context.ConnectionId, GroupName);

        _activeUser.Increment();
        return base.OnConnectedAsync();
    }
    public override Task OnDisconnectedAsync(Exception? exception)
    {
        transaction.SetLabel("Headers", string.Join(',', Context.GetHttpContext().Request.Headers.Select(p => p.Key + " : " + p.Value)));
        _activeUser.Decrement();
        if (exception == null)
        {
            _logger.LogInformation($"Client Disconnected: {Context.ConnectionId}, disconnect time: {DateTime.UtcNow}");

        }
        else
        {
            _logger.LogError(exception, "Client Disconnected deu to exception: {ConnectionId}, disconnect time: {DateTime} ", Context.ConnectionId, DateTime.UtcNow);
        }
        _logger.LogInformation(exception?.ToString());
        return base.OnDisconnectedAsync(exception);
    }

    private (string, string) CheckQueryParams()
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
        return (HeaderDeviceID, HeaderToken);
    }
    private (string, string) CheckHeaderParams()
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
        transaction.SetLabel("Headers", string.Join(',', param.Select(p => p.Key + " : " + p.Value)));
        return (HeaderDeviceID, HeaderToken);
    }

}