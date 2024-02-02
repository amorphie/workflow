using amorphie.workflow.core.Constants;
using StackExchange.Redis;

namespace amorphie.workflow.redisconsumer.StreamExporters;
internal class MessageSubscriptionExporter : BaseMessageSubscriptionExporter, IExporter
{
    public MessageSubscriptionExporter(WorkflowDBContext dbContext, IDatabase redisDb, string consumerName) : base(dbContext, redisDb, consumerName)
    {
        this.streamName = ZeebeStreamKeys.MESSAGE_SUBSCRIPTION;
        this.groupName = ZeebeStreamKeys.MESSAGE_SUBSCRIPTION_GROUP;
        ConfigureGroup().Wait();
    }
}

