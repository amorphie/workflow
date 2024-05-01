using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using amorphie.workflow.core.Enums;

namespace amorphie.workflow.core.Models;
public class HumanTask
{
    public Guid TaskId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public HumanTaskStatus? Status { get; set; }=HumanTaskStatus.Pending;
    public HumanTaskType? Type { get; set; }=HumanTaskType.SelfSelected;
    public string? Assignee { get; set; }
    public string[]? Roles { get; set; }
    public Guid? CreatedBy { get; set; }
    public DateTime? CreatedAt { get; set; }=DateTime.UtcNow;
    public DateTime? DueBy { get; set; }=DateTime.MaxValue;
    public HumanTaskPriority? Priority { get; set; }=HumanTaskPriority.Low;
    public Guid? InstanceId { get; set; }
    public bool? AutoTransaction { get; set; }=false;
    public int? AutoTransactionTimeout { get; set; } =0;
    public string? State { get; set; }
    public string? HumanTaskAppTransition { get; set; }

    public string? Metadata { get; set; }

}
