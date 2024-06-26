using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace amorphie.workflow.core.Dtos;
public class SignalRResponseHistory : SignalRResponsePublic
{
    public string? fromStateName { get; set; }
    public string? toStateName { get; set; }
    public string? userReference { get; set; }
    public string? userName { get; set; }
}
