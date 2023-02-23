

public class Instance : BaseDbEntityWithId
{
    public Workflow Workflow { get; set; } = default!;
    public string WorkflowName { get; set; } = default!;

    public ZeebeMessage? ZeebeFlow { get; set; }
    public string? ZeebeFlowName { get; set; }

    public string EntityName { get; set; } = default!;

    public Guid RecordId { get; set; } = default!;

    public State? State { get; set; } = default!;
    public string? StateName { get; set; } = default!;

    public BaseStatusType BaseStatus { get; set; } = default!;
}



