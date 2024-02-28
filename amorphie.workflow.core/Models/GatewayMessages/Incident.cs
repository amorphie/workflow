namespace amorphie.workflow.core.Models.GatewayMessages;

public class Incident
{

    public long Key { get; set; }

    public string? BpmnProcessId { get; set; }
    public long ProcessInstanceKey { get; set; }
    public long ProcessDefinitionKey { get; set; }
    /// <summary>
    /// Incident occured element
    /// </summary>
    public long ElementInstanceKey { get; set; }
    public string? ElementId { get; set; }

    public long Timestamp { get; set; }
    public string? RejectionReason { get; set; }

    public string? ErrorMessage { get; set; }
    public string? ErrorType { get; set; }
}