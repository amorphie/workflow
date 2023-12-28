using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace amorphie.workflow.redisconsumer.StreamObjects
{
    public class MessageSubscriptionStream
    {
        public string Id { get; set; }
        public int PartitionId { get; set; }
        public MessageSubscriptionValue Value { get; set; }
        public long Deadline { get; set; }
        public long Key { get; set; }
        public long Timestamp { get; set; }
        public int Position { get; set; }
        public string ValueType { get; set; }
        public int SourceRecordPosition { get; set; }
        public string Intent { get; set; }
        public string RejectionType { get; set; }
        public string RejectionReason { get; set; }
        public JsonObject Authorizations { get; set; }
        public int RecordVersion { get; set; }
        public string BrokerVersion { get; set; }
        public string RecordType { get; set; }
    }
    public class MessageSubscriptionValue
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
