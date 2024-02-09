using amorphie.workflow.core.Constants;
using amorphie.workflow.core.Models.GatewayMessages;
using amorphie.workflow.redisconsumer.StreamObjects;
using StackExchange.Redis;
using System.Text.Json;

namespace amorphie.workflow.redisconsumer.StreamExporters;
public class VariableExporter : BaseExporter, IExporter
{
    public VariableExporter(WorkflowDBContext dbContext, IDatabase redisDb, string consumerName) : base(dbContext, redisDb, consumerName)
    {
        this.streamName = ZeebeStreamKeys.VARIABLE;
        this.groupName = ZeebeStreamKeys.VARIABLE_GROUP;
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
                var stream = JsonSerializer.Deserialize<VariableStream>(value, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                if (stream == null)
                {
                    continue;
                }

                var entity = dbContext.Variables.FirstOrDefault(p => p.Key == stream.Key);
                if (entity != null)
                {
                    entity.Value = stream.Value.Value;
                    dbContext.Variables.Update(entity);
                }
                else
                {
                    entity = StreamToEntity(stream);
                    dbContext.Variables.Add(entity);
                }

                var savingResult = await dbContext.SaveChangesAsync();
                if (savingResult > 0)
                {
                    messageToBeDeleted.Add(process.Id);
                }
                messageToBeDeleted.Add(process.Id);
            }
            var deletedItemsCount = await DeleteMessagesAsync(messageToBeDeleted, cancellationToken);
        }
    }
    private Variable StreamToEntity(VariableStream stream)
    {
        return new Variable
        {
            BpmnProcessId = stream.Value.BpmnProcessId,
            Key = stream.Key,
            Timestamp = stream.Timestamp,
            ProcessInstanceKey = stream.Value.ProcessInstanceKey,
            ProcessDefinitionKey = stream.Value.ProcessDefinitionKey,
            ScopeKey = stream.Value.ScopeKey,
            Name = stream.Value.Name,
            Value = stream.Value.Value,
        };
    }
}

