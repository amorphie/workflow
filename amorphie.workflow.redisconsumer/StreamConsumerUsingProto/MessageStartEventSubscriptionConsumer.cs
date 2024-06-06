using System.Text.Json;
using System.Text.Json.Nodes;
using amorphie.workflow.core.Constants;
using amorphie.workflow.core.Dtos;
using amorphie.workflow.core.Models.Consumer;
using amorphie.workflow.redisconsumer.StreamExporters;
using Serilog;
using StackExchange.Redis;


namespace amorphie.workflow.redisconsumer.StreamConsumerUsingProto;
internal class MessageStartEventSubscriptionConsumer : BaseExporter, IExporter
{
    private static readonly Serilog.ILogger _logger = Log.ForContext<MessageStartEventSubscriptionConsumer>();
    public MessageStartEventSubscriptionConsumer(WorkflowDBContext dbContext, IDatabase redisDb, string consumerName) : base(dbContext, redisDb, consumerName)
    {
        this.streamName = ZeebeStreamKeys.Streams.MESSAGE_START_EVENT_SUBSCRIPTION;
        this.groupName = ZeebeStreamKeys.Groups.MESSAGE_START_EVENT_SUBSCRIPTION_GROUP;
        ConfigureGroup().Wait();
    }
    public override async Task DoBussiness(StreamEntry[] streamEntries, CancellationToken cancellationToken)
    {
        var messageToBeDeleted = new List<RedisValue>();
        string? currentProccessId = "";
        foreach (var process in streamEntries)
        {
            try
            {
                var record = Record.Parser.ParseFrom(process.Values.First().Value);
                var stream = record.Record_.Unpack<MessageStartEventSubscriptionRecord>();

                if (stream == null)
                {
                    continue;
                }
                currentProccessId = process.Id;

                //DELETE ...
                //CORRELATING
                //CORRELATE
                //CORRELATED
                //bir event tamamlandığında yukarıdaki herbir aşama için kayıt oluşuyor. bizim için sonuncu yeterli !
                //processInstanceKey => Zeebes process key
                //Variable-> InstanceId => amorphies id
                if (stream.Metadata.Intent == ZeebeEventKeys.CORRELATED || stream.Metadata.Intent == ZeebeEventKeys.CREATED)
                {
                    var entity = dbContext.MessageSubscriptions.FirstOrDefault(s => s.ProcessInstanceKey == stream.ProcessInstanceKey);
                    WorkerBody? workerBody = null;

                    if (entity != null)
                    {
                        entity.Intent = stream.Metadata.Intent;
                        entity.ModifiedAt = DateTime.UtcNow;
                        dbContext.MessageSubscriptions.Update(entity);
                        await dbContext.SaveChangesAsync();
                    }
                    else
                    {
                        //Start event triggered for the first time
                        entity = StreamToEntity(stream);
                        if (stream.Variables != null && stream.Variables.Fields.Count > 0)
                        {
                            var variables = stream.Variables;
                            var instanceId = variables.Fields.FirstOrDefault(p => p.Key == ZeebeVariableKeys.InstanceId).Value.StringValue;
                            var targetObject = variables.Fields.FirstOrDefault(p => p.Key == $"TRX{entity.MessageName?.DeleteUnAllowedCharecters()}").Value?.StructValue;

                            if (targetObject != null)
                            {
                                var createdBy = targetObject.Fields.FirstOrDefault(p => p.Key == ZeebeVariableKeys.TriggeredBy).Value.StringValue;
                                entity.CreatedBy = new Guid(createdBy ?? "");
                                var createdByBehalf = targetObject.Fields.FirstOrDefault(p => p.Key == ZeebeVariableKeys.TriggeredByBehalfOf).Value.StringValue;
                                entity.CreatedByBehalfOf = new Guid(createdByBehalf ?? "");
                            }
                            var guidParseResult = Guid.TryParse(instanceId, out Guid instanceGuid);
                            if (!guidParseResult)
                            {
                                continue;
                            }
                            entity.InstanceId = instanceGuid;
                            RegisterClient(stream.ProcessInstanceKey, instanceGuid, stream.Metadata.ValueType.ToString(), stream.Variables.Fields);

                            await dbContext.MessageSubscriptions.AddAsync(entity);
                            await dbContext.SaveChangesAsync();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                _logger.Error($"Exception while handling {currentProccessId} proccess id. Ex: {e}");
            }
        }
    }
    private void RegisterClient(long processInstanceKey, Guid instanceId, string? valueType, Google.Protobuf.Collections.MapField<string, Google.Protobuf.WellKnownTypes.Value> variablesFields)
    {
        var lastTransition = variablesFields.FirstOrDefault(p => p.Key == ZeebeVariableKeys.LastTransition).Value.StringValue.DeleteUnAllowedCharecters();
        if (lastTransition == null)
        {
            throw new InvalidDataException(message: $"{nameof(lastTransition)} LastTransition property must exist");
        }
        var bodyHeaders = variablesFields.FirstOrDefault(p => p.Key == "Headers").Value.StructValue.Fields;
        var workerBodyHeaders = CreateWorkerBodyHeaders(bodyHeaders);
        //Register user at start
        if (valueType != null)
        {
            RegisteredClients.ClientList.Add(processInstanceKey, workerBodyHeaders);
            RegisteredClients.ActiveInstanceList.Add(processInstanceKey, instanceId);
        }
    }

    private MessageSubscription StreamToEntity(MessageStartEventSubscriptionRecord stream)
    {
        return new MessageSubscription
        {
            BpmnProcessId = stream.BpmnProcessId,
            Key = stream.Metadata.Key,
            Timestamp = stream.Metadata.Timestamp,
            ValueType = stream.Metadata.ValueType.ToString(),
            Intent = stream.Metadata.Intent,
            CorrelationKey = stream.CorrelationKey,
            MessageName = stream.MessageName,
            MessageKey = stream.MessageKey,
            Position = stream.Metadata.Position,
            ProcessInstanceKey = stream.ProcessInstanceKey
        };
    }

    private WorkerBodyHeaders CreateWorkerBodyHeaders(Google.Protobuf.Collections.MapField<string, Google.Protobuf.WellKnownTypes.Value> headerPairs)
    {
        var bodyHeaders = new WorkerBodyHeaders
        {
            XTokenId = headerPairs.FirstOrDefault(p => p.Key == "xtokenid").Value?.StringValue,
            ACustomer = headerPairs.FirstOrDefault(p => p.Key == "acustomer").Value?.StringValue,
            XDeviceId = headerPairs.FirstOrDefault(p => p.Key == "xdeviceid").Value?.StringValue,
            user_reference = headerPairs.FirstOrDefault(p => p.Key == "user_reference").Value?.StringValue

        };
        return bodyHeaders;
        // headerPairs.TryGetValue("xtokenid", out bodyHeaders.XTokenId);
    }
}

