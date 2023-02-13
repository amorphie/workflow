

public class State : BaseDbEntity
{
    public Workflow? Workflow { get; set; }
    public string? WorkflowName { get; set; }

    public string Name { get; set; } = string.Empty;
    public ICollection<Translation> Titles { get; set; } = default!;
    public ICollection<Translation> Descriptions { get; set; } = default!;

    public ICollection<Transition> Transitions { get; set; } = default!;

    public ZeebeFlow? OnEntryFlow { get; set; }
    public ZeebeFlow? OnExitFlow { get; set; }

    public BaseStatusType BaseStatus { get; set; }
    public StateType Type { get; set; }
}





