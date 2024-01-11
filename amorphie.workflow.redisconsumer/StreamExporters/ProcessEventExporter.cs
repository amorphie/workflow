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
    internal class ProcessEventExporter : IExporter
    {
        public async Task Attach(IDatabase redisDb, CancellationToken cancellationToken)
        {
            const string PROCESS_EVENT = "zeebe:PROCESS_EVENT";
            const string PROCESS_EVENT_GROUP = "PROCESS_EVENT_GROUP";
            if (!(await redisDb.KeyExistsAsync(PROCESS_EVENT)) ||
                (await redisDb.StreamGroupInfoAsync(PROCESS_EVENT)).All(x => x.Name != PROCESS_EVENT_GROUP))
            {
                await redisDb.StreamCreateConsumerGroupAsync(PROCESS_EVENT, PROCESS_EVENT_GROUP, "0-0", true);
            }

            string lastReadId = "-";
            var readTask = Task.Run(async () =>
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    //var result = await redisDb.StreamRangeAsync(PROCESS_INSTANCE, lastReadId, "+", 1, Order.Ascending);
                    var result = await redisDb.StreamRangeAsync(PROCESS_EVENT, lastReadId, "+");

                    //var result = await redisDb.StreamReadGroupAsync(PROCESS_INSTANCE, groupName, "avg-1", ">");

                    if (result.Any())
                    {
                        lastReadId = result.Last().Id;
                        foreach (var process in result)
                        {
                            var value = process.Values[0].Value.ToString();
                            var entity = JsonSerializer.Deserialize<ProcessEventStream>(value, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                            if (entity == null)
                            {
                                //ihtimal mi??
                                continue;
                            }
                            //TRIGGERING
                            //TRIGGERED
                            //bir event tamamlandığında yukarıdaki herbir aşama için kayıt oluşuyor.
                            if (entity.Intent == "TRIGGERING")
                            {

                            }
                            else if (entity.Intent == "TRIGGERED")
                            {

                            }
                        }
                    }
                    await Task.Delay(1000);
                }
            });
            await readTask;
        }
    }
}
