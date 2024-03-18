using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace amorphie.workflow.core.Constants;
public static class EventInfos
{
    public const string WorkerCompleted = "worker-completed";
    public const string WorkerStarted = "worker-started";
    public const string TransitionCompleted = "transition-completed";
    public const string TransitionCompletedWithError = "transition-completed-with-error";

}
