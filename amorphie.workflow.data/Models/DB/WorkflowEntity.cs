

public class WorkflowEntity : BaseDbEntityWithId
{
    public Workflow Workflow { get; set; } = default!;
    public string WorkflowName { get; set; } = default!;
    
    public string Name { get; set; } = string.Empty;
    public bool IsExclusive { get; set; } = false;
    public bool IsStateManager { get; set; } = false;
    public BaseStatusType AvailableInStatus { get; set; }
}



