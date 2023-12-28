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
    internal class MessageStartEventSubscriptionExporter : IExporter
    {
        private readonly WorkflowDBContext dbContext;
        private readonly string consumerName;
        public MessageStartEventSubscriptionExporter(WorkflowDBContext dbContext, string consumerName)
        {
            this.dbContext = dbContext;
            this.consumerName = consumerName;
        }


        public async Task Attach(IDatabase redisDb, CancellationToken cancellationToken)
        {

            if (!await redisDb.KeyExistsAsync(ZeebeStreamKeys.MESSAGE_START_EVENT_SUBSCRIPTION) || (await redisDb.StreamGroupInfoAsync(ZeebeStreamKeys.MESSAGE_START_EVENT_SUBSCRIPTION)).All(x => x.Name != ZeebeStreamKeys.MESSAGE_START_EVENT_SUBSCRIPTION_GROUP))
            {
                await redisDb.StreamCreateConsumerGroupAsync(ZeebeStreamKeys.MESSAGE_START_EVENT_SUBSCRIPTION, ZeebeStreamKeys.MESSAGE_START_EVENT_SUBSCRIPTION_GROUP, "0-0", true);
            }

            string lastReadId = "-";
            List<RedisValue> messageToBeDeleted = new List<RedisValue>();
            var readTask = Task.Run(async () =>
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    //var result = await redisDb.StreamRangeAsync(streamName, lastReadId, "+", 1, Order.Ascending);
                    //var result = await redisDb.StreamRangeAsync(MESSAGE_START_EVENT_SUBSCRIPTION, lastReadId, "+");

                    var result = await redisDb.StreamReadGroupAsync(ZeebeStreamKeys.MESSAGE_START_EVENT_SUBSCRIPTION, ZeebeStreamKeys.MESSAGE_START_EVENT_SUBSCRIPTION_GROUP, this.consumerName, ">");

                    if (result.Any())
                    {
                        lastReadId = result.Last().Id;
                        //messageToBeDeleted = result.Select(p => p.Id).ToList();
                        foreach (var process in result)
                        {
                            var value = process.Values[0].Value.ToString();
                            var stream = JsonSerializer.Deserialize<MessageStartEventSubscriptionStream>(value, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                            if (stream == null)
                            {
                                //ihtimal mi??
                                continue;
                            }

                            //DELETE ...
                            //CORRELATING
                            //CORRELATE
                            //CORRELATED
                            //bir event tamamlandığında yukarıdaki herbir aşama için kayıt oluşuyor. bizim için sonuncu yeterli !
                            if (stream.Intent == "CORRELATED")
                            {
                                var entity = StreamToEntity(stream);
                                entity.RedisId = process.Id;

                                if (stream.Value.Variables != null)
                                {
                                    var variables = stream.Value.Variables;
                                    var targetObject = stream.Value.Variables[$"TRX-{entity.MessageName}"];
                                    if (targetObject != null)
                                    {
                                        entity.CreatedBy = new Guid(targetObject[ZeebeVariableKeys.TriggeredBy]?.ToString() ?? "");
                                        entity.CreatedByBehalfOf = new Guid(targetObject[ZeebeVariableKeys.TriggeredByBehalfOf]?.ToString() ?? "");
                                    }
                                    entity.InstanceId = variables[ZeebeVariableKeys.TriggeredBy]?.ToString() ?? "";


                                }
                                dbContext.MessageSubscriptions.Add(entity);
                                var savingResult = await dbContext.SaveChangesAsync();
                                if (savingResult > 0)
                                {
                                    messageToBeDeleted.Add(entity.RedisId);
                                }

                            }

                        }
                    }

                    var deletedItemsCount = await redisDb.StreamDeleteAsync(ZeebeStreamKeys.MESSAGE_START_EVENT_SUBSCRIPTION, messageToBeDeleted.ToArray());
                    await Task.Delay(1000);
                }
            });
            await readTask;
        }

        private MessageSubscription StreamToEntity(MessageStartEventSubscriptionStream stream)
        {
            return new MessageSubscription
            {
                BpmnProcessId = stream.Value.BpmnProcessId,
                Key = stream.Key, //Element specific
                Timestamp = stream.Timestamp,//Event created time in long format
                ValueType = stream.ValueType,
                BrokerVersion = stream.BrokerVersion,
                SourceRecordPosition = stream.SourceRecordPosition,
                Intent = stream.Intent,
                CorrelationKey = stream.Value.CorrelationKey,
                ElementId = stream.Value.StartEventId,
                MessageName = stream.Value.MessageName,
                Variables = stream.Value.Variables.ToJsonString(),
                MessageKey = stream.Value.MessageKey,
                Position = stream.Position,
                ProcessInstanceKey = stream.Value.ProcessInstanceKey,
                ProcessDefinitionKey = stream.Value.ProcessDefinitionKey,
                RecordType = stream.RecordType,
                RecordVersion = stream.RecordVersion,
                RejectionType = stream.RejectionType,
                RejectionReason = stream.RejectionReason,
                //TenantId=stream.Value.TenantId
            };
        }
    }
}
