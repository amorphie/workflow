using amorphie.workflow.core.Constants;
using amorphie.workflow.core.Models.GatewayMessages;
using amorphie.workflow.redisconsumer.StreamObjects;
using StackExchange.Redis;
using System.Text.Json;

namespace amorphie.workflow.redisconsumer.StreamExporters;
internal class MessageSubscriptionExporter : BaseExporter, IExporter
{

    public MessageSubscriptionExporter(WorkflowDBContext dbContext, IDatabase redisDb, string consumerName, string readingStrategy) : base(dbContext, redisDb, consumerName, readingStrategy)
    {
        this.streamName = ZeebeStreamKeys.MESSAGE_SUBSCRIPTION;
        this.groupName = ZeebeStreamKeys.MESSAGE_SUBSCRIPTION_GROUP;
        ConfigureGroup().Wait();
    }
    public async Task Attach(CancellationToken cancellationToken)
    {

        var result = await redisDb.StreamReadGroupAsync(streamName, groupName, consumerName, ">");

        if (result.Any())
        {
            var messageToBeDeleted = new List<RedisValue>();
            foreach (var process in result)
            {
                var value = process.Values[0].Value.ToString();
                var stream = JsonSerializer.Deserialize<MessageSubscriptionStream>(value, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                if (stream == null)
                {
                    //ihtimal mi??
                    continue;
                }

                //DELETE ...
                //CORRELATING
                //CORRELATE
                //CORRELATED

                //Bu stream için aşağıdaki 2sine bakacaz
                //CREATE
                //CREATED
                //bir event tamamlandığında yukarıdaki herbir aşama için kayıt oluşuyor. bizim için sonuncu yeterli
                if (stream.Intent == "CORRELATED")
                {
                    var entity = StreamToEntity(stream);

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
    private MessageSubscription StreamToEntity(MessageSubscriptionStream stream)
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

