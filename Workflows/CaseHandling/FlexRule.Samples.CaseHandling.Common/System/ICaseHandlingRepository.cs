using System.Collections.Generic;

namespace FlexRule.Samples.CaseHandling.System
{
    /// <summary>
    /// This is a main interface to the case handling data store
    /// Service uses this interface to communicate to storage for managing a case
    /// </summary>
    public interface ICaseHandlingRepository
    {
        // officers
        Officer CreateOfficer(Officer officer);
        IEnumerable<Officer> ListOfficers();

        // cases
        IEnumerable<CaseInfo> ListCases();
        CaseInfo CreateCase(CaseInfo caseInfo);

        // case officers
        Assignment CreateAssignment(ExecutionContextInfo context, Assignment assignment);
        void UpdateAssignment(ExecutionContextInfo context, Assignment assignment);
        IEnumerable<Assignment> ListAssignments(bool withDetail);
        Assignment ReadAssignment(Assignment assignment);
    }
}
