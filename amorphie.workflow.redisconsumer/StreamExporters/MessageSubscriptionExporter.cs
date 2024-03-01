using amorphie.workflow.core.Constants;
using StackExchange.Redis;

namespace amorphie.workflow.redisconsumer.StreamExporters;
internal class MessageSubscriptionExporter : BaseMessageSubscriptionExporter, IExporter
{
    public MessageSubscriptionExporter(WorkflowDBContext dbContext, IDatabase redisDb, string consumerName) : base(dbContext, redisDb, consumerName)
    {
        this.streamName = ZeebeStreamKeys.Streams.MESSAGE_SUBSCRIPTION;
        this.groupName = ZeebeStreamKeys.Groups.MESSAGE_SUBSCRIPTION_GROUP;
        ConfigureGroup().Wait();
    }
}

