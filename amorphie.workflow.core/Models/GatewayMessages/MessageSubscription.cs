using amorphie.core.Base;
using NpgsqlTypes;

public class MessageSubscription : EntityBase
{

    /// <summary>
    /// Probably not needed
    /// </summary>
    public string RedisId { get; set; } = default!;
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
    //public string Authorizations { get; set; } //json
    public int RecordVersion { get; set; }
    public string? BrokerVersion { get; set; }
    public string? RecordType { get; set; }

    public string? TenantId { get; set; }

    public string? Variables { get; set; }
    public string BpmnProcessId { get; set; } = default!;

    public long ProcessInstanceKey { get; set; }
    public long ProcessDefinitionKey { get; set; }

    public string? ElementId { get; set; }
    public string? MessageName { get; set; }
    public long MessageKey { get; set; }
    public string? CorrelationKey { get; set; }
}