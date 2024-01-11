using amorphie.core.Base;
using NpgsqlTypes;

public class Process : EntityBase
{

    /// <summary>
    /// Probably not needed
    /// </summary>
    public string RedisId { get; set; } = default!;
    public string? InstanceId { get; set; }
    public string? BpmnProcessId { get; set; }

    public long Key { get; set; }
    public long Timestamp { get; set; }
    public int Version { get; set; }

    public string? ResourceName { get; set; }
}