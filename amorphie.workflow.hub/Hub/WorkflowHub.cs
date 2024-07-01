using amorphie.workflow.hub.Metric;
using Microsoft.AspNetCore.SignalR;
namespace amorphie.workflow.hub;
    public class WorkflowHub : Hub
{
    ILogger<WorkflowHub> _logger;
    IActiveUser _activeUser;
    public WorkflowHub(ILogger<WorkflowHub> logger, IActiveUser activeUser)
    {
       _logger = logger;
        _activeUser= activeUser;
    }

    public override Task OnConnectedAsync()
    {
        _activeUser.Increment();
        _logger.LogInformation($"Client Connected: {Context.ConnectionId}, user id : {Context?.User?.Identity?.Name}, user ident: {this.Context?.UserIdentifier}");
        return base.OnConnectedAsync();
    }
    public override Task OnDisconnectedAsync(Exception? exception)
    {
          _activeUser.Decrement();
        _logger.LogInformation($"Client Disconnected: " + DateTime.UtcNow);
        _logger.LogInformation(exception?.ToString());
        return base.OnDisconnectedAsync(exception);
    }

}