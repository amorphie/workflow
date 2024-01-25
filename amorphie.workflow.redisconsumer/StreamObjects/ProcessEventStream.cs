namespace amorphie.workflow.redisconsumer.StreamObjects
{
    public class ProcessEventStream : BaseStream
    {
        public ProcessEventValue Value { get; set; }
        public int SourceRecordPosition { get; set; }
        public string RecordType { get; set; }
        public string RejectionType { get; set; }
        public string RejectionReason { get; set; }
        public int Position { get; set; }
    }
    public class ProcessEventValue
    {
        public int Version { get; set; }
        public string BpmnProcessId { get; set; }
        public long ProcessInstanceKey { get; set; }
        public long ProcessDefinitionKey { get; set; }
        public string ElementId { get; set; }
        public long FlowScopeKey { get; set; }
        public string BpmnElementType { get; set; }
        public string BpmnEventType { get; set; }
        public long ParentProcessInstanceKey { get; set; }
        public long ParentElementInstanceKey { get; set; }


    }
}
