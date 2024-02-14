using amorphie.workflow.core.Constants;
using amorphie.workflow.core.Models.GatewayMessages;
using amorphie.workflow.redisconsumer.StreamObjects;
using Serilog;
using StackExchange.Redis;
using System.Text.Json;

namespace amorphie.workflow.redisconsumer.StreamExporters;
public class DeploymentExporter : BaseExporter, IExporter
{
    private static readonly Serilog.ILogger _logger = Log.ForContext<DeploymentExporter>();

    public DeploymentExporter(WorkflowDBContext dbContext, IDatabase redisDb, string consumerName) : base(dbContext, redisDb, consumerName)
    {
        this.streamName = ZeebeStreamKeys.DEPLOYMENT;
        this.groupName = ZeebeStreamKeys.DEPLOYMENT_GROUP;
        ConfigureGroup().Wait();
    }
    public override async Task DoBussiness(StreamEntry[] streamEntries, CancellationToken cancellationToken)
    {
        try
        {
            var messageToBeDeleted = new List<RedisValue>();
            foreach (var process in streamEntries)
            {
                var stream = Deserialize<DeploymentStream>(process);
                if (stream == null)
                {
                    continue;
                }
                var resourceName = stream.Value.Resources.FirstOrDefault()?.ResourceName ?? stream.Value.ProcessesMetadata.FirstOrDefault()?.ResourceName;

                var entity = dbContext.Deployments.FirstOrDefault(p => p.ResourceName == resourceName);
                if (entity != null)
                {
                    entity.Intent = stream.Intent;
                    entity.Version = stream.RecordVersion;
                    entity.BpmnProcessId = stream.Value.ProcessesMetadata.FirstOrDefault()?.BpmnProcessId ?? "";
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
        catch (Exception e)
        {
            _logger.Error($"{e}");
            throw;
        }
    }
    private Deployment StreamToEntity(DeploymentStream stream)
    {
        var deployment = new Deployment
        {
            BpmnProcessId = "",
            Intent = stream.Intent,
            Duplicate = stream.Value.Duplicate,
            Version = stream.Value.Version,
        };
        var resource = stream.Value.Resources.FirstOrDefault();
        deployment.Resource = resource?.Resource ?? "";
        deployment.ResourceName = resource?.ResourceName ?? "";
        return deployment;

    }
}

