using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace amorphie.workflow.core.Enums
{
    public enum TransitionButtonType
    {
         [Description("forward")]
        Forward = 1,
        [Description("back")]
        Back = 2,
        [Description("cancel")]
        Cancel = 4,
    }
}