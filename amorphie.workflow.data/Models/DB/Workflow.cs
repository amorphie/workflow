

public class Workflow : BaseDbEntity
{
    public string Name { get; set; } = string.Empty;
    public string[]? Tags { get; set; }
    public Translation[]? Title { get; set; }
    public State[]? States { get; set; }
    public WorkflowType Type { get; set; }
    public string? ProcessName { get; set; }
    public string? Process { get; set; }
    public string? Gateway { get; set; }

    public List<WorkflowEntity>? Entities { get; set; }
}



