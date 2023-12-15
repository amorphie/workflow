using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace amorphie.workflow.core.Dtos;

public class SignalRRequest
{
    public string id { get; set; }
    public string source { get; set; }
    public string type { get; set; }
    public string subject { get; set; }
    public dynamic? data { get; set; }
}
