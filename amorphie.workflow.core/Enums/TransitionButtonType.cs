using System.ComponentModel;
namespace amorphie.workflow.core.Enums;

public enum TransitionButtonType
{
    [Description("forward")]
    Forward = 1,
    [Description("back")]
    Back = 2,
    [Description("cancel")]
    Cancel = 4,

    [Description("addnote")]
    AddNote = 8,
    [Description("invisible")]
    Invisible = 16,

}
