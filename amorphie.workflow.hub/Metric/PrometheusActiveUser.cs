using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Prometheus;

namespace amorphie.workflow.hub.Metric
{
	public class PrometheusActiveUser : IActiveUser
    {
        private static readonly Gauge ActiveUsers = Metrics.CreateGauge("active_users", "Number of active SignalR users.");
        private static int _connectedUsers = 0;

		public void Increment()
		{
            Interlocked.Increment(ref _connectedUsers);
            ActiveUsers.Set(_connectedUsers);
        }
        public void Decrement()
        {
            Interlocked.Decrement(ref _connectedUsers);
            ActiveUsers.Set(_connectedUsers);
        }
    }
}