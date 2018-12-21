using System;
using System.Collections.Generic;
using System.Linq;
using FlexRule.Samples.CaseHandling.System;

namespace FlexRule.Samples.CaseHandling.Server.Controllers
{
    /// <summary>
    /// This controller handles listing the available cases 
    /// for an officer that he/she can accept them.
    /// </summary>
    class ListAcceptableController : ServiceOperationController
    {
        public ListAcceptableController(ICaseHandlingHostContext hostContext)
            : base(hostContext)
        {
        }
        public IEnumerable<Assignment> Process()
        {
            // we filter the list for a particular user
            // the caseofficer must be:
            // 1. Active, means it has not been take out of the officer yet
            // 2. Has workflow: means the item has a workflow assigned to it

            var list = Context.CaseHandlingRepository.ListAssignments(true)
                .Where(x => x.FlowInstanceIdentifier != null
                        && x.Active
                        && x.Assigned != null);

            if (list.Any())
            {
                // Now, we have to make sure all this workflowInstanceIdentifiers
                // are in suspend mode not any other states e.g. Completed or Fault...
                IEnumerable<Guid> allAvailables =
                    Context.WorkflowManager.ListAvailables(list.Select(x => (Guid) x.FlowInstanceIdentifier));

                // Filter out the invalid caseofficers based on workflow instances
                list = list.Where(x => allAvailables.Contains(x.FlowInstanceIdentifier.Value));
            }
            return list;
        }
    }
}
