using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amorphie.workflow.redisconsumer.StreamExporters
{
    public interface IExporter
    {
        Task Attach(IDatabase redisDb, CancellationToken cancellationToken);
    }
}
