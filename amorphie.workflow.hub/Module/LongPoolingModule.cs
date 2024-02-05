using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            app.MapPost("/longpooling/{instanceId}", LongPoolingGetLastData);


        }
        static async Task<IResult> LongPoolingGetLastData(
             [FromServices] WorkflowDBContext dbContext,
             [FromHeader(Name = "X-Device-Id")] string? deviceId,
         [FromHeader(Name = "X-Token-Id")] string? tokenId,
          [FromRoute(Name = "instanceId")] string instanceId,
                CancellationToken cancellationToken

         )
        {
            SignalRData? data = await dbContext.SignalRResponses.Where(w => w.InstanceId == instanceId && w.tokenId == tokenId && w.deviceId == deviceId)
            .OrderByDescending(o => o.CreatedAt).FirstOrDefaultAsync(cancellationToken);
            if (data == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(data);
        }
    }
}