using amorphie.workflow.core.Constants;
using amorphie.workflow.core.Models.GatewayMessages;
using amorphie.workflow.redisconsumer.StreamObjects;
using Serilog;
using StackExchange.Redis;

namespace amorphie.workflow.redisconsumer.StreamExporters;
public class VariableExporter : BaseExporter, IExporter
{
    private static readonly Serilog.ILogger _logger = Log.ForContext<VariableExporter>();

    public VariableExporter(WorkflowDBContext dbContext, IDatabase redisDb, string consumerName) : base(dbContext, redisDb, consumerName)
    {
        this.streamName = ZeebeStreamKeys.VARIABLE;
        this.groupName = ZeebeStreamKeys.VARIABLE_GROUP;
        ConfigureGroup().Wait();
    }
    public override async Task DoBussiness(StreamEntry[] streamEntries, CancellationToken cancellationToken)
    {
        try
        {
            var messageToBeDeleted = new List<RedisValue>();
            foreach (var process in streamEntries)
            {
                var stream = Deserialize<VariableStream>(process);

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
        catch (Exception e)
        {
            _logger.Error($"{e}");
            throw;
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

