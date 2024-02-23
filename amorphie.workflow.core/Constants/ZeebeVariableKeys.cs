using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amorphie.workflow.core.Constants
{
    public static class ZeebeVariableKeys
    {
        public const string TriggeredBy = "TriggeredBy";
        public const string TriggeredByBehalfOf = "TriggeredByBehalfOf";
        public const string InstanceId = "InstanceId";
        public const string PageUrl = "PageUrl";
        public const string Message = "Message";
        public const string message = "message";
        public const string ErrorCode = "ErrorCode";
        public const string RecordId = "RecordId";
        public const string LastTransition = "LastTransition";
        public const string AmorphieHttpWorker = "amorphie-http-worker";

    }
}
