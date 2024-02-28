using amorphie.core.Base;

public class InstanceEvent : EntityBaseLog
{
    public InstanceTransition InstanceTransition { get; set; } = default!;
    public Guid InstanceTransitionId { get; set; } = default!;

    public DateTime ExecutedAt { get; set; } = default!;
    public DateTime CompletedAt { get; set; } = default!;

    public int Duration { get; set; } = default!;

    public string InputData { get; set; } = default!;
    public string OutputData { get; set; } = default!;
    public string AdditionalData { get; set; } = default!;

    public string Status { get; set; } = default!;


}
