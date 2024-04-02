namespace amorphie.workflow.core.Models.GatewayMessages;

public class JobBatch
{

    public long Key { get; set; }
    public long ElementInstanceKey { get; set; }
    public long Timestamp { get; set; }
    public long EndTimestamp { get; set; }

    public int Retries { get; set; }

    public string? BpmnProcessId { get; set; }
    public string? ElementType { get; set; }
    public string? Intent { get; set; }
    public long ProcessInstanceKey { get; set; }
    public string? Variables { get; set; }
    public string? CustomHeaders { get; set; }

}