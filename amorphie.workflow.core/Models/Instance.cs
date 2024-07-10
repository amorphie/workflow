

using System.ComponentModel.DataAnnotations.Schema;
using amorphie.core.Base;
using NpgsqlTypes;
namespace amorphie.workflow.core.Models;
public class Instance : EntityBase
{
    public Workflow Workflow { get; set; } = default!;
    public string WorkflowName { get; set; } = default!;

    public ZeebeMessage? ZeebeFlow { get; set; }
    public string? ZeebeFlowName { get; set; }

    public string EntityName { get; set; } = default!;

    public Guid RecordId { get; set; } = default!;

    public State State { get; set; } = default!;
    public string StateName { get; set; } = default!;

    public amorphie.core.Enums.StatusType BaseStatus { get; set; } = default!;
    public NpgsqlTsVector? SearchVector { get; set; }
    public string? UserReference { get; set; }
    public string? FullName { get; set; }
    public ICollection<Note>? Notes { get; set; }
    public long? ProcessInstanceKey {get;set;}
    [Column(TypeName = "jsonb")]
    public string InstanceData { get; set; } = default!;

}



