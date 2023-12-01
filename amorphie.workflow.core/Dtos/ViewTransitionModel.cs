using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using amorphie.workflow.core.Enums;


public class ViewTransitionModel
{
    public string? name { get; set; }
    public string? type { get; set; }
    public string? language { get; set; }
    public string? navigation { get; set; }
    public string? data { get; set; }
    public dynamic? body { get; set; }
}
