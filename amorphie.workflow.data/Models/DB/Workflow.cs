

public class Workflow : BaseDbEntity
{
    public string Name { get; set; } = string.Empty;
    public string[]? Tags { get; set; }
    public ICollection<Translation> Titles { get; set; } = default!;
    public ICollection<State> States { get; set; } = default!;
    public WorkflowType Type { get; set; }
    public string? ProcessName { get; set; }
    public string? Process { get; set; }
    public string? Gateway { get; set; }

    public List<WorkflowEntity>? Entities { get; set; }
}



