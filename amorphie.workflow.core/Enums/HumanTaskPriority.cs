using System.ComponentModel;

namespace amorphie.workflow.core.Enums;
public enum HumanTaskPriority
{
    [Description("low")]
    Low = 0,
    [Description("medium ")]
    Medium = 1,
    [Description("high")]
    Hign = 2
}