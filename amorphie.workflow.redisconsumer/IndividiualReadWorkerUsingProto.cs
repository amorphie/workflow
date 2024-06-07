using amorphie.workflow.core.Constants;
using amorphie.workflow.redisconsumer.StreamConsumerUsingProto;
using amorphie.workflow.redisconsumer.StreamExporters;
using amorphie.workflow.service.Db.Abstracts;
using Dapr.Client;
using StackExchange.Redis;
namespace amorphie.workflow.redisconsumer;
public class IndividiualReadWorkerUsingProto : BackgroundService
{
    protected readonly WorkflowDBContext dbContext;
    protected readonly IDatabase redisDb;
    protected readonly string groupName;
    protected readonly string consumerName;
    protected readonly string readingStrategy;
    private readonly ILogger<IndividiualReadWorkerUsingProto> _logger;
    private readonly DaprClient daprClient;
    private readonly IInstanceService _instanceService;

    protected async Task ConfigureGroup()
    {
        foreach (var item in typeof(ZeebeStreamKeys.Streams).GetProperties())
        {
            var streamName = item.GetValue(null)?.ToString();
            if (!string.IsNullOrEmpty(streamName) && (
                !await redisDb.KeyExistsAsync(streamName, CommandFlags.PreferMaster) ||
                (await redisDb.StreamGroupInfoAsync(streamName, CommandFlags.PreferMaster)).All(x => x.Name != groupName)
                ))
            {
                await redisDb.StreamCreateConsumerGroupAsync(streamName, groupName, "0-0", true, CommandFlags.PreferMaster);
            }
        }
    }
    public IndividiualReadWorkerUsingProto(ILogger<IndividiualReadWorkerUsingProto> logger, WorkflowDBContext dbContext, IDatabase redisDb, DaprClient daprClient, IInstanceService instanceService)
    {
        this.dbContext = dbContext;
        this.redisDb = redisDb;
        this.groupName = ZeebeStreamKeys.GateWay;
        this.consumerName = Environment.MachineName;
        this.readingStrategy = ">";
        _logger = logger;
        this.daprClient = daprClient;
        _instanceService = instanceService;
    }

    private async Task<(string, StreamEntry[])> ReadGroupAsync(string streamName, int count)
    {

        var result = await redisDb.StreamReadGroupAsync(streamName, groupName, consumerName, StreamPosition.NewMessages, count, CommandFlags.PreferMaster);

        return (streamName, result);
    }


    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        await ConfigureGroup();

        _logger.LogInformation("IndividiualReadWorkerUsingProto start running at: {Time}", DateTimeOffset.Now);

        while (!cancellationToken.IsCancellationRequested)
        {
            try
            {
                var processEntry = await ReadGroupAsync(ZeebeStreamKeys.Streams.PROCESS, 1000);
                var messageStartEventEntry = await ReadGroupAsync(ZeebeStreamKeys.Streams.MESSAGE_START_EVENT_SUBSCRIPTION, 1000);
                var messageSubsEntry = await ReadGroupAsync(ZeebeStreamKeys.Streams.MESSAGE_SUBSCRIPTION, 100);
                //var messageEntry = await ReadGroupAsync(ZeebeStreamKeys.Streams.MESSAGE, 100);
                //var proccessEntry = await ReadGroupAsync(ZeebeStreamKeys.Streams.PROCESS_INSTANCE, 100);
                //var variableEntry = await ReadGroupAsync(ZeebeStreamKeys.Streams.VARIABLE, 100);
                //var jobEntry = await ReadGroupAsync(ZeebeStreamKeys.Streams.JOB, 100);
                var jobBatchEntry = await ReadGroupAsync(ZeebeStreamKeys.Streams.JOB_BATCH, 100);

                await ProccessStreamsAsync(processEntry.Item1, processEntry.Item2, cancellationToken);

                await ProccessStreamsAsync(messageStartEventEntry.Item1, messageStartEventEntry.Item2, cancellationToken);
                await ProccessStreamsAsync(messageSubsEntry.Item1, messageSubsEntry.Item2, cancellationToken);
                //await ProccessStreamsAsync(messageEntry.Item1, messageEntry.Item2, cancellationToken);
                //await ProccessStreamsAsync(proccessEntry.Item1, proccessEntry.Item2, cancellationToken);
                //await ProccessStreamsAsync(variableEntry.Item1, variableEntry.Item2, cancellationToken);
                //await ProccessStreamsAsync(jobEntry.Item1, jobEntry.Item2, cancellationToken);
                await ProccessStreamsAsync(jobBatchEntry.Item1, jobBatchEntry.Item2, cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"An unhandled exception occured while running ExecuteAsync: {ex}");
            }
            await Task.Delay(10000, cancellationToken);
        }
    }
    protected async Task ProccessStreamsAsync(string streamName, StreamEntry[] entries, CancellationToken cancellationToken)
    {
        try
        {
            if (!entries.Any())
            {
                return;
            }
            BaseExporter exporter;
            if (streamName == ZeebeStreamKeys.Streams.PROCESS)
            {
                exporter = new ProcessConsumer(dbContext, redisDb, consumerName);
            }
            else if (streamName == ZeebeStreamKeys.Streams.MESSAGE_START_EVENT_SUBSCRIPTION)
            {
               exporter = new MessageStartEventSubscriptionConsumer(dbContext, redisDb, consumerName);
            }
            else if (streamName == ZeebeStreamKeys.Streams.MESSAGE_SUBSCRIPTION)
            {
               exporter = new MessageSubscriptionConsumer(dbContext, redisDb, consumerName);
            }
            //else if (streamName == ZeebeStreamKeys.Streams.MESSAGE)
            //{
            //    exporter = new MessageExporter(dbContext, redisDb, consumerName);
            //}
            //else if (streamName == ZeebeStreamKeys.Streams.PROCESS_INSTANCE)
            //{
            //    exporter = new ProcessInstanceExporter(dbContext, redisDb, consumerName);
            //}
            //else if (streamName == ZeebeStreamKeys.Streams.VARIABLE)
            //{
            //    exporter = new VariableExporter(dbContext, redisDb, consumerName);
            //}
            //else if (streamName == ZeebeStreamKeys.Streams.JOB)
            //{
            //    exporter = new JobExporter(dbContext, redisDb, consumerName);
            //}
            else if (streamName == ZeebeStreamKeys.Streams.JOB_BATCH)
            {
               exporter = new JobBatchConsumer(dbContext, redisDb, consumerName, _instanceService);
            }
            else
            {
                return;
            }
            await exporter.DoBussiness(entries, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogCritical(ex, "An unhandled exception occured while running ProccessStreamsAsync: ");
        }
    }
}