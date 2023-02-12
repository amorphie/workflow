

public class ZeebeFlow : BaseDbEntity
{
    public string Name { get; set; } = string.Empty;
    public string[]? Tags { get; set; }
    public bool IsAtomic { get; set; }
    public string Process { get; set; } = default!;
    public string Gateway { get; set; } = default!;
}





