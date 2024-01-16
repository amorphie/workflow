using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
namespace amorphie.workflow.hub
{
    public static class ClientRepo
    {
        public static Dictionary<string, string> ClientList = new Dictionary<string, string>();
    }
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

            string GroupName = await GetGroupName();

            ClientRepo.ClientList.Add(GroupName, Context.ConnectionId);

            await Groups.AddToGroupAsync(Context.ConnectionId, GroupName);
            _logger.LogInformation($"Client Connected: {Context.ConnectionId},GroupName : {GroupName}");
            return base.OnConnectedAsync();
        }
        public async override Task OnDisconnectedAsync(Exception? exception)
        {
            string GroupName = await GetGroupName();

            ClientRepo.ClientList.Remove(GroupName);

            _logger.LogInformation($"Client Disconnected: " + DateTime.UtcNow);
            _logger.LogInformation(exception?.ToString());

            await base.OnDisconnectedAsync(exception);
        }

        private async Task<string> GetGroupName()
        {
            var httpCtx = Context.GetHttpContext();
            string HeaderUser = string.Empty;
            string GroupName = string.Empty;

            string HeaderDeviceID = string.Empty;
            HeaderDeviceID = httpCtx.Request.Query["X-Device-Id"].ToString();
            if (string.IsNullOrEmpty(HeaderDeviceID))
            {
                HeaderDeviceID = httpCtx.Request.Query["x-device-id"].ToString();

            }
            if (string.IsNullOrEmpty(HeaderDeviceID))
            {
                throw new Exception("X-Device-Id can not be null");
            }
            string HeaderToken = string.Empty;
            HeaderToken = httpCtx.Request.Query["X-Token-Id"].ToString();
            if (string.IsNullOrEmpty(HeaderDeviceID))
            {
                HeaderToken = httpCtx.Request.Query["x-token-id"].ToString();
            }
            if (string.IsNullOrEmpty(HeaderToken))
            {
                throw new Exception("X-Token-Id can not be null");
            }

            return HeaderDeviceID + HeaderToken;
        }
    }

}