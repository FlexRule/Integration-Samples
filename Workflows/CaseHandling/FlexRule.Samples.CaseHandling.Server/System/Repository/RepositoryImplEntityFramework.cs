using System;
using System.Collections.Generic;
using System.Linq;
using FlexRule.Samples.CaseHandling.Server.System.Repository.DataAccess;
using FlexRule.Samples.CaseHandling.System;

namespace FlexRule.Samples.CaseHandling.Server.System.Repository
{
    [Serializable]
    class RepositoryImplEntityFramework : ICaseHandlingRepository
    {
        public IEnumerable<CaseInfo> ListCases()
        {
            var list = new List<CaseInfo>();
            using (var ctx = new Server.System.Repository.DataAccess.CaseHandlingDatabaseContext())
            {
                var result = (from c in ctx.CaseEntities
                              select c).ToList();

                foreach (var c in result)
                    list.Add(EntityConvertorUtility.ConvertCaseInfo(c));
            }
            return list;
        }

        public CaseInfo CreateCase(CaseInfo caseInfo)
        {
            using (var ctx = new Server.System.Repository.DataAccess.CaseHandlingDatabaseContext())
            {
                if (caseInfo.Created == null)
                    caseInfo.Created = DateTime.Now;
                var c = new CaseEntity()
                    {
                        ID = Guid.NewGuid(),
                        Description = caseInfo.Description,
                        Task = caseInfo.Task,
                        ClientEmail = caseInfo.ClientAddress
                    };
                c.Created = caseInfo.Created.Value;
                ctx.CaseEntities.AddObject(c);
                ctx.SaveChanges();
                caseInfo.Identifier = c.ID;
                return caseInfo;
            }
        }

        public Assignment CreateAssignment(ExecutionContextInfo context, Assignment assignment)
        {
            if (assignment == null)
                throw new ArgumentNullException("assignment");

            if (assignment.Case == null || assignment.Case.Identifier == Guid.Empty)
                throw new ArgumentNullException("Assignment.Case.Identifier");

            if (assignment.Officer == null || assignment.Officer.Identifier == Guid.Empty)
                throw new ArgumentNullException("Assignment.Officer.Identifier");

            if (assignment.Assigned == null)
                assignment.Assigned = DateTime.Now;

            using (var ctx = new Server.System.Repository.DataAccess.CaseHandlingDatabaseContext())
            {
                var caseEntity = (from ca in ctx.CaseEntities where ca.ID == assignment.Case.Identifier select ca).FirstOrDefault();
                var officerEntity = (from of in ctx.OfficerEntities where of.ID == assignment.Officer.Identifier select of).FirstOrDefault();
                if (caseEntity == null || officerEntity == null)
                    throw new CaseHandlingException(string.Format("Case ({0}) or Officer ({1}) information not found provided by Workflow ({2})", assignment.Case.Identifier, assignment.Officer.Identifier, assignment.FlowInstanceIdentifier));
                var c = new AssignmentEntity()
                {
                    ID = Guid.NewGuid(),
                    Case = caseEntity,
                    Officer = officerEntity,
                    Active = true,
                    Assigned = assignment.Assigned,
                    FlowInstanceID = assignment.FlowInstanceIdentifier,
                };
                ctx.AssignmentEntities.AddObject(c);
                ctx.SaveChanges();
                assignment.Active = c.Active;
                assignment.Identifier = c.ID;

                return assignment;
            }
        }

        public void UpdateAssignment(ExecutionContextInfo context, Assignment assignment)
        {
            if (assignment == null)
                throw new ArgumentNullException("assignment");

            if (assignment.Identifier == Guid.Empty)
                throw new ArgumentNullException("Assignment.Identifier");
            
            using (var ctx = new Server.System.Repository.DataAccess.CaseHandlingDatabaseContext())
            {
                var assignmentEntity = (from c in ctx.AssignmentEntities where c.ID == assignment.Identifier select c).FirstOrDefault();
                if (assignmentEntity == null)
                    throw new CaseHandlingException(string.Format("Assignment ({0}) information not found provided by Workflow ({1})", assignment.Identifier, assignment.FlowInstanceIdentifier));
                var ca = assignmentEntity;
                ca.Accepted = assignment.Accepted;
                ca.Assigned = assignment.Assigned;
                ca.Active = assignment.Active;
                ca.FlowInstanceID = assignment.FlowInstanceIdentifier;
                ctx.SaveChanges();
            }
        }

        public IEnumerable<Assignment> ListAssignments(bool withDetail)
        {
            List<Assignment> list = new List<Assignment>();
            using (var ctx = new CaseHandlingDatabaseContext())
            {
                List<AssignmentEntity> results = (from co in ctx.AssignmentEntities select co).ToList();
                foreach (var res in results)
                {
                    var co = EntityConvertorUtility.ConvertCaseOfficer(res);
                    list.Add(co);
                    if (withDetail)
                    {
                        if (!res.CaseReference.IsLoaded)
                            res.CaseReference.Load();
                        co.Case = EntityConvertorUtility.ConvertCaseInfo(res.Case);

                        if (!res.OfficerReference.IsLoaded)
                        {
                            res.OfficerReference.Load();
                        }

                        co.Officer = EntityConvertorUtility.ConvertOfficer(res.Officer);
                        // loads the officer hierarchy to management
                        Officer officer = co.Officer;
                        OfficerEntity oe = res.Officer;
                        while (oe.ManagerReference != null)
                        {
                            if (!oe.ManagerReference.IsLoaded)
                                oe.ManagerReference.Load();
                            if (oe.Manager == null)
                                break;

                            officer.Manager = EntityConvertorUtility.ConvertOfficer(oe.Manager);
                            oe = oe.Manager;
                            officer = officer.Manager;
                        }
                    }
                }
            }
            return list;
        }

        public Officer CreateOfficer(Officer officer)
        {
            using (var ctx = new Server.System.Repository.DataAccess.CaseHandlingDatabaseContext())
            {
                OfficerEntity manager = null;
                if (officer.Manager != null)
                {
                    manager = (from m in ctx.OfficerEntities
                               where m.ID == officer.Manager.Identifier
                               select m).First();
                }
                var off = new OfficerEntity()
                    {
                        ID = Guid.NewGuid(),
                        Manager = manager,
                        Name = officer.Name,
                        Role = officer.Role,
                    };
                ctx.OfficerEntities.AddObject(off);
                ctx.SaveChanges();

                officer.Identifier = off.ID;
                return officer;
            }
        }

        public IEnumerable<Officer> ListOfficers()
        {
            var list = new List<Officer>();
            using (var ctx = new Server.System.Repository.DataAccess.CaseHandlingDatabaseContext())
            {

                var staffs = (from m in ctx.OfficerEntities
                              select m).ToList();
                Fill(list, staffs);
            }

            return list;
        }

        private void Fill(List<Officer> list, List<OfficerEntity> staffs)
        {
            foreach (var stf in staffs)
            {
                var officer = EntityConvertorUtility.ConvertOfficer(stf);
                officer.Manager = GetManager(staffs, stf);
                Officer mng = officer.Manager;
                while (mng != null)
                {
                    mng.Manager = GetManager(staffs, staffs.First(x => x.ID == mng.Identifier));
                    mng = mng.Manager;
                }
                list.Add(officer);
            }

            foreach (var officer in list)
                FillChilds(list, officer, officer);
        }

        private void FillChilds(List<Officer> list, Officer officer, Officer root)
        {
            var result = list.FirstOrDefault(x => x.Manager != null && x.Manager.Identifier == officer.Identifier);
            if (result == null)
                return;
            if (!root.Subordinate.Any(x => x.Identifier == result.Identifier))
                root.Subordinate.Add(result);
            FillChilds(list, result, root);
        }

        private Officer GetManager(List<OfficerEntity> staffs, OfficerEntity stf)
        {
            if (stf.Manager == null)
                return null;
            var mng = stf.Manager;
            var officer = EntityConvertorUtility.ConvertOfficer(mng);
            return officer;
        }

        public Assignment ReadAssignment(Assignment assignment)
        {
            if (assignment == null)
                throw new ArgumentNullException("assignment");

            var listAll = ListAssignments(true);
            return listAll.FirstOrDefault(x => x.Identifier == assignment.Identifier);
        }
    }
}
