namespace amorphie.workflow.redisconsumer.StreamObjects
{
    public class ProcessStream : BaseStream
    {
        public ProcessStreamValue Value { get; set; }
        public int SourceRecordPosition { get; set; }
        public string RecordType { get; set; }
        public string RejectionType { get; set; }
        public string RejectionReason { get; set; }
        public int Position { get; set; }
        public int Version { get; set; }

    }
    public class ProcessStreamValue
    {
        public int Version { get; set; }
        public string? BpmnProcessId { get; set; }
        public long ProcessInstanceKey { get; set; }
        public long ProcessDefinitionKey { get; set; }
        public string? ResourceName { get; set; }



    }
}
