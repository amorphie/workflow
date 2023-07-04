using amorphie.core.Base;
public class InstanceTransition : EntityBaseLog
{
    public Instance Instance { get; set; } = default!;
    public Guid InstanceId { get; set; } = default!;

    public State FromState { get; set; } = default!;
    public string FromStateName { get; set; } = default!;

    public State ToState { get; set; } = default!;
    public string ToStateName { get; set; } = default!;

    public string EntityData { get; set; } = default!;
    public string? FormData { get; set; } = default!;
    public string? AdditionalData { get; set; } = default!;
    public string? RouteData { get; set; } = default!;
    public string? QueryData { get; set; } = default!;

    public Transition?  Transition { get; set; } = default!;
    public string? TransitionName { get; set; } = default!;
   
}
