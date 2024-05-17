using amorphie.core.Base;
using amorphie.workflow.core.Enums;

namespace amorphie.workflow.core.Models.Transfer;
public class TransferHistory : EntityBase
{
    public string Hash { get; set; } = default!;
    public string SubjectName { get; set; } = default!;
    public string RequestBody { get; set; } = default!;
    public string TransferringType { get; set; } = default!;
    public TransferStatus TransferStatus { get; set; }
    public string? SemVer { get; set; } = default!;
}
