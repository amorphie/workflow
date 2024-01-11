namespace amorphie.workflow.core.Models;
public class JsonSchema : amorphie.core.Base.EntityBase
{
    public string ZeebeElementId { get; set; } = default!;
    public string Schema { get; set; } = default!;

    public string WorkflowName { get; set; } = default!;
    public Workflow Workflow { get; set; } = default!;

}
