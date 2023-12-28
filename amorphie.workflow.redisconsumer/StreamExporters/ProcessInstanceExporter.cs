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
    internal class ProcessInstanceExporter : IExporter
    {
        public async Task Attach(IDatabase redisDb, CancellationToken cancellationToken)
        {
            const string PROCESS_INSTANCE = "zeebe:PROCESS_INSTANCE";
            const string PROCESS_INSTANCE_GROUP = "PROCESS_INSTANCE_GROUP";
            if (!(await redisDb.KeyExistsAsync(PROCESS_INSTANCE)) ||
                (await redisDb.StreamGroupInfoAsync(PROCESS_INSTANCE)).All(x => x.Name != PROCESS_INSTANCE_GROUP))
            {
                await redisDb.StreamCreateConsumerGroupAsync(PROCESS_INSTANCE, PROCESS_INSTANCE_GROUP, "0-0", true);
            }

            string lastReadId = "-";
            var readTask = Task.Run(async () =>
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    //var result = await redisDb.StreamRangeAsync(PROCESS_INSTANCE, lastReadId, "+", 1, Order.Ascending);
                    var result = await redisDb.StreamRangeAsync(PROCESS_INSTANCE, lastReadId, "+");

                    //var result = await redisDb.StreamReadGroupAsync(PROCESS_INSTANCE, groupName, "avg-1", ">");

                    if (result.Any())
                    {
                        lastReadId = result.Last().Id;
                        foreach (var process in result)
                        {
                            var value = process.Values[0].Value.ToString();
                            var entity = JsonSerializer.Deserialize<ProcessInstanceStream>(value, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                            if (entity == null)
                            {
                                //ihtimal mi??
                                continue;
                            }
                            //ELEMENT_ACTIVATING
                            //ELEMENT_ACTIVATED
                            //COMPLETE_ELEMENT
                            //ELEMENT_COMPLETING
                            //ELEMENT_COMPLETED
                            //bir event tamamlandığında yukarıdaki herbir aşama için kayıt oluşuyor. bizim için sonuncu yeterli
                            if (entity.Value.BpmnElementType == "START_EVENT" && entity.Intent == "ELEMENT_COMPLETED")
                            {

                            }
                            else if (entity.Value.BpmnElementType == "INTERMEDIATE_CATCH_EVENT" && entity.Intent == "ELEMENT_COMPLETED")
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
