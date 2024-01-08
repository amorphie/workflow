using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace amorphie.workflow.core.Models;

public class TransitionRole : amorphie.core.Base.EntityBase
{
    public string? TransitionName {get;set;}
    public Transition? Transition {get;set;}
    public string? Role {get;set;}
}
