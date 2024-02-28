namespace amorphie.workflow.redisconsumer.StreamObjects;

public class DeploymentStream : BaseStream
{

    public DeploymentStreamValue Value { get; set; }
    public int SourceRecordPosition { get; set; }
    public string RecordType { get; set; } = default!;
    public int Position { get; set; }
    public int RecordVersion { get; set; }

}

public class DeploymentStreamValue
{
    //ilk stream'de upload edilen bpmn base 64 olarak geliyor ve Resources array şeklinde
    public List<Resources> Resources { get; set; }
    //sonraki stream'lerde
    public List<Resources> ProcessesMetadata { get; set; }
    public long Version { get; set; }
    public bool Duplicate { get; set; }

}

public class Resources
{
    public string BpmnProcessId { get; set; }
    public string ResourceName { get; set; } = default!;
    public string Resource { get; set; } = default!;
}

