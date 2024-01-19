using amorphie.workflow.core.Constants;
using amorphie.workflow.core.Models.GatewayMessages;
using amorphie.workflow.redisconsumer.StreamObjects;
using StackExchange.Redis;
using System.Text.Json;

namespace amorphie.workflow.redisconsumer.StreamExporters;

internal class MessageStartEventSubscriptionExporter : BaseExporter, IExporter
{

    public MessageStartEventSubscriptionExporter(WorkflowDBContext dbContext, IDatabase redisDb, string consumerName, string readingStrategy) : base(dbContext, redisDb, consumerName, readingStrategy)
    {
        this.streamName = ZeebeStreamKeys.MESSAGE_START_EVENT_SUBSCRIPTION;
        this.groupName = ZeebeStreamKeys.MESSAGE_START_EVENT_SUBSCRIPTION_GROUP;
        ConfigureGroup().Wait();
    }

    public async Task Attach(CancellationToken cancellationToken)
    {
        var result = await redisDb.StreamReadGroupAsync(streamName, groupName, this.consumerName, this.readingStrategy);
        if (result.Any())
        {
            var messageToBeDeleted = new List<RedisValue>();
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
                //processInstanceKey => Zeebes process key
                //Variable-> InstanceId => amorphies id
                if (stream.Intent == "CORRELATED" || stream.Intent == "CREATED")
                {
                    var entity = dbContext.MessageSubscriptions.FirstOrDefault(s => s.ProcessInstanceKey == stream.Value.ProcessInstanceKey);

                    if (entity != null)
                    {
                        entity.Intent = stream.Intent;
                        entity.ModifiedAt = DateTime.UtcNow;
                        dbContext.MessageSubscriptions.Update(entity);
                    }
                    else
                    {
                        entity = StreamToEntity(stream);
                        if (stream.Value.Variables != null)
                        {
                            var variables = stream.Value.Variables;
                            var targetObject = stream.Value.Variables[$"TRX-{entity.MessageName}"];
                            if (targetObject != null)
                            {
                                entity.CreatedBy = new Guid(targetObject[ZeebeVariableKeys.TriggeredBy]?.ToString() ?? "");
                                entity.CreatedByBehalfOf = new Guid(targetObject[ZeebeVariableKeys.TriggeredByBehalfOf]?.ToString() ?? "");
                            }
                            entity.InstanceId = variables[ZeebeVariableKeys.InstanceId]?.ToString() ?? "";
                        }
                        dbContext.MessageSubscriptions.Add(entity);
                    }
                    var savingResult = await dbContext.SaveChangesAsync();
                    if (savingResult > 0)
                    {
                        messageToBeDeleted.Add(process.Id);
                    }

                }
                else
                {
                    //delete the messages which have other Intent's
                    messageToBeDeleted.Add(process.Id);
                }

            }
            var deletedItemsCount = await redisDb.StreamDeleteAsync(streamName, messageToBeDeleted.ToArray());
        }
    }

    private MessageSubscription StreamToEntity(MessageStartEventSubscriptionStream stream)
    {
        return new MessageSubscription
        {
            BpmnProcessId = stream.Value.BpmnProcessId,
            Key = stream.Key,
            Timestamp = stream.Timestamp,
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
