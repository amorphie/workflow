

public class BaseDbLogEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    public DateTime CreatedAt { get; set; } = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc);

    public Guid CreatedBy { get; set; }
    public Guid? CreatedByBehalfOf { get; set; }
}