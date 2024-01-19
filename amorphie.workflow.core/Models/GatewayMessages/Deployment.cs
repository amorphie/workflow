namespace amorphie.workflow.core.Models.GatewayMessages;
public class Deployment
{

    public long Key { get; set; }

    public string BpmnProcessId { get; set; }
    public string ResourceName { get; set; }
    public long Version { get; set; }
    public bool Duplicate { get; set; }
    public string? Intent { get; set; }

}