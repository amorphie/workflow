using amorphie.core.Base;
namespace amorphie.workflow.core.Models.GatewayMessages;
public class Process : EntityBase
{
    public string? InstanceId { get; set; }
    public string? BpmnProcessId { get; set; }

    public long Key { get; set; }
    public long Timestamp { get; set; }
    public int Version { get; set; }

    public string? ResourceName { get; set; }
}