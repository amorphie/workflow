﻿using amorphie.workflow.core.Constants;
using StackExchange.Redis;

namespace amorphie.workflow.redisconsumer.StreamExporters;

internal class MessageStartEventSubscriptionExporter : BaseMessageSubscriptionExporter, IExporter
{

    public MessageStartEventSubscriptionExporter(WorkflowDBContext dbContext, IDatabase redisDb, string consumerName) : base(dbContext, redisDb, consumerName)
    {
        this.streamName = ZeebeStreamKeys.MESSAGE_START_EVENT_SUBSCRIPTION;
        this.groupName = ZeebeStreamKeys.MESSAGE_START_EVENT_SUBSCRIPTION_GROUP;
        ConfigureGroup().Wait();
    }
}
