using amorphie.core.Base;
namespace amorphie.workflow.core.Models.GatewayMessages;

public class Message : EntityBase
{
    public string? InstanceId { get; set; }
    public long Deadline { get; set; }
    public long Key { get; set; }
    public long Timestamp { get; set; }
    public int Position { get; set; }
    public string? ValueType { get; set; }
    public int SourceRecordPosition { get; set; }
    public string? Intent { get; set; }
    public string? RejectionType { get; set; }
    public string? RejectionReason { get; set; }
    public int RecordVersion { get; set; }
    public string? BrokerVersion { get; set; }
    public string? RecordType { get; set; }

    public string? Variables { get; set; }

    public long ProcessInstanceKey { get; set; }
    public long ProcessDefinitionKey { get; set; }

    public string? ElementId { get; set; }
    public string? MessageName { get; set; }
    public long MessageKey { get; set; }
    public string? CorrelationKey { get; set; }
}