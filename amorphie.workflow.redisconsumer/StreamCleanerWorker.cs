using amorphie.workflow.core.Constants;

using StackExchange.Redis;
namespace amorphie.workflow.redisconsumer;
public class StreamCleanerWorker : BackgroundService
{
    protected readonly IDatabase redisDb;
    protected readonly int timeToLive;
    private readonly ILogger<ExporterWorker> _logger;

    public StreamCleanerWorker(ILogger<ExporterWorker> logger, IDatabase redisDb)
    {
        this.redisDb = redisDb;
        this.timeToLive = 100;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        //_logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

        while (!cancellationToken.IsCancellationRequested)
        {
            await redisDb.StreamTrimAsync(ZeebeStreamKeys.PROCESS_EVENT, 10);
            await redisDb.StreamTrimAsync(ZeebeStreamKeys.VARIABLE_DOCUMENT, 10);
            //await redisDb.StreamTrimAsync(ZeebeStreamKeys.JOB, 10);
            await redisDb.StreamTrimAsync(ZeebeStreamKeys.JOB_BATCH, 10);

            await Task.Delay(timeToLive * 1000);
        }
    }
}