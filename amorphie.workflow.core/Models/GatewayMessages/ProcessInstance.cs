namespace amorphie.workflow.core.Models.GatewayMessages;

public class ProcessInstance
{
    public long Key { get; set; }
    public int PartitionId { get; set; }
    public int Version { get; set; }
    public string BpmnProcessId { get; set; } = default!;
    public long ProcessInstanceKey { get; set; }
    public long ProcessDefinitionKey { get; set; }
    public string ElementId { get; set; } = default!;
    public long FlowScopeKey { get; set; }
    public string BpmnElementType { get; set; } = default!;
    public string BpmnEventType { get; set; } = default!;
    public long ParentProcessInstanceKey { get; set; }
    public long ParentElementInstanceKey { get; set; }
    public long Timestamp { get; set; }
    public long EndTimestamp { get; set; }
    public string ValueType { get; set; } = default!;
    public string BrokerVersion { get; set; } = default!;
    public int SourceRecordPosition { get; set; }
    public string Intent { get; set; } = default!;
    public string RecordType { get; set; } = default!;
    public string RejectionType { get; set; } = default!;
    public string RejectionReason { get; set; } = default!;
    public int Position { get; set; }
}