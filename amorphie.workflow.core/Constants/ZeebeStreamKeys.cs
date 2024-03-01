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
        public static string GateWay = "zeebe";
        public class Streams
        {

            public static string DEPLOYMENT => $"{GateWayPrefix}DEPLOYMENT";
            public static string INCIDENT => $"{GateWayPrefix}INCIDENT";
            public static string JOB => $"{GateWayPrefix}JOB";
            public static string JOB_BATCH => $"{GateWayPrefix}JOB_BATCH";
            public static string MESSAGE => $"{GateWayPrefix}MESSAGE";
            public static string MESSAGE_START_EVENT_SUBSCRIPTION => $"{GateWayPrefix}MESSAGE_START_EVENT_SUBSCRIPTION";
            public static string MESSAGE_SUBSCRIPTION => $"{GateWayPrefix}MESSAGE_SUBSCRIPTION";
            public static string PROCESS => $"{GateWayPrefix}PROCESS";
            public static string PROCESS_EVENT => $"{GateWayPrefix}PROCESS_EVENT";
            public static string PROCESS_INSTANCE => $"{GateWayPrefix}PROCESS_INSTANCE";
            public static string PROCESS_MESSAGE_SUBSCRIPTION => $"{GateWayPrefix}PROCESS_MESSAGE_SUBSCRIPTION";
            public static string VARIABLE => $"{GateWayPrefix}VARIABLE";
            public static string VARIABLE_DOCUMENT => $"{GateWayPrefix}VARIABLE_DOCUMENT";
        }
        public class Groups
        {

            #region Groups
            public const string DEPLOYMENT_GROUP = "DEPLOYMENT_GROUP";
            public const string INCIDENT_GROUP = "INCIDENT_GROUP";
            public const string JOB_GROUP = "JOB_GROUP";
            public const string JOB_BATCH_GROUP = "JOB_BATCH_GROUP";
            public const string MESSAGE_GROUP = "MESSAGE_GROUP";
            public const string MESSAGE_START_EVENT_SUBSCRIPTION_GROUP = "MESSAGE_START_EVENT_SUBSCRIPTION_GROUP";
            public const string MESSAGE_SUBSCRIPTION_GROUP = "MESSAGE_SUBSCRIPTION_GROUP";
            public const string PROCESS_GROUP = "PROCESS_GROUP";
            public const string PROCESS_EVENT_GROUP = "PROCESS_EVENT_GROUP";
            public const string PROCESS_INSTANCE_GROUP = "PROCESS_INSTANCE_GROUP";
            public const string VARIABLE_GROUP = "VARIABLE_GROUP";
            public const string VARIABLE_DOCUMENT_GROUP = "VARIABLE_DOCUMENT_GROUP";

            #endregion
        }

    }
}
