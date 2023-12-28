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
        public async Task AttachToClean(ConnectionMultiplexer connectionMultiplexer, int timeToLive, CancellationToken cancellationToken)
        {


            var readTask = Task.Run(async () =>
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    var redisServers = connectionMultiplexer.GetServers();
                    var redisDb = connectionMultiplexer.GetDatabase();
                    foreach (var server in redisServers)
                    {
                        var allKeys = server.KeysAsync(pattern: "zeebe:");
                        await foreach (var key in allKeys)
                        {
                            //these keys handled in another way
                            if (key == ZeebeStreamKeys.PROCESS_INSTANCE || key == ZeebeStreamKeys.MESSAGE_START_EVENT_SUBSCRIPTION || key == ZeebeStreamKeys.MESSAGE_SUBSCRIPTION)
                            {
                                continue;
                            }

                            await redisDb.StreamTrimAsync(key, 10);

                        }

                    }
                    await Task.Delay(timeToLive * 1000);
                }
            });
            await readTask;
        }
    }
}
