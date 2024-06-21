using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using amorphie.workflow.core.Enums;

namespace amorphie.workflow.core.Models
{
    public class UiForm : amorphie.core.Base.EntityBase
    {
        public Transition? Transition { get; set; }
        public string? TransitionName { get; set; }
        public State? State { get; set; }
        public string? StateName { get; set; }
        public NavigationType? Navigation { get; set; }
        public TypeofUiEnum? TypeofUiEnum { get; set; }
        public string? Role {get;set;}
        public ICollection<amorphie.core.Base.Translation>? Forms { get; set; } = default!;
    }
}