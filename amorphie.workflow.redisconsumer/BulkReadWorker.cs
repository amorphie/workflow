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
        _logger.LogInformation("Bulk Worker running at: {time}", DateTimeOffset.Now);

        var streamsToBeRead = new StreamPosition[]
        {
            new StreamPosition(ZeebeStreamKeys.DEPLOYMENT, 0),
            new StreamPosition(ZeebeStreamKeys.MESSAGE_START_EVENT_SUBSCRIPTION, 0),
            new StreamPosition(ZeebeStreamKeys.MESSAGE_SUBSCRIPTION, 0),
            new StreamPosition(ZeebeStreamKeys.MESSAGE, 0),
            new StreamPosition(ZeebeStreamKeys.PROCESS_INSTANCE, 0),
            new StreamPosition(ZeebeStreamKeys.VARIABLE, 0),
            new StreamPosition(ZeebeStreamKeys.JOB, 0),
        };

        while (!cancellationToken.IsCancellationRequested)
        {
            try
            {
                var result = await redisDb.StreamReadAsync(streamPositions: streamsToBeRead, 100);
                if (result.Any())
                {
                    foreach (var stream in result)
                    {
                        if (!stream.Entries.Any())
                        {
                            continue;
                        }
                        BaseExporter exporter;
                        if (stream.Key == ZeebeStreamKeys.DEPLOYMENT)
                        {
                            exporter = new DeploymentExporter(dbContext, redisDb, consumerName);
                        }
                        else if (stream.Key == ZeebeStreamKeys.MESSAGE_START_EVENT_SUBSCRIPTION)
                        {
                            exporter = new MessageStartEventSubscriptionExporter(dbContext, redisDb, consumerName);
                        }
                        else if (stream.Key == ZeebeStreamKeys.MESSAGE_SUBSCRIPTION)
                        {
                            exporter = new MessageSubscriptionExporter(dbContext, redisDb, consumerName);
                        }
                        else if (stream.Key == ZeebeStreamKeys.MESSAGE)
                        {
                            exporter = new MessageExporter(dbContext, redisDb, consumerName);
                        }
                        else if (stream.Key == ZeebeStreamKeys.PROCESS_INSTANCE)
                        {
                            exporter = new ProcessInstanceExporter(dbContext, redisDb, consumerName);
                        }
                        else if (stream.Key == ZeebeStreamKeys.VARIABLE)
                        {
                            exporter = new VariableExporter(dbContext, redisDb, consumerName);
                        }
                        else if (stream.Key == ZeebeStreamKeys.JOB)
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