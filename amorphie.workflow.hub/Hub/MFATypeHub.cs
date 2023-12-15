using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
namespace amorphie.workflow.hub
{
    public class MFATypeHub : Hub
    {
        ILogger<WorkflowHub> _logger;


        public MFATypeHub(ILogger<WorkflowHub> logger)
        {
            _logger = logger;
        }
        public override Task OnConnectedAsync()
        {
            _logger.LogInformation($"Client Connected: {Context.ConnectionId}, user id : {Context?.User?.Identity?.Name}, user ident: {this.Context?.UserIdentifier}");
            var httpCtx = Context.GetHttpContext();
            string HeaderUser =string.Empty;
            try
            {
                 HeaderUser = httpCtx.Request.Headers["A-Customer"].ToString();
                 
            }
            catch(Exception)
            {

            }
              string HeaderDeviceID =string.Empty;
            try
            {
                 HeaderDeviceID = httpCtx.Request.Headers["X-Device-Id"].ToString();
            }
            catch(Exception)
            {

            }
             string HeaderToken =string.Empty;
             try
            {
                 HeaderToken = httpCtx.Request.Headers["X-Token-Id"].ToString();
            }
            catch(Exception)
            {

            }
            string GroupName=HeaderDeviceID+HeaderUser+HeaderToken;
              
            Groups.AddToGroupAsync(Context.ConnectionId,GroupName);
            Clients.Group(HeaderUser).SendAsync("ClientConnected", "Client Connected");
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception? exception)
        {
            _logger.LogInformation($"Client Disconnected: " + DateTime.UtcNow);
            _logger.LogInformation(exception?.ToString());
            return base.OnDisconnectedAsync(exception);
        }

    }

}