using System;
using FlexRule.Flows;
using FlexRule.Flows.Model;
using FlexRule.Flows.Workflows.Model;
using FlexRule.Samples.CaseHandling.System;

namespace FlexRule.Samples.CaseHandling.Server.Controllers
{
    /// <summary>
    /// This controller process the accept request on a case 
    /// When accept message is recived from the service the processing of the 
    /// operation will be passed to this controller.
    /// </summary>
    class AcceptController : ServiceOperationController
    {
        public AcceptController(ICaseHandlingHostContext hostContext)
            : base(hostContext)
        {
        }
        public Assignment Process(Assignment co)
        {
            if (co == null)
                throw new ArgumentNullException("co");
            if (co.FlowInstanceIdentifier == null)
                throw new ArgumentNullException("co.FlowInstanceIdentifier");

            var signale = new ReceiverSignal("http://helpdesk/CaseHandling", "Accept", "AcceptAction");
            var context = Context.WorkflowManager.Resume(co.FlowInstanceIdentifier.Value, signale);
            
            
            if (context.State == FlowState.Waiting
                || context.State == FlowState.Completed)
            {
                Assignment assignment = null;
                // it was timeout
                if (context.State == FlowState.Waiting)
                {
                    assignment = null;
                }
                // it was accepted
                if (context.State == FlowState.Completed)
                {
                    assignment = (Assignment)context.VariableContainer["assignment"];
                }

                return assignment;

            }
            // send user friendly as a fault message in the service
            throw new Exception("Error occurred, we expected a suspend or completed state for workflow", context.Exception);
        }

    }
}
