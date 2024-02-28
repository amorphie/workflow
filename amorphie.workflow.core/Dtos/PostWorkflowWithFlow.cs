using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

public class PostWorkflowWithFlow
{
    public Guid recordId { get; set; }
    public DtoSaveWorkflowWithFlow? entityData { get; set; }
    [Required]
    public string newStatus { get; set; } = default!;
    public Guid? user { get; set; }
    public Guid? behalfOfUser { get; set; }
    [Required]
    public string workflowName { get; set; } = default!;
}

public class PostWorkflowWithFlowDynamic
{
    public Guid recordId { get; set; }
    public dynamic? entityData { get; set; }
    [Required]
    public string newStatus { get; set; } = default!;
    public Guid? user { get; set; }
    public Guid? behalfOfUser { get; set; }
    [Required]
    public string workflowName { get; set; } = default!;
}