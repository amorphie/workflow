using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using amorphie.core.Base;

namespace amorphie.workflow.core.Models
{
    public class FlowHeader: EntityBaseWithOutId
    {
        public string Key {get;set;} = string.Empty;
    }
}