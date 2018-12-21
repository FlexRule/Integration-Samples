using System;
using FlexRule.Flows;
using FlexRule.Flows.Workflows;
using FlexRule.Samples.CaseHandling.System;

namespace FlexRule.Samples.CaseHandling.Server.Controllers
{
    /// <summary>
    /// This controller handles operation for recording a new case
    /// </summary>
    class LaunchCaseController : ServiceOperationController
    {
        public LaunchCaseController(ICaseHandlingHostContext hostContext)
            : base(hostContext)
        {
        }
        public object Process(string title, string description, string clientEmail)
        {
            // 1. We create a new case based on user support input
            var ci = CreateNewCase(title, description, clientEmail);

            // 2. We create an flow to process the newly created case
            var context = Context.WorkflowManager.New(Context.CaseHandlingRepository, ci, null);
            if (context.State == FlowState.Waiting)
            {
                if (context.WorkflowInstanceId == null)
                    throw new Exception("Could not store workflow state");
             
                return true;
            }
            // send user friendly as a fault message in the service
            throw new Exception("Error occurred, we expected a suspend state for workflow", context.Exception);
        }

        
        private CaseInfo CreateNewCase(string title, string description, string clientEmail)
        {
            CaseInfo ci = new CaseInfo()
                {
                    Task = title,
                    Description = description,
                    ClientAddress = clientEmail,
                };

            Context.CaseHandlingRepository.CreateCase(ci);
            return ci;
        }
    }
}
