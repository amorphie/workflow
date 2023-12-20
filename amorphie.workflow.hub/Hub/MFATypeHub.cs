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
            _logger.LogInformation($"Client try to  Connect: {Context.ConnectionId}");
            var httpCtx = Context.GetHttpContext();
            string HeaderUser = string.Empty;
            string GroupName = string.Empty;
            try
            {
                HeaderUser = httpCtx.Request.Headers["A-Customer"].ToString();
                if (string.IsNullOrEmpty(HeaderUser))
                {
                    HeaderUser = httpCtx.Request.Headers["a-customer"].ToString();
                }

            }
            catch (Exception)
            {

            }
            string HeaderDeviceID = string.Empty;
            try
            {
                HeaderDeviceID = httpCtx.Request.Headers["X-Device-Id"].ToString();
                if (string.IsNullOrEmpty(HeaderDeviceID))
                {
                    HeaderDeviceID = httpCtx.Request.Headers["x-device-id"].ToString();

                }
            }
            catch (Exception)
            {

            }
            GroupName = HeaderDeviceID + HeaderUser;
            if (!string.IsNullOrEmpty(GroupName))
            {
                    Groups.AddToGroupAsync(Context.ConnectionId, GroupName);
                      _logger.LogInformation($"Client Connected: {Context.ConnectionId},GroupName : {GroupName}");
            }
            
            string HeaderToken = string.Empty;
            try
            {
                HeaderToken = httpCtx.Request.Headers["X-Token-Id"].ToString();
                if (string.IsNullOrEmpty(HeaderDeviceID))
                {
                    HeaderToken = httpCtx.Request.Headers["x-token-id"].ToString();
                }
                if (!string.IsNullOrEmpty(HeaderToken))
                {
                    GroupName = HeaderDeviceID + HeaderUser + HeaderToken;
                    Groups.AddToGroupAsync(Context.ConnectionId, GroupName);
                      _logger.LogInformation($"Client Connected: {Context.ConnectionId},GroupName : {GroupName}");
                }

            }
            catch (Exception)
            {

            }
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