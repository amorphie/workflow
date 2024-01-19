using amorphie.workflow.core.Constants;
using amorphie.workflow.core.Models.GatewayMessages;
using amorphie.workflow.redisconsumer.StreamObjects;
using StackExchange.Redis;
using System.Text.Json;

namespace amorphie.workflow.redisconsumer.StreamExporters;
public class IncidentExporter : BaseExporter, IExporter
{
    public IncidentExporter(WorkflowDBContext dbContext, IDatabase redisDb, string consumerName, string readingStrategy) : base(dbContext, redisDb, consumerName, readingStrategy)
    {
        this.streamName = ZeebeStreamKeys.INCIDENT;
        this.groupName = ZeebeStreamKeys.INCIDENT_GROUP;
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
                }
                messageToBeDeleted.Add(process.Id);
            }
            var deletedItemsCount = await redisDb.StreamDeleteAsync(streamName, messageToBeDeleted.ToArray());
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
            ProcessInstanceKey= stream.Value.ProcessInstanceKey,
        };
    }
}

