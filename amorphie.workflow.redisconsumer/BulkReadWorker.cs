using amorphie.workflow.core.Constants;
using amorphie.workflow.redisconsumer.StreamExporters;
using Dapr.Client;
using StackExchange.Redis;
namespace amorphie.workflow.redisconsumer;
public class BulkReadWorker : BackgroundService
{
    protected readonly WorkflowDBContext dbContext;
    protected readonly IDatabase redisDb;
    protected readonly string consumerName;
    protected readonly string readingStrategy;
    private readonly ILogger<BulkReadWorker> _logger;
    private readonly DaprClient daprClient;
    protected async Task ConfigureGroup(string groupName)
    {
        foreach (var item in typeof(ZeebeStreamKeys.Streams).GetProperties())
        {
            var streamName = item.GetValue(null)?.ToString();
            if (!string.IsNullOrEmpty(streamName) && (
                !await redisDb.KeyExistsAsync(streamName) ||
                (await redisDb.StreamGroupInfoAsync(streamName)).All(x => x.Name != groupName)
                ))
            {
                await redisDb.StreamCreateConsumerGroupAsync(streamName, groupName, "0-0", true);
            }
        }
    }
    public BulkReadWorker(ILogger<BulkReadWorker> logger, WorkflowDBContext dbContext, IDatabase redisDb, DaprClient daprClient)
    {
        this.dbContext = dbContext;
        this.redisDb = redisDb;
        this.consumerName = Environment.MachineName;
        this.readingStrategy = ">";
        _logger = logger;
        this.daprClient = daprClient;
    }

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        var gatewayAsConsumerGroup = ZeebeStreamKeys.GateWay;
        var consumer = Environment.MachineName;
        await ConfigureGroup(gatewayAsConsumerGroup);

        _logger.LogInformation("Bulk Worker running at: {time}", DateTimeOffset.Now);

        var streamsToBeRead = new StreamPosition[]
        {
            new StreamPosition(ZeebeStreamKeys.Streams.DEPLOYMENT, StreamPosition.NewMessages),
            new StreamPosition(ZeebeStreamKeys.Streams.MESSAGE_START_EVENT_SUBSCRIPTION, StreamPosition.NewMessages),
            new StreamPosition(ZeebeStreamKeys.Streams.MESSAGE_SUBSCRIPTION, StreamPosition.NewMessages),
            new StreamPosition(ZeebeStreamKeys.Streams.MESSAGE, StreamPosition.NewMessages),
            new StreamPosition(ZeebeStreamKeys.Streams.PROCESS_INSTANCE, StreamPosition.NewMessages),
            new StreamPosition(ZeebeStreamKeys.Streams.VARIABLE, StreamPosition.NewMessages),
            new StreamPosition(ZeebeStreamKeys.Streams.JOB, StreamPosition.NewMessages),
        };

        while (!cancellationToken.IsCancellationRequested)
        {
            try
            {
                //var result = await redisDb.StreamReadAsync(streamPositions: streamsToBeRead, 100);
                var result = await redisDb.StreamReadGroupAsync(streamPositions: streamsToBeRead, gatewayAsConsumerGroup, consumer, 100);
                if (result.Any())
                {
                    foreach (var stream in result)
                    {
                        if (!stream.Entries.Any())
                        {
                            continue;
                        }
                        BaseExporter exporter;
                        if (stream.Key == ZeebeStreamKeys.Streams.DEPLOYMENT)
                        {
                            exporter = new DeploymentExporter(dbContext, redisDb, consumerName);
                        }
                        else if (stream.Key == ZeebeStreamKeys.Streams.MESSAGE_START_EVENT_SUBSCRIPTION)
                        {
                            exporter = new MessageStartEventSubscriptionExporter(dbContext, redisDb, consumerName);
                        }
                        else if (stream.Key == ZeebeStreamKeys.Streams.MESSAGE_SUBSCRIPTION)
                        {
                            exporter = new MessageSubscriptionExporter(dbContext, redisDb, consumerName);
                        }
                        else if (stream.Key == ZeebeStreamKeys.Streams.MESSAGE)
                        {
                            exporter = new MessageExporter(dbContext, redisDb, consumerName);
                        }
                        else if (stream.Key == ZeebeStreamKeys.Streams.PROCESS_INSTANCE)
                        {
                            exporter = new ProcessInstanceExporter(dbContext, redisDb, consumerName);
                        }
                        else if (stream.Key == ZeebeStreamKeys.Streams.VARIABLE)
                        {
                            exporter = new VariableExporter(dbContext, redisDb, consumerName);
                        }
                        else if (stream.Key == ZeebeStreamKeys.Streams.JOB)
                        {
                            exporter = new JobExporter(dbContext, redisDb, consumerName);
                        }
                        else
                        {
                            continue;
                        }
                        await exporter.DoBussiness(stream.Entries, cancellationToken);
                    }
                }
                await Task.Delay(1000, cancellationToken);
            }
            catch (Exception ex)
            {

                _logger.LogCritical($"An unhandled exception occured while running attachers: {ex}");
            }


        }
    }
}