using System.ComponentModel;

namespace amorphie.workflow.core.Enums
{
    public enum HumanTaskCompleteType
    {
           [Description("complete")]
    Complete = 1,
    [Description("deny")]
    Deny = 2,
    [Description("autotrigger")]
    AutoTrigger = 4
    }
}