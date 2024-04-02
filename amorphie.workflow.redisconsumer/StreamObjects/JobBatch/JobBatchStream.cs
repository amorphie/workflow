using System.Text.Json.Nodes;

namespace amorphie.workflow.redisconsumer.StreamObjects;
public class JobBatchStream : BaseStream
{
    public JobBatchValue Value { get; set; } = default!;
    public int SourceRecordPosition { get; set; }
    public string? RecordType { get; set; }
    public int RecordVersion { get; set; }
    public string? RejectionType { get; set; }
    public string? RejectionReason { get; set; }
    public int Position { get; set; }
    public JsonObject? Authorizations { get; set; }
}