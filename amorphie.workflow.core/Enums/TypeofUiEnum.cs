using System.ComponentModel;

namespace amorphie.workflow.core.Enums
{
    public enum TypeofUiEnum
    {
        [Description("Formio")]
        Formio = 1,
        [Description("Page Url")]
        PageUrl = 2,
        [Description("Html")]
        Html = 4,
        [Description("FlutterWidget")]
        FlutterWidget = 8
    }
}