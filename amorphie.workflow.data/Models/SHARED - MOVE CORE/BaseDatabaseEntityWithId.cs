

public class BaseDbEntityWithId 
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public DateTime CreatedAt { get; set; }
    public Guid CreatedBy { get; set; }
    public Guid CreatedByBehalfOf { get; set; }

    public DateTime ModifiedAt { get; set; }
    public Guid ModifiedBy { get; set; }
    public Guid ModifiedByBehalfOf { get; set; }
}
