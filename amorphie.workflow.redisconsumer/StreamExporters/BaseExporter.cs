using StackExchange.Redis;

namespace amorphie.workflow.redisconsumer.StreamExporters
{
    //public delegate void 
    public class BaseExporter
    {
        protected readonly WorkflowDBContext dbContext;
        protected readonly IDatabase redisDb;
        protected readonly string consumerName;
        protected string streamName;
        protected string groupName;
        protected readonly string readingStrategy;

        public BaseExporter(WorkflowDBContext dbContext, IDatabase redisDb, string consumerName, string readingStrategy)
        {
            this.dbContext = dbContext;
            this.redisDb = redisDb;
            this.consumerName = consumerName;
            this.readingStrategy = readingStrategy;

        }
        protected async Task ConfigureGroup()
        {
            // if (!await redisDb.KeyExistsAsync(streamName) ||
            //     (await redisDb.StreamGroupInfoAsync(streamName)).All(x => x.Name != groupName))
            // {
            //     await redisDb.StreamCreateConsumerGroupAsync(streamName, groupName, "0-0", true);
            // }
        }
        protected async Task<StreamEntry[]> ReadStreamEntryAsync(CancellationToken cancellationToken)
        {
            return await redisDb.StreamRangeAsync(streamName, 0, "+", 100, Order.Ascending);
        }


    }
}
