using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using amorphie.workflow.core.Constants;
using amorphie.workflow.core.Dtos;
using amorphie.workflow.core.Enums;
using amorphie.workflow.core.Models;
using amorphie.workflow.core.Models.SignalR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace amorphie.workflow.hub
{
    public static class LongPoolingModule
    {
        public static void MapLongPoolingEndpoints(this WebApplication app)
        {
            app.MapGet("/longpooling/{workflowName}", LongPoolingGetLastData);


        }
        static async Task<IResult> LongPoolingGetLastData(
             [FromServices] WorkflowDBContext dbContext,
             [FromQuery(Name = "instanceId")] string? instanceId,
             [FromHeader(Name = "X-Device-Id")] string? deviceId,
         [FromHeader(Name = "X-Token-Id")] string? tokenId,
          [FromRoute(Name = "workflowName")] string workflowName,
            [FromHeader(Name = "Accept-Language")] string? language,
                CancellationToken cancellationToken

         )
        {
            SignalRData? data = await dbContext.SignalRResponses.Where(w => w.InstanceId == instanceId && w.tokenId == tokenId && w.deviceId == deviceId
            && (w.subject == EventInfos.WorkerCompleted || w.subject == EventInfos.TransitionCompleted)
            && w.routeChange == true
            )
            .OrderByDescending(o => o.CreatedAt).FirstOrDefaultAsync(cancellationToken);

            SignalRResponsePublic dbData = new SignalRResponsePublic();
            if (data == null)
            {
                State? state = await dbContext.States.Include(s => s.Workflow).ThenInclude(s => s.Entities)
                .Where(s => s.WorkflowName == workflowName && s.Type == StateType.Start).FirstOrDefaultAsync(cancellationToken);

                if (state == null)
                    return Results.NotFound();
                if (string.IsNullOrEmpty(state.InitPageName))
                {
                    state.InitPageName = state.Name;
                }
                
                string eventInfo = EventInfos.WorkerCompleted;
                PostSignalRData postSignalRData = new PostSignalRData(
                             Guid.Empty,
                           Guid.Empty,
                          eventInfo,
                           Guid.Empty,
                           state.Workflow.Entities.FirstOrDefault()!.Name,
                         new { }, DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc),
                          state.Name, string.Empty, null, state.BaseStatus,
                         new PostPageSignalRData(
                              amorphie.workflow.core.Helper.EnumHelper.GetDescription<PageOperationType>(PageOperationType.Open),
                          amorphie.workflow.core.Helper.EnumHelper.GetDescription<NavigationType>(NavigationType.Push),
                           new MultilanguageText(language, state.InitPageName), 0),
                            string.Empty,
                             string.Empty,
                             new { },
                             workflowName, state.IsPublicForm == true ? "state" : "transition",
                              false,
                               TransitionButtonType.Forward.ToString()

                       );
                data = new SignalRData()
                {

                    source = "workflow",
                    type = "workflow",
                    subject = eventInfo,
                    InstanceId = string.Empty


                };
                dbData = ObjectMapper.Mapper.Map<SignalRResponsePublic>(data);
                dbData.data = postSignalRData;
                dbData.baseState = await BaseStateControl(dbContext,instanceId);
                return Results.Ok(dbData);
            }
            dbData.routeChange = null;

            dbData = ObjectMapper.Mapper.Map<SignalRResponsePublic>(data);
            try
            {
                dbData.baseState =await BaseStateControl(dbContext,instanceId);
            }
            catch (Exception)
            {
                dbData.baseState = core.Constants.StatusTypes.InProgress;
            }
            dbData.data = System.Text.Json.JsonSerializer.Deserialize<dynamic>(dbData.data);
            return Results.Ok(dbData);
        }
        private async static Task<string> BaseStateControl(WorkflowDBContext dbContext, string? instanceId)
        {
            Instance? instance = await dbContext.Instances.FirstOrDefaultAsync(f => f.Id.ToString() == instanceId);
            if (instance != null && instance.BaseStatus != amorphie.core.Enums.StatusType.LockedInFlow)
            {
                return core.Constants.StatusTypes.Completed;
            }
            if(instance==null)
            {
                return core.Constants.StatusTypes.New;
            }
            return core.Constants.StatusTypes.InProgress;

        }
    }
}