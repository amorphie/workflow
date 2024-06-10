
using amorphie.core.Base;

namespace amorphie.workflow.core.Models;
public class Note : EntityBase
{
    public required string Text { get; set; }
    public Guid InstanceId { get; set; }
    public string? StateName { get; set; }
}

