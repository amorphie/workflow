using amorphie.core.Enums;
using amorphie.workflow.core.Enums;

namespace amorphie.workflow.core.Dtos.Definition;
public class WorkflowEntityDto
{
    public string Name { get; set; } = default!;
    public bool IsExclusive { get; set; }
    public bool IsStateManager { get; set; }
    public StatusType AvailableInStatus { get; set; }

}
