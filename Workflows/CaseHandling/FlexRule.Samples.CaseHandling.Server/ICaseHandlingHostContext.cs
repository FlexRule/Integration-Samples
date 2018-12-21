using FlexRule.Samples.CaseHandling.Server.Workflow;
using FlexRule.Samples.CaseHandling.System;

namespace FlexRule.Samples.CaseHandling.Server
{
    /// <summary>
    /// Each server host has some running context
    /// The commands on the operation would required 
    /// this service context to process the request
    /// </summary>
    internal interface ICaseHandlingHostContext
    {
        /// <summary>
        /// Service repository to case handling storage
        /// </summary>
        ICaseHandlingRepository CaseHandlingRepository { get; }

        /// <summary>
        /// Service uses this workflow to use the underlaying workflow implementation
        /// </summary>
        IWorkflowManager WorkflowManager { get; }
    }
}