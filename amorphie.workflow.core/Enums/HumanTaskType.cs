using System.ComponentModel;

namespace amorphie.workflow.core.Enums;
public enum HumanTaskType
{
    [Description("self_selected")]
    SelfSelected = 0,
    [Description("assigned ")]
    Assigned = 1
}
