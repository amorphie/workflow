                                                                                   using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amorphie.workflow.redisconsumer.StreamObjects
{
    public class JobStream
    {
        public string Id { get; set; }
        public int PartitionId { get; set; }
        public JobValue Value { get; set; }
        public long Key { get; set; }
        public string ZeebeJobType { get; set; }

    }
    public class JobValue
    {
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public string ZeebeJobType { get; set; }

    }
}
