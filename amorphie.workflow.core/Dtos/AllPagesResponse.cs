using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace amorphie.workflow.core.Dtos;

public class AllPagesResponse
{
    public List<dynamic> PageComponentList { get; set; } = new List<dynamic>();
    public List<string> TemplateList { get; set; } = new List<string>();
}
