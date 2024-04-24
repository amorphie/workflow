namespace amorphie.workflow.core.Dtos.Hierarchy;
public class HierarchyTransition
{
    public string? TransitionName { get; set; } = string.Empty;
    public string? ToStateName { get; set; } = string.Empty;
    public HierarchyState? ToState { get; set; }
}

