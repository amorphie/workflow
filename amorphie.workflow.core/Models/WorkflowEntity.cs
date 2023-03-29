

using System.Text.Json.Serialization;
using amorphie.core.Base;
using amorphie.core.Enums;

public class WorkflowEntity : EntityBase
{
     [JsonIgnore]
    public Workflow Workflow { get; set; } = default!;
    public string WorkflowName { get; set; } = default!;

    public string Name { get; set; } = string.Empty;

    public bool IsStateManager { get; set; } = false;

    public bool AllowOnlyOneActiveInstance { get; set; } = false;
    public ICollection<Workflow> InclusiveWorkflows { get; set; } = default!;

    public StatusType AvailableInStatus { get; set; }
}



