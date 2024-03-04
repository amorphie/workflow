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
        _logger.LogInformation("Stream cleaner worker start running at: {time}", DateTimeOffset.Now);

        while (!cancellationToken.IsCancellationRequested)
        {
            await redisDb.StreamTrimAsync(ZeebeStreamKeys.Streams.PROCESS_EVENT, 10, false, CommandFlags.PreferMaster);
            await redisDb.StreamTrimAsync(ZeebeStreamKeys.Streams.VARIABLE_DOCUMENT, 10, false, CommandFlags.PreferMaster);
            await redisDb.StreamTrimAsync(ZeebeStreamKeys.Streams.JOB_BATCH, 10, false, CommandFlags.PreferMaster);
            await Task.Delay(timeToLive * 1000);
        }
    }
}