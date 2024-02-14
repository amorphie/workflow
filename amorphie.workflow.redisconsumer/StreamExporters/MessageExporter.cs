using amorphie.core.Base;
using amorphie.workflow.core.Constants;
using amorphie.workflow.core.Models.GatewayMessages;
using amorphie.workflow.redisconsumer.StreamObjects;
using Serilog;
using StackExchange.Redis;
using System.Text.Json;

namespace amorphie.workflow.redisconsumer.StreamExporters;
internal class MessageExporter : BaseExporter, IExporter
{
    private static readonly Serilog.ILogger _logger = Log.ForContext<MessageExporter>();

    public MessageExporter(WorkflowDBContext dbContext, IDatabase redisDb, string consumerName) : base(dbContext, redisDb, consumerName)
    {
        this.streamName = ZeebeStreamKeys.MESSAGE;
        this.groupName = ZeebeStreamKeys.MESSAGE_GROUP;
        ConfigureGroup().Wait();
    }
    public override async Task DoBussiness(StreamEntry[] streamEntries, CancellationToken cancellationToken)
    {
        try
        {
            var messageToBeDeleted = new List<RedisValue>();
            foreach (var process in streamEntries)
            {
                var stream = Deserialize<MessageStream>(process);
                if (stream == null)
                {
                    //ihtimal mi??
                    continue;
                }

                //PUBLISHING,
                //PUBLISHED
                //DELETED
                if (stream.Intent == ZeebeEventKeys.PUBLISHED)
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
            var deletedItemsCount = await DeleteMessagesAsync(messageToBeDeleted, cancellationToken);
        }
        catch (Exception e)
        {
            _logger.Error($"{e}");
            throw;
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

