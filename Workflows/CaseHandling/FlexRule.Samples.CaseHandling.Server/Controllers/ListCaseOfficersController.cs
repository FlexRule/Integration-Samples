using System.Collections.Generic;
using FlexRule.Samples.CaseHandling.System;

namespace FlexRule.Samples.CaseHandling.Server.Controllers
{
    /// <summary>
    /// This controller lists all the cases. 
    /// This will be used for monitoring of the cases and officers
    /// </summary>
    class ListCaseOfficersController : ServiceOperationController
    {
        public ListCaseOfficersController(ICaseHandlingHostContext hostContext)
            : base(hostContext)
        {
        }
        public IEnumerable<Assignment> Process()
        {
            return Context.CaseHandlingRepository.ListAssignments(true);
        }
    }
}
