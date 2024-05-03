using System.ComponentModel;

namespace amorphie.workflow.core.Enums;
public enum HumanTaskStatus
{
    [Description("pending ")]
    Pending = 1,
    [Description("in_progress  ")]
    InProgress = 2,
    [Description("completed ")]
    Completed = 4,
    [Description("denied ")]
    Denied = 8
}
