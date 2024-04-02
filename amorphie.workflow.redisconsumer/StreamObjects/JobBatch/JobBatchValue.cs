namespace amorphie.workflow.redisconsumer.StreamObjects;
public class JobBatchValue
{
    public List<JobBatchJobs> Jobs { get; set; } = default!;
    public string? Type { get; set; }
}