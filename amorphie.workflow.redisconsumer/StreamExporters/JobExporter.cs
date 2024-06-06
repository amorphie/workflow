using amorphie.workflow.core.Constants;
using amorphie.workflow.core.Dtos;
using amorphie.workflow.core.Models.Consumer;
using amorphie.workflow.redisconsumer.StreamObjects;
using Serilog;
using StackExchange.Redis;

namespace amorphie.workflow.redisconsumer.StreamExporters;

internal class JobExporter : BaseExporter, IExporter
{
    private static readonly Serilog.ILogger _logger = Log.ForContext<JobExporter>();

    public JobExporter(WorkflowDBContext dbContext, IDatabase redisDb, string consumerName) : base(dbContext, redisDb, consumerName)
    {
        this.streamName = ZeebeStreamKeys.Streams.JOB;
        this.groupName = ZeebeStreamKeys.Groups.JOB_GROUP;
        ConfigureGroup().Wait();
    }

    public override async Task DoBussiness(StreamEntry[] streamEntries, CancellationToken cancellationToken)
    {

        var messageToBeDeleted = new List<RedisValue>();
        string? currentProccessId = "";
        foreach (var process in streamEntries)
        {
            try
            {
                var stream = Deserialize<JobStream>(process);

                if (stream == null)
                {
                    continue;
                }
                currentProccessId = process.Id;
                //Take only user tasks
                if ((stream.Intent == ZeebeEventKeys.COMPLETED || stream.Intent == ZeebeEventKeys.CREATED) && stream.Value.Type == ZeebeVariableKeys.TypeUserTask)
                {
                    var entity = dbContext.Jobs.FirstOrDefault(s => s.Key == stream.Value.ElementInstanceKey);

                    if (entity != null)
                    {
                        entity.EndTimestamp = stream.Timestamp;
                        entity.Intent = stream.Intent;
                        dbContext.Jobs.Update(entity);
                    }
                    else
                    {
                        //Start event triggered for the first time
                        entity = StreamToEntity(stream);
                        dbContext.Jobs.Add(entity);
                    }

                    var savingResult = await dbContext.SaveChangesAsync();
                    if (savingResult > 0)
                    {
                        messageToBeDeleted.Add(process.Id);
                    }
                }
                else
                {
                    //delete the messages which have other Intent's
                    messageToBeDeleted.Add(process.Id);
                }
            }
            catch (Exception e)
            {
                _logger.Error($"Exception while handling {currentProccessId} proccess id. Ex: {e}");
            }
        }
        //var deletedItemsCount = await DeleteMessagesAsync(messageToBeDeleted, cancellationToken);
    }

    private Job StreamToEntity(JobStream stream)
    {
        return new Job
        {
            BpmnProcessId = stream.Value.BpmnProcessId,
            Key = stream.Key,
            Timestamp = stream.Timestamp,
            ElementType = stream.Value.Type,
            Intent = stream.Intent,
            ProcessInstanceKey = stream.Value.ProcessInstanceKey
        };
    }
}
