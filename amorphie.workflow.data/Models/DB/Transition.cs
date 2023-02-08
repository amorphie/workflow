

public class Transition : BaseDbEntity
{
    public State? FromState { get; set; }
    public State? ToState { get; set; }
    
    public string Name { get; set; } = string.Empty;
    public Translation[]? Title { get; set; }

    public string? Form { get; set; }

    public TransitionType Type { get; set; }

    public string? Process { get; set; }
    public string? Gateway { get; set; }
}





