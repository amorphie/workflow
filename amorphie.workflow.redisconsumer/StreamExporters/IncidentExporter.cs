using amorphie.workflow.core.Constants;
using amorphie.workflow.core.Dtos;
using amorphie.workflow.core.Models.GatewayMessages;
using amorphie.workflow.redisconsumer.StreamObjects;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using System.Text.Json;

namespace amorphie.workflow.redisconsumer.StreamExporters;
public class IncidentExporter : BaseExporter, IExporter
{
    public IncidentExporter(WorkflowDBContext dbContext, IDatabase redisDb, string consumerName) : base(dbContext, redisDb, consumerName)
    {
        this.streamName = ZeebeStreamKeys.INCIDENT;
        this.groupName = ZeebeStreamKeys.INCIDENT_GROUP;
        ConfigureGroup().Wait();
    }
    public async Task Attach(CancellationToken cancellationToken)
    {
        var result = await ReadStreamEntryAsync(cancellationToken);
        if (result.Any())
        {
            var messageToBeDeleted = new List<RedisValue>();
            foreach (var process in result)
            {
                var value = process.Values[0].Value.ToString();
                var stream = JsonSerializer.Deserialize<IncidentStream>(value, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                if (stream == null)
                {
                    continue;
                }

                var entity = dbContext.Incidents.FirstOrDefault(p => p.Key == stream.Key);
                if (entity != null)
                {
                    entity.ErrorMessage = stream.Value.ErrorMessage;
                    entity.ErrorType = stream.Value.ErrorType;
                    entity.Timestamp = stream.Timestamp;
                    dbContext.Incidents.Update(entity);
                }
                else
                {
                    entity = StreamToEntity(stream);
                    dbContext.Incidents.Add(entity);
                }

                var savingResult = await dbContext.SaveChangesAsync();
                if (savingResult > 0)
                {
                    messageToBeDeleted.Add(process.Id);
                    var message = stream.Value.ElementId == "NO_CATCH_EVENT_FOUND" ? "Wf has thrown error but there is not proper error event in wf " : " " + stream.Value.ErrorMessage;
                    var instanceGuid = RegisteredClients.ActiveInstanceList.TryGetValue(stream.Value.ProcessInstanceKey, out Guid instanceId) ? instanceId : Guid.Empty;
                    var hubData = new PostSignalRData(
                            Guid.Empty,
                            instanceGuid,
                            "exporter notifies about error " + stream.Value.ErrorType,
                            Guid.Empty,
                            stream.Value.ElementId ?? "",
                            "",
                            DateTime.Now,
                            stream.Intent,
                            "",
                            amorphie.core.Enums.StatusType.New,
                            new PostPageSignalRData("", "", new MultilanguageText("", ""), 1000),
                            message: message,
                            "",
                            "",
                            workflowName: stream.Value.BpmnProcessId ?? "",
                            "",
                            false,
                            buttonType: ""
                        );
                    if (RegisteredClients.ClientList.TryGetValue(stream.Value.ProcessInstanceKey, out WorkerBodyHeaders? bodyHeaders) && bodyHeaders != null)
                    {
                        await StateHelper.SendHubMessage(hubData, "eventInfo", "",
                        bodyHeaders.XDeviceId,
                        bodyHeaders.XTokenId,
                        bodyHeaders.ACustomer,
                        cancellationToken);
                    }
                    if (instanceId != Guid.Empty)
                    {
                        await UpdateInstanceBaseStatusToErrorAsync(instanceId);

                    }
                }
                messageToBeDeleted.Add(process.Id);
            }
            var deletedItemsCount = await DeleteMessagesAsync(messageToBeDeleted, cancellationToken);
        }
    }
    private Incident StreamToEntity(IncidentStream stream)
    {
        return new Incident
        {
            BpmnProcessId = stream.Value.BpmnProcessId,
            Key = stream.Key,
            Timestamp = stream.Timestamp,
            ErrorMessage = stream.Value.ErrorMessage,
            ErrorType = stream.Value.ErrorType,
            ElementId = stream.Value.ElementId,
            ElementInstanceKey = stream.Value.ElementInstanceKey,
            ProcessDefinitionKey = stream.Value.ProcessDefinitionKey,
            ProcessInstanceKey = stream.Value.ProcessInstanceKey,
        };
    }

    private async Task UpdateInstanceBaseStatusToErrorAsync(Guid instanceId)
    {
        Instance? instance = await dbContext.Instances.Where(i => i.Id == instanceId).FirstOrDefaultAsync();
        if (instance != null)
        {
            instance.BaseStatus = amorphie.core.Enums.StatusType.Error;
            await dbContext.SaveChangesAsync();
        }
    }
}

