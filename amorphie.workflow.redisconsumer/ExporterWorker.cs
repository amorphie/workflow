using amorphie.workflow.redisconsumer.StreamExporters;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;
namespace amorphie.workflow.redisconsumer;
public class ExporterWorker : BackgroundService
{
    protected readonly WorkflowDBContext dbContext;
    protected readonly IDatabase redisDb;
    protected readonly string consumerName;
    protected readonly string readingStrategy;
    private readonly ILogger<ExporterWorker> _logger;

    public ExporterWorker(ILogger<ExporterWorker> logger, WorkflowDBContext dbContext, IDatabase redisDb)
    {
        this.dbContext = dbContext;
        this.redisDb = redisDb;
        this.consumerName = Environment.MachineName;
        this.readingStrategy = ">";
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {

        //_logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

        var deploymentExporter = new DeploymentExporter(dbContext, redisDb, consumerName, readingStrategy);
        var incidentExporter = new IncidentExporter(dbContext, redisDb, consumerName, readingStrategy);
        var messageExporter = new MessageExporter(dbContext, redisDb, consumerName, readingStrategy);
        var messageStartEventExporter = new MessageStartEventSubscriptionExporter(dbContext, redisDb, consumerName, readingStrategy);
        var messageSubscriptionExporter = new MessageSubscriptionExporter(dbContext, redisDb, consumerName, readingStrategy);
        var processInstanceExporter = new ProcessInstanceExporter(dbContext, redisDb, consumerName, readingStrategy);
        var variableExporter = new VariableExporter(dbContext, redisDb, consumerName, readingStrategy);
        var jobExporter = new JobExporter(dbContext, redisDb, consumerName, readingStrategy);

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