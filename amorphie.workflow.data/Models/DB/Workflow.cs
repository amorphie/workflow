

public class Workflow : BaseDbEntity
{
    public string Name { get; set; } = string.Empty;
    public string[]? Tags { get; set; }
    public ICollection<Translation> Titles { get; set; } = default!;
    public ICollection<State> States { get; set; } = default!;
    public ZeebeFlow? ZeebeFlow { get; set; }
    public List<WorkflowEntity> Entities { get; set; } = default!;
}



