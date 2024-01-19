namespace amorphie.workflow.redisconsumer.StreamObjects;

public class DeploymentStream:BaseStream
{
    
    public DeploymentStreamValue Value { get; set; }

    public int SourceRecordPosition { get; set; }

    public string RecordType { get; set; } = default!;
    
    public int Position { get; set; }
    public int RecordVersion { get; set; }

}

public class DeploymentStreamValue
{
    public string BpmnProcessId { get; set; }
    public string ResourceName { get; set; }
    public long Version { get; set; }
    public bool Duplicate { get; set; }

}

