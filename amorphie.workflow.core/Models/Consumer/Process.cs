using amorphie.core.Base;
namespace amorphie.workflow.core.Models.Consumer;
public class Process : EntityBase
{
    public string? BpmnProcessId { get; set; }

    public long Key { get; set; }
    public long Timestamp { get; set; }
    public int Version { get; set; }

    public string? Resource { get; set; }
}