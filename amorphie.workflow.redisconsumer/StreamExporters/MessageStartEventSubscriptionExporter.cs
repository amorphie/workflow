using amorphie.workflow.core.Constants;
using StackExchange.Redis;

namespace amorphie.workflow.redisconsumer.StreamExporters;

internal class MessageStartEventSubscriptionExporter : BaseMessageSubscriptionExporter, IExporter
{

    public MessageStartEventSubscriptionExporter(WorkflowDBContext dbContext, IDatabase redisDb, string consumerName, string readingStrategy) : base(dbContext, redisDb, consumerName, readingStrategy)
    {
        this.streamName = ZeebeStreamKeys.MESSAGE_START_EVENT_SUBSCRIPTION;
        this.groupName = ZeebeStreamKeys.MESSAGE_START_EVENT_SUBSCRIPTION_GROUP;
        ConfigureGroup().Wait();
    }
}
