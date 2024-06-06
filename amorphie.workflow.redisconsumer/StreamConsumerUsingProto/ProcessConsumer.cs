using amorphie.workflow.core.Constants;
using amorphie.workflow.redisconsumer.StreamExporters;
using Serilog;
using StackExchange.Redis;

namespace amorphie.workflow.redisconsumer.StreamConsumerUsingProto;
public class ProcessConsumer : BaseExporter, IExporter
{
    private static readonly Serilog.ILogger _logger = Log.ForContext<ProcessConsumer>();

    public ProcessConsumer(WorkflowDBContext dbContext, IDatabase redisDb, string consumerName) : base(dbContext, redisDb, consumerName)
    {
        this.streamName = ZeebeStreamKeys.Streams.DEPLOYMENT;
        this.groupName = ZeebeStreamKeys.Groups.DEPLOYMENT_GROUP;
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
                var record = Record.Parser.ParseFrom(process.Values.First().Value);

                var unpacked = record.Record_.Unpack<ProcessRecord>();

                var bpmProcessId = unpacked.BpmnProcessId;
                //var stream = Deserialize<ProcessStream>(process);
                //if (stream == null)
                //{
                //    continue;
                //}
                //currentProccessId = process.Id;

                //var resourceName = stream.Value.Resources.FirstOrDefault()?.ResourceName ?? stream.Value.ProcessesMetadata.FirstOrDefault()?.ResourceName;

                //var entity = dbContext.Processs.FirstOrDefault(p => p.ResourceName == resourceName);
                //if (entity != null)
                //{
                //    entity.Intent = stream.Intent;
                //    entity.Version = stream.RecordVersion;
                //    entity.BpmnProcessId = stream.Value.ProcessesMetadata.FirstOrDefault()?.BpmnProcessId ?? "";
                //    dbContext.Processs.Update(entity);
                //}
                //else
                //{
                //    entity = StreamToEntity(stream);
                //    dbContext.Processs.Add(entity);
                //}

                //var savingResult = await dbContext.SaveChangesAsync();
                //if (savingResult > 0)
                //{
                //    messageToBeDeleted.Add(process.Id);
                //}
            }
            catch (Exception e)
            {
                _logger.Error($"Exception while handling {currentProccessId} proccess id. Ex: {e}");
            }
        }
        //var deletedItemsCount = await DeleteMessagesAsync(messageToBeDeleted, cancellationToken);

    }
    //private Process StreamToEntity(ProcessStream stream)
    //{
    //    var Process = new Process
    //    {
    //        BpmnProcessId = "",
    //        Intent = stream.Intent,
    //        Duplicate = stream.Value.Duplicate,
    //        Version = stream.Value.Version,
    //    };
    //    var resource = stream.Value.Resources.FirstOrDefault();
    //    Process.Resource = resource?.Resource ?? "";
    //    Process.ResourceName = resource?.ResourceName ?? "";
    //    return Process;

    //}
}

