using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amorphie.workflow.core.Constants
{
    public static class ZeebeStreamKeys
    {
        private const string GateWayPrefix = "zeebe:";

        public static string PROCESS_INSTANCE => $"{GateWayPrefix}PROCESS_INSTANCE";

        public static string MESSAGE_START_EVENT_SUBSCRIPTION => $"{GateWayPrefix}MESSAGE_START_EVENT_SUBSCRIPTION";
        public static string MESSAGE_SUBSCRIPTION => $"{GateWayPrefix}MESSAGE_SUBSCRIPTION";
        public static string MESSAGE => $"{GateWayPrefix}MESSAGE";

        #region Groups
        public const string PROCESS_INSTANCE_GROUP = "PROCESS_INSTANCE_GROUP";
        public const string MESSAGE_START_EVENT_SUBSCRIPTION_GROUP = "MESSAGE_START_EVENT_SUBSCRIPTION_GROUP";
        public const string MESSAGE_SUBSCRIPTION_GROUP = "MESSAGE_SUBSCRIPTION_GROUP";
        public const string MESSAGE_GROUP = "MESSAGE_GROUP";

        #endregion

    }
}
