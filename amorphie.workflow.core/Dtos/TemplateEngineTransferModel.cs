using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace amorphie.workflow.core.Dtos;

public class TemplateEngineTransferModel
{
    public string? TemplateName { get; set; }
    public string? TransferFromUrl { get; set; }
    public string? TransferToUrl { get; set; }
}
