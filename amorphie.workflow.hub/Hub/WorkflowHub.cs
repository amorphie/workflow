using Microsoft.AspNetCore.SignalR;
namespace amorphie.workflow.hub;
    public class WorkflowHub : Hub
{
    ILogger<WorkflowHub> _logger;


    public WorkflowHub(ILogger<WorkflowHub> logger)
    {
        _logger = logger;
    }
    public override Task OnConnectedAsync()
    {
        _logger.LogInformation($"Client Connected: {Context.ConnectionId}, user id : {Context?.User?.Identity?.Name}, user ident: {this.Context?.UserIdentifier}");
        return base.OnConnectedAsync();
    }
    public override Task OnDisconnectedAsync(Exception? exception)
    {
        _logger.LogInformation($"Client Disconnected: " + DateTime.UtcNow);
        _logger.LogInformation(exception?.ToString());
        return base.OnDisconnectedAsync(exception);
    }

}