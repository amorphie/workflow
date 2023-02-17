
public class InstanceTransition : BaseDbEntityWithId
{
    public Instance Instance { get; set; } = default!;
    public Guid InstanceId { get; set; } = default!;

    public ZeebeFlow? ZeebeFlow { get; set; }
    public string? ZeebeFlowName { get; set; }

    public ZeebeFlow? OnExitZeebeFlow { get; set; }
    public string? OnExitZeebeFlowName { get; set; }

    public ZeebeFlow? OnEnterZeebeFlow { get; set; }
    public string? OnEnterZeebeFlowName { get; set; }

    public State FromState { get; set; } = default!;
    public string FromStateName { get; set; } = default!;

    public State ToState { get; set; } = default!;
    public string ToStateName { get; set; } = default!;

    public string EntityData { get; set; } = default!;
    public string FormData { get; set; } = default!;
    public string AdditionalData { get; set; } = default!;

    public string FieldUpdates { get; set; } = default!;
    

    public DateTime CompletedAt { get; set; } = default!;
}
