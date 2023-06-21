using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
namespace amorphie.workflow.hub
{
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

}

}