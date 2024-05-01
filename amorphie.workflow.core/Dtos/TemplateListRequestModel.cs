using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace amorphie.workflow.core.Dtos;
public class TemplateListRequestModel
{
    public bool IsPage { get; set; } = false;
    public string[]? workflowNames { get; set; }
    public string? environmentFrom { get; set; }
    public string? environmentTo { get; set; }
    public List<string>? extraTemplates { get; set; }
}
