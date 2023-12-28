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
    internal class MessageSubscriptionExporter :IExporter
    {
        public async Task Attach(IDatabase redisDb, CancellationToken cancellationToken)
        {
            
            if (!await redisDb.KeyExistsAsync(ZeebeStreamKeys.MESSAGE_SUBSCRIPTION) || (await redisDb.StreamGroupInfoAsync(ZeebeStreamKeys.MESSAGE_SUBSCRIPTION)).All(x => x.Name != ZeebeStreamKeys.MESSAGE_SUBSCRIPTION_GROUP))
            {
                await redisDb.StreamCreateConsumerGroupAsync(ZeebeStreamKeys.MESSAGE_SUBSCRIPTION, ZeebeStreamKeys.MESSAGE_SUBSCRIPTION_GROUP, "0-0", true);
            }

            string lastReadId = "-";
            var readTask = Task.Run(async () =>
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    //var result = await redisDb.StreamRangeAsync(streamName, lastReadId, "+", 1, Order.Ascending);
                    var result = await redisDb.StreamRangeAsync(ZeebeStreamKeys.MESSAGE_SUBSCRIPTION, lastReadId, "+");

                    //var result = await redisDb.StreamReadGroupAsync(streamName, groupName, "avg-1", ">");

                    if (result.Any())
                    {
                        lastReadId = result.Last().Id;
                        foreach (var process in result)
                        {
                            var value = process.Values[0].Value.ToString();
                            var stream = JsonSerializer.Deserialize<MessageSubscription>(value, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                            if (stream == null)
                            {
                                //ihtimal mi??
                                continue;
                            }

                            //DELETE ...
                            //CORRELATING
                            //CORRELATE
                            //CORRELATED
                            //bir event tamamlandığında yukarıdaki herbir aşama için kayıt oluşuyor. bizim için sonuncu yeterli
                            if (stream.Intent == "CORRELATED")
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
