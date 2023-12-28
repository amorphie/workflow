using System.ComponentModel;
using System.Text.Json.Serialization;

namespace amorphie.workflow.core.Enums
{
    public enum NavigationType
    {
         [JsonPropertyName("push-replacement")]
        [Description("push-replacement")]
        PushReplacement = 1,
        [JsonPropertyName("popup")]
        [Description("popup")]
        PopUp = 2,
         [JsonPropertyName("pop-until")]
        [Description("pop-until")]
        
        PopUntil = 4,
         [JsonPropertyName("push-as-root")]
        [Description("push-as-root")]
        PushAsRoot = 8,
         [JsonPropertyName("push")]
        [Description("push")]
        Push = 16,
         [JsonPropertyName("bottom-sheet")]
        [Description("bottom-sheet")]
        BottomSheet = 32
    }
}