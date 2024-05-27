

using amorphie.core.Base;
using NpgsqlTypes;
using Semver;

public class Workflow : EntityBaseWithOutId
{
    public string Name { get; set; } = string.Empty;
    public string[]? Tags { get; set; }
    public ICollection<Translation> Titles { get; set; } = default!;
    public ICollection<State> States { get; set; } = default!;
    public ZeebeMessage? ZeebeFlow { get; set; }
    public List<WorkflowEntity> Entities { get; set; } = default!;
    public WorkflowStatus? WorkflowStatus { get; set; }
    public ICollection<Translation> HistoryForms { get; set; } = default!;
    public NpgsqlTsVector? SearchVector { get; set; }
    public Guid? RecordId { get; set; }
    public bool? IsForbiddenData { get; set; }
    public string? SemVer {get;set;}

}



