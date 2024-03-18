using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using amorphie.workflow.core.Dtos;
using amorphie.workflow.core.Enums;
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
            && (w.subject == "worker-completed" || w.subject == "transition-completed")
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
                string eventInfo = "worker-completed";
                PostSignalRData postSignalRData = new PostSignalRData(
                             Guid.Empty,
                           Guid.Empty,
                          eventInfo,
                           Guid.Empty,
                           state.Workflow.Entities.FirstOrDefault()!.Name,
                         new { }, DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc),
                          state.Name, string.Empty,null, state.BaseStatus,
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
                //dbData.baseState="New";
                dbData.baseState=string.Empty;
                return Results.Ok(dbData);
            }
            dbData.routeChange = null;

            dbData = ObjectMapper.Mapper.Map<SignalRResponsePublic>(data);
            dbData.baseState="InProgress";
            try
            {
                PostSignalRData? postSignalRData = JsonSerializer.Deserialize<PostSignalRData>(dbData.data);
              State? state = await dbContext.States.FirstOrDefaultAsync(f=>f.Name==postSignalRData.state,cancellationToken);
              if(state!=null&&state.Type==StateType.Finish)
              {
                    dbData.baseState="Completed";
              }
            }
            catch (Exception)
            {
                 dbData.baseState="InProgress";
            }
            dbData.baseState=string.Empty;
            dbData.data = System.Text.Json.JsonSerializer.Deserialize<dynamic>(dbData.data);
            return Results.Ok(dbData);
        }
    }
}