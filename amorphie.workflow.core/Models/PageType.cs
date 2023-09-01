using System.ComponentModel;

public enum PageType
{
    [Description("Normal")]
    Normal = 1,
    [Description("Popup")]
    Popup = 2,
    [Description("Confirm")]
    Confirm = 4,
    [Description("Notification")]
    Notification = 8
}
