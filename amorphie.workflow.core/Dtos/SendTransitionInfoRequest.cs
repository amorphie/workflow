using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace amorphie.workflow.core.Dtos
{
    public class SendTransitionInfoRequest
    {
        public Guid recordId {get;set;}
        public dynamic? entityData {get;set;}
        public string newStatus {get;set;}=default!;
        public Guid? user {get;set;}
        public Guid? behalfOfUser {get;set;}
        public string  workflowName {get;set;}=default!;

    }
}