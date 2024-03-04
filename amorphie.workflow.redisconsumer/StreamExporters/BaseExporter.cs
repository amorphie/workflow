using amorphie.workflow.redisconsumer.StreamObjects;
using Serilog;
using StackExchange.Redis;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

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
            //Log.Information($"{this.GetType().Name} is constructed");
        }
        protected async Task ConfigureGroup()
        {
            // if (!await redisDb.KeyExistsAsync(streamName) ||
            //     (await redisDb.StreamGroupInfoAsync(streamName)).All(x => x.Name != groupName))
            // {
            //     await redisDb.StreamCreateConsumerGroupAsync(streamName, groupName, "0-0", true);
            // }
        }
        protected async Task<StreamPendingMessageInfo[]?> ReadPendingStreamGroupEntryAsync(CancellationToken cancellationToken)
        {
            StreamPendingMessageInfo[]? pendingInfos = await redisDb.StreamPendingMessagesAsync(streamName, groupName, 0, consumerName);
            return pendingInfos;
        }
        protected async Task<StreamEntry[]> ReadStreamGroupEntryAsync(CancellationToken cancellationToken)
        {
            return await redisDb.StreamReadGroupAsync(streamName, groupName, consumerName, StreamPosition.NewMessages, 0, CommandFlags.None);
        }

        protected async Task<long> AckMessagesAsync(List<RedisValue> messageToBeDeleted, CancellationToken cancellationToken)
        {
            if (messageToBeDeleted.Any())
                return await redisDb.StreamAcknowledgeAsync(streamName, groupName, messageToBeDeleted.ToArray());
            return 0;
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
        protected T? Deserialize<T>(StreamEntry streamEntry) where T : BaseStream
        {
            var value = streamEntry.Values[0].Value.ToString();
            return JsonSerializer.Deserialize<T>(value, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, Encoder = JavaScriptEncoder.Create(UnicodeRanges.All) });
        }

        public async Task Attach(CancellationToken cancellationToken)
        {
            // var result = await ReadStreamEntryAsync(cancellationToken);
            var result = await ReadStreamGroupEntryAsync(cancellationToken);
            await DoBussiness(result, cancellationToken);
        }

        public virtual Task DoBussiness(StreamEntry[] streamEntries, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }



    }
}
