namespace amorphie.workflow.core.Models.GatewayMessages;
public class Deployment
{
    public string BpmnProcessId { get; set; } = default!;
    public string ResourceName { get; set; } = default!;
    public string Resource { get; set; } = default!;
    public long Version { get; set; }
    public bool Duplicate { get; set; }
    public string? Intent { get; set; }

}