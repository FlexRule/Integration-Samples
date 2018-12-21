using FlexRule.Flows;
using FlexRule.Samples.CaseHandling.System;

namespace FlexRule.Samples.CaseHandling.Server.Controllers
{
    /// <summary>
    /// All service controller base that shares the same running service context.
    /// All controllers that process a service operation have to implement this
    /// </summary>
    abstract class ServiceOperationController
    {
        protected ICaseHandlingHostContext Context { get; private set; }
        protected ServiceOperationController(ICaseHandlingHostContext context)
        {
            Context = context;
        }
    }
}