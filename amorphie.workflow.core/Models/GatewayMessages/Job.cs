namespace amorphie.workflow.core.Models.GatewayMessages;

public class Job
{

    public long Key { get; set; }
    /// <summary>
    /// Probably not needed
    /// </summary>
    public string RedisId { get; set; } = default!;
    public string? InstanceId { get; set; }

    public long Timestamp { get; set; }
    public int Retries { get; set; }

    public string? ErrorMessageName { get; set; }
    public string? JobType { get; set; }
}