

public class Instance : BaseDbEntityWithId
{
    public Workflow Workflow { get; set; } = default!;
    public string WorkflowName { get; set; } = default!;

    public ZeebeFlow ZeebeFlow { get; set; } = default!;
    public string ZeebeFlowName { get; set; } = default!;

    public WorkflowEntity Entity { get; set; } = default!;
    public Guid EntityId { get; set; } = default!;

    public Guid RecordId { get; set; } = default!;

    public State State { get; set; } = default!;
    public string StateName { get; set; } = default!;
}



