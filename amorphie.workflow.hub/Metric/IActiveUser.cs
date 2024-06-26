using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace amorphie.workflow.hub.Metric
{
	public interface IActiveUser
{
        void Increment();
        void Decrement();

    }
}