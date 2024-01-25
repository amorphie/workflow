using amorphie.workflow.core.Constants;
using amorphie.workflow.core.Models.GatewayMessages;
using amorphie.workflow.redisconsumer.StreamObjects;
using StackExchange.Redis;
using System.Text.Json;

namespace amorphie.workflow.redisconsumer.StreamExporters;
public class DeploymentExporter : BaseExporter, IExporter
{
    public DeploymentExporter(WorkflowDBContext dbContext, IDatabase redisDb, string consumerName, string readingStrategy) : base(dbContext, redisDb, consumerName, readingStrategy)
    {
        this.streamName = ZeebeStreamKeys.DEPLOYMENT;
        this.groupName = ZeebeStreamKeys.DEPLOYMENT_GROUP;
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
                var stream = JsonSerializer.Deserialize<DeploymentStream>(value, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                if (stream == null)
                {
                    continue;
                }

                var entity = dbContext.Deployments.FirstOrDefault(p => p.Key == stream.Key);
                if (entity != null)
                {
                    entity.Intent = stream.Intent;
                    dbContext.Deployments.Update(entity);
                }
                else
                {
                    entity = StreamToEntity(stream);
                    dbContext.Deployments.Add(entity);
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
    private Deployment StreamToEntity(DeploymentStream stream)
    {
        return new Deployment
        {
            BpmnProcessId = stream.Value.BpmnProcessId,
            Key = stream.Key,
            Intent = stream.Intent,
            Duplicate = stream.Value.Duplicate,
            ResourceName = stream.Value.ResourceName,
            Version = stream.Value.Version,
        };
    }
}

