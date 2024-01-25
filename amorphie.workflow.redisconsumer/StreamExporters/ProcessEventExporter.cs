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
    internal class ProcessEventExporter : BaseExporter, IExporter
    {

        public ProcessEventExporter(WorkflowDBContext dbContext, IDatabase redisDb, string consumerName, string readingStrategy) : base(dbContext, redisDb, consumerName, readingStrategy)
        {
            this.streamName = ZeebeStreamKeys.PROCESS_EVENT;
            this.groupName = ZeebeStreamKeys.PROCESS_EVENT_GROUP;
            ConfigureGroup().Wait();
        }
        public async Task Attach(CancellationToken cancellationToken)
        {

            if (!(await redisDb.KeyExistsAsync(streamName)) ||
                (await redisDb.StreamGroupInfoAsync(streamName)).All(x => x.Name != groupName))
            {
                await redisDb.StreamCreateConsumerGroupAsync(streamName, groupName, "0-0", true);
            }
            var readTask = Task.Run(async () =>
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    var result = await ReadStreamEntryAsync(cancellationToken);

                    if (result.Any())
                    {
                        foreach (var process in result)
                        {
                            var value = process.Values[0].Value.ToString();
                            var entity = JsonSerializer.Deserialize<ProcessEventStream>(value, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                            if (entity == null)
                            {
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
