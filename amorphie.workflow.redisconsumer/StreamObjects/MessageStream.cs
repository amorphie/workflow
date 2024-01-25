using System.Text.Json.Nodes;

namespace amorphie.workflow.redisconsumer.StreamObjects
{
    public class MessageStream : BaseStream
    {
        public MessageValue Value { get; set; }
        public long Deadline { get; set; }
        public int Position { get; set; }
        public int SourceRecordPosition { get; set; }
        public string RejectionType { get; set; }
        public string RejectionReason { get; set; }
        public JsonObject Authorizations { get; set; }
        public int RecordVersion { get; set; }
        public string RecordType { get; set; }
    }
    public class MessageValue
    {
        public string TenantId { get; set; }
        public JsonObject Variables { get; set; }
        public string BpmnProcessId { get; set; }

        public long ProcessInstanceKey { get; set; }
        public long ProcessDefinitionKey { get; set; }

        public string ElementId { get; set; }
        public string MessageName { get; set; }
        public long MessageKey { get; set; }
        public string CorrelationKey { get; set; }
    }
}
