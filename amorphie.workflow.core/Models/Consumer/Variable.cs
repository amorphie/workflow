namespace amorphie.workflow.core.Models.Consumer;

public class Variable
{
    public long Key { get; set; }
    public long Timestamp { get; set; }
    public string? BpmnProcessId { get; set; }
    public long ProcessInstanceKey { get; set; }
    public long ProcessDefinitionKey { get; set; }
    public long ScopeKey { get; set; }
    public string? Name { get; set; }
    public string? Value { get; set; }
}