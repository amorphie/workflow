using amorphie.workflow.core.Constants;
using amorphie.workflow.core.Models.GatewayMessages;
using amorphie.workflow.redisconsumer.StreamObjects;
using StackExchange.Redis;
using System.Text.Json;

namespace amorphie.workflow.redisconsumer.StreamExporters;
internal class MessageExporter : BaseExporter, IExporter
{

    string lastReadId;
    public MessageExporter(WorkflowDBContext dbContext, IDatabase redisDb, string consumerName, string readingStrategy) : base(dbContext, redisDb, consumerName, readingStrategy)
    {
        this.streamName = ZeebeStreamKeys.MESSAGE;
        this.groupName = ZeebeStreamKeys.MESSAGE_GROUP;
        ConfigureGroup().Wait();
    }
    public async Task Attach(CancellationToken cancellationToken)
    {
        var result = await ReadStreamEntryAsync(cancellationToken);

        if (result.Any())
        {
            var messageToBeDeleted = new List<RedisValue>();

            lastReadId = result.Last().Id;
            foreach (var process in result)
            {
                var value = process.Values[0].Value.ToString();
                var stream = JsonSerializer.Deserialize<MessageStream>(value, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                if (stream == null)
                {
                    //ihtimal mi??
                    continue;
                }

                //PUBLISHING,
                //PUBLISHED
                //DELETED
                //bir event tamamlandığında yukarıdaki herbir aşama için kayıt oluşuyor.
                if (stream.Intent == ZeebeEventKeys.PUBLISHED)
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
                        entity.InstanceId = variables[ZeebeVariableKeys.InstanceId]?.ToString() ?? "";


                    }
                    dbContext.Messages.Add(entity);
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
    private Message StreamToEntity(MessageStream stream)
    {
        return new Message
        {
            //BpmnProcessId = stream.Value.BpmnProcessId,
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

