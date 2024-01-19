using amorphie.core.Base;
using amorphie.workflow.redisconsumer.StreamObjects;
using StackExchange.Redis;
using System.Text.Json;

namespace amorphie.workflow.redisconsumer.StreamExporters;
public delegate EntityBase StreamToEntityHandler(BaseStream redisStream);
    public class GenericExporter<TEntity> where TEntity : EntityBase 
    {

        private readonly WorkflowDBContext dbContext;
        private readonly IDatabase redisDb;
        private readonly string streamName;
        private readonly string groupName;
        private StreamToEntityHandler streamToEntityHandler;
        public GenericExporter(WorkflowDBContext dbContext, IDatabase redisDb, string streamName, string groupName)
        {
            this.dbContext = dbContext;
            this.streamName = streamName;
            this.groupName = groupName;
            this.redisDb = redisDb;
        }
        public async Task Attach( CancellationToken cancellationToken)
        {
            if (!(await redisDb.KeyExistsAsync(streamName)) ||
                (await redisDb.StreamGroupInfoAsync(streamName)).All(x => x.Name != groupName))
            {
                await redisDb.StreamCreateConsumerGroupAsync(streamName, groupName, "0-0", true);
            }

            string lastReadId = "-";

                    //var result = await redisDb.StreamRangeAsync(PROCESS_INSTANCE, lastReadId, "+", 1, Order.Ascending);
                    var result = await redisDb.StreamRangeAsync(streamName, lastReadId, "+");


                    if (result.Any())
                    {
                        var messageToBeDeleted = new List<RedisValue>();

                        lastReadId = result.Last().Id;
                        foreach (var process in result)
                        {
                            var value = process.Values[0].Value.ToString();
                            var stream = JsonSerializer.Deserialize<ProcessInstanceStream>(value, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                            if (stream == null)
                            {
                                continue;
                            }

                            var entity = streamToEntityHandler(stream);
                            dbContext.Set<TEntity>().Add(entity as TEntity);
                            var savingResult = await dbContext.SaveChangesAsync();
                            if (savingResult > 0)
                            {
                                messageToBeDeleted.Add(process.Id);
                            }
                        }
                        var deletedItemsCount = await redisDb.StreamDeleteAsync(streamName, messageToBeDeleted.ToArray());

                    }
        }
    }

