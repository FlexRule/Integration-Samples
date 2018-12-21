using System;
using FlexRule.Flows;
using System.Collections.Generic;
using FlexRule.Flows.Workflows;
using FlexRule.Flows.Workflows.Model;

namespace FlexRule.Samples.CaseHandling.Server.Workflow
{
    /// <summary>
    /// Main contract model that service uses to communicate to workflow
    /// </summary>
    public interface IWorkflowManager
    {
        /// <summary>
        /// This creates an instance of engine for processing the flow
        /// </summary>
        /// <returns></returns>
        WorkflowExecutionContext New(params object[] inputs);

        /// <summary>
        /// This creates an instance of engine for processing the previously stored flow
        /// </summary>
        /// <returns></returns>
        WorkflowExecutionContext Resume(Guid instanceId, IReceiverSignal signal);

        /// <summary>
        /// Lists all the process ids from workflow store
        /// </summary>
        /// <param name="instanceIds"></param>
        /// <returns></returns>
        IEnumerable<Guid> ListAvailables(IEnumerable<Guid> instanceIds);
    }
}