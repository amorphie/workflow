namespace amorphie.workflow.core.Dtos.Hierarchy;
public class HierarchyState
{
    public string StateName { get; set; } = string.Empty;
    public List<HierarchyTransition>? Transitions { get; set; }
}
