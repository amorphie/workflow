using System.Text.Json.Nodes;

namespace amorphie.workflow.redisconsumer.StreamObjects;
public class JobBatchJobs
{
    public JsonObject CustomHeaders { get; set; } = default!;
    public JsonObject Variables { get; set; } = default!;
    public string BpmnProcessId { get; set; } = default!;
    public long ProcessInstanceKey { get; set; }
    public long ProcessDefinitionKey { get; set; }
    public long ElementInstanceKey { get; set; }
    public string ElementId { get; set; } = default!;
    public string? Type { get; set; }
}