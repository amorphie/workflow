﻿using amorphie.workflow.core.Constants;
using amorphie.workflow.core.Dtos;
using amorphie.workflow.core.Models.GatewayMessages;
using amorphie.workflow.redisconsumer.StreamObjects;
using StackExchange.Redis;
using System.Text.Json;

namespace amorphie.workflow.redisconsumer.StreamExporters;
internal class BaseMessageSubscriptionExporter : BaseExporter, IExporter
{
    public BaseMessageSubscriptionExporter(WorkflowDBContext dbContext, IDatabase redisDb, string consumerName) : base(dbContext, redisDb, consumerName)
    {
    }
    public async Task Attach(CancellationToken cancellationToken)
    {
        // var result = await redisDb.StreamReadGroupAsync(streamName, groupName, this.consumerName, this.readingStrategy);
        var result = await ReadStreamEntryAsync(cancellationToken);

        if (result.Any())
        {
            var messageToBeDeleted = new List<RedisValue>();
            foreach (var process in result)
            {
                var value = process.Values[0].Value.ToString();
                var stream = JsonSerializer.Deserialize<MessageSubscriptionStream>(value, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                if (stream == null)
                {
                    continue;
                }

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
                            var targetObject = stream.Value.Variables[$"TRX-{entity.MessageName}"];
                            if (targetObject != null)
                            {
                                entity.CreatedBy = new Guid(targetObject[ZeebeVariableKeys.TriggeredBy]?.ToString() ?? "");
                                entity.CreatedByBehalfOf = new Guid(targetObject[ZeebeVariableKeys.TriggeredByBehalfOf]?.ToString() ?? "");
                            }
                            entity.InstanceId = Guid.Parse(variables[ZeebeVariableKeys.InstanceId]?.ToString() ?? "").ToString();


                            workerBody = SetWrokerBody(entity, stream);

                            dbContext.MessageSubscriptions.Add(entity);
                        }
                    }
                    var savingResult = await dbContext.SaveChangesAsync();
                    if (savingResult > 0)
                    {
                        messageToBeDeleted.Add(process.Id);
                        if (workerBody != null)
                            await StateHelper.CallStateManager(workerBody, "default", entity.ProcessInstanceKey, cancellationToken);
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
    private WorkerBody? SetWrokerBody(MessageSubscription entity, MessageSubscriptionStream stream)
    {
        var variables = stream.Value.Variables;
        var targetObject = stream.Value.Variables[$"TRX-{entity.MessageName}"];
        var workerBody = new WorkerBody
        {
            InstanceId = Guid.Parse(entity.InstanceId),
            LastTransition = variables[ZeebeVariableKeys.LastTransition]?.ToString()


        };
        var bodyHeaders = stream.Value.Variables["Headers"];
        var workerBodyHeaders = bodyHeaders.Deserialize<WorkerBodyHeaders>(new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        //Register user at start
        if (stream.ValueType != null && ZeebeStreamKeys.MESSAGE_START_EVENT_SUBSCRIPTION.Contains(stream.ValueType))
        {
            RegisteredClients.ClientList.Add(entity.ProcessInstanceKey, workerBodyHeaders);
            RegisteredClients.ActiveInstanceList.Add(entity.ProcessInstanceKey, workerBody.InstanceId);
        }

        var workerBodyTrxDatas = targetObject.Deserialize<WorkerBodyTrxDatas>(new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        if (workerBodyTrxDatas?.Data?.SetStateVia != "exporter")
            return null;


        //Set users headers in order to claim at job notification stage

        workerBody.WorkerBodyTrxDataList.Add($"TRX{entity.MessageName}", workerBodyTrxDatas);
        workerBody.BodyHeaders = workerBodyHeaders;
        return workerBody;
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
            //ElementId = stream.Value.StartEventId,
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
        };
    }
}

