using amorphie.workflow.redisconsumer.StreamExporters;
using Dapr.Client;
using StackExchange.Redis;
namespace amorphie.workflow.redisconsumer;
public class ExporterWorker : BackgroundService
{
    protected readonly WorkflowDBContext dbContext;
    protected readonly IDatabase redisDb;
    protected readonly string consumerName;
    protected readonly string readingStrategy;
    private readonly ILogger<ExporterWorker> _logger;
    private readonly DaprClient daprClient;

    public ExporterWorker(ILogger<ExporterWorker> logger, WorkflowDBContext dbContext, IDatabase redisDb, DaprClient daprClient)
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
        _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

        var deploymentExporter = new DeploymentExporter(dbContext, redisDb, consumerName);
        var incidentExporter = new IncidentExporter(dbContext, redisDb, consumerName);
        var messageExporter = new MessageExporter(dbContext, redisDb, consumerName);
        var messageStartEventExporter = new MessageStartEventSubscriptionExporter(dbContext, redisDb, consumerName);
        var messageSubscriptionExporter = new MessageSubscriptionExporter(dbContext, redisDb, consumerName);
        var processInstanceExporter = new ProcessInstanceExporter(dbContext, redisDb, consumerName);
        var variableExporter = new VariableExporter(dbContext, redisDb, consumerName);
        var jobExporter = new JobExporter(dbContext, redisDb, consumerName);

        while (!cancellationToken.IsCancellationRequested)
        {
            await deploymentExporter.Attach(cancellationToken);
            await incidentExporter.Attach(cancellationToken);
            await messageStartEventExporter.Attach(cancellationToken);
            await messageSubscriptionExporter.Attach(cancellationToken);
            await messageExporter.Attach(cancellationToken);
            await processInstanceExporter.Attach(cancellationToken);
            await variableExporter.Attach(cancellationToken);
            await jobExporter.Attach(cancellationToken);
            await Task.Delay(1000, cancellationToken);

        }
    }
}