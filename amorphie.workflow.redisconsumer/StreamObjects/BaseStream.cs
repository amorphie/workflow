using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amorphie.workflow.redisconsumer.StreamObjects
{
    public class BaseStream
    {
        public string Id { get; set; } = default!;
        public int PartitionId { get; set; }
        public string? Intent { get; set; }
        public string? ValueType { get; set; }
        /// <summary>
        /// Element specific
        /// </summary>
        public long Key { get; set; }
        /// <summary>
        /// Event creation time in long format
        /// </summary>
        public long Timestamp { get; set; }
        public string? BrokerVersion { get; set; }


    }
}
