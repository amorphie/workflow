

using amorphie.core.Base;

public class ZeebeMessage : EntityBaseWithOutId
{
    public string Name { get; set; } = string.Empty;
    public string[]? Tags { get; set; }
    public string Message { get; set; } = default!;
    public string Process { get; set; } = default!;
    public string Gateway { get; set; } = default!;
}





