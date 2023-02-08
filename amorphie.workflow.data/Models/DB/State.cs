

public class State : BaseDbEntity
{
    public Workflow? Workflow { get; set; }
    public string Name { get; set; } = string.Empty;
    public Translation[]? Title { get; set; }

    public Transition[]? Transitions { get; set; }

    public BaseStatusType BaseStatus { get; set; }
    public StateType Type { get; set; }
}





