using System.ComponentModel;

namespace amorphie.workflow.core.Enums
{
    public enum NavigationType
    {
        [Description("push-replacement")]
        PushReplacement = 1,
        [Description("popup")]
        PopUp = 2,
        [Description("pop-until")]
        PopUntil = 4,
        [Description("push-as-root")]
        PushAsRoot = 8,
        [Description("push")]
        Push = 16,
        [Description("bottom-sheet")]
        BottomSheet = 32
    }
}