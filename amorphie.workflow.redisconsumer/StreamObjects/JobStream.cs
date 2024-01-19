namespace amorphie.workflow.redisconsumer.StreamObjects
{
    public class JobStream : BaseStream
    {
        public JobValue Value { get; set; }
        public string? ZeebeJobType { get; set; }

    }
    public class JobValue
    {
        public string? ErrorCode { get; set; }
        public string? ErrorMessage { get; set; }
        public string? ZeebeJobType { get; set; }

    }
}
