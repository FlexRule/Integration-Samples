using System.Collections.Generic;
using FlexRule.Samples.CaseHandling.Server.System.Repository.DataAccess;
using FlexRule.Samples.CaseHandling.System;

namespace FlexRule.Samples.CaseHandling.Server.System.Repository
{
    /// <summary>
    /// This class helps converting: Entity -> POCO
    /// </summary>
    static class EntityConvertorUtility
    {
        static internal CaseInfo ConvertCaseInfo(CaseEntity c)
        {
            var ci = new CaseInfo()
                    {
                        Identifier = c.ID,
                        ClientAddress = c.ClientEmail,
                        Created = c.Created,
                        Description = c.Description,
                        Task = c.Task,
                        Finished = c.Finished
                    };
            return ci;
        }

        static internal Assignment ConvertCaseOfficer(AssignmentEntity res)
        {
            var co = new Assignment
                       {
                           Identifier = res.ID,
                           Accepted = res.Accepted,
                           Assigned = res.Assigned,
                           Active = res.Active,
                           FlowInstanceIdentifier = res.FlowInstanceID
                       };


            return co;
        }


        static internal Officer ConvertOfficer(OfficerEntity officer)
        {
            return new Officer()
                {
                    Identifier = officer.ID,
                    Role = officer.Role,
                    Name = officer.Name,
                    Manager = null,
                    Subordinate = new List<Officer>()
                };

        }
    }
}