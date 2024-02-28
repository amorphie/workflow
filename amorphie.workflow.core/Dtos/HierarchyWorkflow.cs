using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace amorphie.workflow.core.Dtos
{
    public class HierarchyState
    {
        public string StateName { get; set; } = string.Empty;
        public List<HierarchyTransition>? Transitions { get; set; }
    }
    public class HierarchyTransition
    {
        public string? TransitionName { get; set; } = string.Empty;
        public string? ToStateName { get; set; } = string.Empty;
        public HierarchyState? ToState { get; set; }
    }
}