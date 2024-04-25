namespace amorphie.workflow.core.Dtos.Hierarchy;
public class HierarchyStateNew
{
    public string StateName { get; set; } = string.Empty;
    public string Kind { get; set; } = string.Empty;
    public List<HierarchyStateNew>? ToStates { get; set; }
}
