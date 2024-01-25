using amorphie.workflow.core.Constants;
using amorphie.workflow.redisconsumer.StreamObjects;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace amorphie.workflow.redisconsumer.StreamExporters
{
    /// <summary>
    ///after a specified time trim acked messages that we use
    ///and trim others 
    ///
    /// </summary>
    internal class StreamCleaner
    {
        public async Task TrimNotAttachedStream(IDatabase redisDb, int timeToLive, CancellationToken cancellationToken)
        {

            while (!cancellationToken.IsCancellationRequested)
            {
                await redisDb.StreamTrimAsync(ZeebeStreamKeys.PROCESS_EVENT, 10);
                await redisDb.StreamTrimAsync(ZeebeStreamKeys.VARIABLE_DOCUMENT, 10);
                //await redisDb.StreamTrimAsync(ZeebeStreamKeys.JOB, 10);
                await redisDb.StreamTrimAsync(ZeebeStreamKeys.JOB_BATCH, 10);

                await Task.Delay(timeToLive * 1000);
            }

        }
    }
}
