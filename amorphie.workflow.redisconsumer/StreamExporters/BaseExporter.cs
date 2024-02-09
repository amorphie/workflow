using Serilog;
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

        public BaseExporter(WorkflowDBContext dbContext, IDatabase redisDb, string consumerName)
        {
            this.dbContext = dbContext;
            this.redisDb = redisDb;
            this.consumerName = consumerName;
            Log.Information($"{this.GetType().Name} is constructed");
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
        protected async Task<long> DeleteMessagesAsync(List<RedisValue> messageToBeDeleted, CancellationToken cancellationToken)
        {
            if (messageToBeDeleted.Any())
                return await redisDb.StreamDeleteAsync(streamName, messageToBeDeleted.ToArray());
            return 0;
        }



    }
}
