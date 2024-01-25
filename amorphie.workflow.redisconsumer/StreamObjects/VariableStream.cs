namespace amorphie.workflow.redisconsumer.StreamObjects;
public class VariableStream : BaseStream
{
    public VariableStreamValue Value { get; set; }
    public int SourceRecordPosition { get; set; }
    public int Position { get; set; }
}
public class VariableStreamValue
{
    public string? BpmnProcessId { get; set; }
    public long ProcessInstanceKey { get; set; }
    public long ProcessDefinitionKey { get; set; }
    public long ScopeKey { get; set; }
    public string? Name { get; set; }
    public string? Value { get; set; }
}

