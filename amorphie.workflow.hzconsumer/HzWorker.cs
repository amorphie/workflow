
using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Hazelcast;
using Microsoft.Extensions.Options;

namespace amorphie.workflow.hzconsumer;
public class HzWorker : BackgroundService
{

    private readonly ILogger<HzWorker> _logger;
    private readonly HazelcastOptions _options;


    public HzWorker(ILogger<HzWorker> logger, IOptions<HazelcastOptions> options)
    {
        _logger = logger;
        _options = options.Value;
    }

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Hz worker start running at: {Time}", DateTimeOffset.Now);

        await using var client = await HazelcastClientFactory.StartNewClientAsync(_options);
        await using var rb = await client.GetRingBufferAsync<byte[]>("zeebe");
        var sequence = await rb.GetHeadSequenceAsync();


        while (!cancellationToken.IsCancellationRequested)
        {
            var readResult = await rb.ReadOneAsync(sequence);
            var recordParseResult = Record.Parser.ParseFrom(readResult);

            var rra = GetMessageType(recordParseResult);
        }
    }
    static List<IMessage> RecordMessages = new List<IMessage>
        {
            new DeploymentRecord(),
            new DeploymentDistributionRecord(),
            new ErrorRecord(),
            new IncidentRecord(),
            new JobRecord(),
            new JobBatchRecord(),
            new MessageStartEventSubscriptionRecord(),
            new MessageSubscriptionRecord(),
            new MessageRecord(),
            new ProcessRecord(),
            new ProcessEventRecord(),
            new ProcessInstanceRecord(),
            new ProcessInstanceCreationRecord(),
            new ProcessMessageSubscriptionRecord(),
            new TimerRecord(),
            new VariableRecord(),
            new VariableDocumentRecord(),
            new DecisionRecord(),
            new DecisionRequirementsRecord(),
            new DecisionEvaluationRecord(),
            new SignalRecord(),
            new SignalSubscriptionRecord(),
        };
    static IMessage GetMessageType(Record record)
    {
        var recordType = RecordMessages.FirstOrDefault(p => record.Record_.Is(p.Descriptor));
        if (recordType != null)
        {
            recordType.MergeFrom(record.Record_.Value);
            return recordType;

        }
        return null;
    }



}