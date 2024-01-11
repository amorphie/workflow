using amorphie.core.Base;
using NpgsqlTypes;

public class Incident : EntityBase
{

    /// <summary>
    /// Probably not needed
    /// </summary>
    public string RedisId { get; set; } = default!;
    public string? InstanceId { get; set; }
    public string? BpmnProcessId { get; set; }
    public string? ElementId { get; set; }

    public long Key { get; set; }
    public long Timestamp { get; set; }
    public int Retries { get; set; }
    public string? RejectionReason { get; set; }

    public string? ErrorMessageName { get; set; }
    public string? JobType { get; set; }
}