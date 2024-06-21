using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace amorphie.workflow.core.Dtos.HumanTasks;
    public class HumanTaskDto :amorphie.workflow.core.Models.HumanTask
    {
        public ViewTransitionModel? ApproveView {get;set;}
        public ViewTransitionModel? RejectView {get;set;}
        public dynamic? lastEntityData {get;set;}
        public dynamic? lastAdditionalData {get;set;}
    }
