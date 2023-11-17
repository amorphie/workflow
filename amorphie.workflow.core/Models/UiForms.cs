using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using amorphie.workflow.core.Enums;

namespace amorphie.workflow.core.Models
{
    public class UiForm: amorphie.core.Base.EntityBase
    {
        public Transition? transition {get;set;}
        public string? transitionName {get;set;}
        public State? state {get;set;}
        public string? stateName {get;set;}
        public TypeofUiEnum typeofUiEnum {get;set;}
        public ICollection<amorphie.core.Base.Translation> Forms { get; set; } = default!;
    }
}