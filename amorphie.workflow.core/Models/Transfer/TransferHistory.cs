using amorphie.core.Base;
using amorphie.workflow.core.Enums;

namespace amorphie.workflow.core.Models.Transfer;
public class TransferHistory : EntityBase
{
    public string Hash { get; set; } = default!;
    public string WorkflowName { get; set; } = default!;
    public string RequestBody { get; set; } = default!;
    public TransferStatus TransferStatus { get; set; }
}
