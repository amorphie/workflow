using System.Text.Json.Nodes;

namespace amorphie.workflow.redisconsumer.StreamObjects
{
    public class JobStream : BaseStream
    {
        public JobValue Value { get; set; }
    }
    public class JobValue
    {
        public string? BpmnProcessId { get; set; }
        public string? ErrorCode { get; set; }
        public string? ErrorMessage { get; set; }
        public string? ZeebeJobType { get; set; }
        public string? ElementId { get; set; }
        public string? Type { get; set; }
        public long ElementInstanceKey { get; set; }
        public long ProcessInstanceKey { get; set; }
        public JsonObject CustomHeaders { get; set; } = default!;

    }
}
