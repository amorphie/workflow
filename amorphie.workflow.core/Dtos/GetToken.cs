public record GetTokenRequest
{
    public String? Token { get; set; }
    public Guid InstanceId { get; set; }
    public string? WorkflowEntity { get; set; }
    public string? Scope { get; set; }
    public string? Client { get; set; }
    public Guid User { get; set; }
    public string? Reference { get; set; }
    public int TTL { get; set; } = 0;
    public DateTime IssuedAt { get; set; } = DateTime.Now;
    public DateTime? ExpiryAt { get; set; }
    public DateTime? ExpiredAt { get; set; }
    public DateTime? LastValidatedAt { get; set; }

};
public record PostPublishStatusRequest(string id,  string details,string transition,string state);
