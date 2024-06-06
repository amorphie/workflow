using amorphie.core.Base;
namespace amorphie.workflow.core.Models.Consumer;
public class MessageSubscription : EntityBase
{

    public Guid InstanceId { get; set; }

    public long Deadline { get; set; }
    public long Key { get; set; }
    public long Timestamp { get; set; }
    public long Position { get; set; }
    public string? ValueType { get; set; }
    public int SourceRecordPosition { get; set; }
    public string? Intent { get; set; }

    public string? Variables { get; set; }
    public string BpmnProcessId { get; set; } = default!;

    public long ProcessInstanceKey { get; set; }
    public string? ElementId { get; set; }
    public string? MessageName { get; set; }
    public long MessageKey { get; set; }
    public string? CorrelationKey { get; set; }
}