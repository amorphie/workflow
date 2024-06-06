using amorphie.core.Base;
using amorphie.workflow.core.Constants;
using amorphie.workflow.core.Dtos;
using amorphie.workflow.core.Models.Consumer;
using amorphie.workflow.redisconsumer.StreamObjects;
using Serilog;
using StackExchange.Redis;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace amorphie.workflow.redisconsumer.StreamExporters;
internal class BaseMessageSubscriptionExporter : BaseExporter, IExporter
{
    private static readonly Serilog.ILogger _logger = Log.ForContext<BaseMessageSubscriptionExporter>();
    public BaseMessageSubscriptionExporter(WorkflowDBContext dbContext, IDatabase redisDb, string consumerName) : base(dbContext, redisDb, consumerName)
    {
    }
    public override async Task DoBussiness(StreamEntry[] streamEntries, CancellationToken cancellationToken)
    {
        var messageToBeDeleted = new List<RedisValue>();
        string? currentProccessId = "";
        foreach (var process in streamEntries)
        {
            try
            {
                var stream = Deserialize<MessageSubscriptionStream>(process);
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
                if (stream.Intent == ZeebeEventKeys.CORRELATED || stream.Intent == ZeebeEventKeys.CREATED)
                {
                    var entity = dbContext.MessageSubscriptions.FirstOrDefault(s => s.ProcessInstanceKey == stream.Value.ProcessInstanceKey);
                    WorkerBody? workerBody = null;

                    if (entity != null)
                    {
                        entity.Intent = stream.Intent;
                        entity.ModifiedAt = DateTime.UtcNow;
                        dbContext.MessageSubscriptions.Update(entity);
                    }
                    else
                    {
                        //Start event triggered for the first time
                        entity = StreamToEntity(stream);
                        if (stream.Value.Variables != null)
                        {
                            var variables = stream.Value.Variables;
                            var targetObject = stream.Value.Variables[$"TRX{entity.MessageName?.DeleteUnAllowedCharecters()}"];
                            if (targetObject != null)
                            {
                                entity.CreatedBy = new Guid(targetObject[ZeebeVariableKeys.TriggeredBy]?.ToString() ?? "");
                                entity.CreatedByBehalfOf = new Guid(targetObject[ZeebeVariableKeys.TriggeredByBehalfOf]?.ToString() ?? "");
                            }
                            var guidParseResult = Guid.TryParse(variables[ZeebeVariableKeys.InstanceId]?.ToString(), out Guid instanceGuid);
                            if (!guidParseResult)
                            {
                                messageToBeDeleted.Add(process.Id);
                                continue;
                            }
                            entity.InstanceId = instanceGuid;
                            RegisterClient(stream.Value.ProcessInstanceKey, instanceGuid, stream.ValueType, stream.Value.Variables);

                            dbContext.MessageSubscriptions.Add(entity);
                        }
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
            catch (Exception e)
            {
                _logger.Error($"Exception while handling {currentProccessId} proccess id. Ex: {e}");
            }
        }
        //var deletedItemsCount = await DeleteMessagesAsync(messageToBeDeleted, cancellationToken);

    }
    private void RegisterClient(long processInstanceKey, Guid instanceId, string? valueType, JsonObject variables)
    {
        var lastTransition = variables[ZeebeVariableKeys.LastTransition]?.ToString().DeleteUnAllowedCharecters();
        if (lastTransition == null)
        {
            throw new InvalidDataException(message: $"{nameof(lastTransition)} LastTransition property must exist");
        }
        var bodyHeaders = variables["Headers"];
        var workerBodyHeaders = bodyHeaders.Deserialize<WorkerBodyHeaders>(new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        //Register user at start
        if (valueType != null && ZeebeStreamKeys.Streams.MESSAGE_START_EVENT_SUBSCRIPTION.Contains(valueType))
        {
            RegisteredClients.ClientList.Add(processInstanceKey, workerBodyHeaders);
            RegisteredClients.ActiveInstanceList.Add(processInstanceKey, instanceId);
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
            SourceRecordPosition = stream.SourceRecordPosition,
            Intent = stream.Intent,
            CorrelationKey = stream.Value.CorrelationKey,
            //ElementId = stream.Value.StartEventId,
            MessageName = stream.Value.MessageName,
            //Variables being processed in variable exporter no need to duplicate
            //Variables = stream.Value.Variables.ToJsonString(),
            MessageKey = stream.Value.MessageKey,
            Position = stream.Position,
            ProcessInstanceKey = stream.Value.ProcessInstanceKey
        };
    }
}

