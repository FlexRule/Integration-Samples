using System;
using System.Collections.Generic;
using System.Linq;
using FlexRule.Flows.Workflows;
using FlexRule.Flows.Workflows.Managers.Tasks;

namespace FlexRule.Samples.Task
{
    internal class InMemoryWorkRepository
    {
        [Serializable]
        internal class WorkEntity : IWork
        {
            public Participant Owner { get; set; }
            public string Id { get; set; }
            public ulong Revision { get; set; }
            public string WorkflowInstanceId { get; set; }
            public IWorkflowIdentity Identity { get; set; }
            public ITaskDefinition Task { get; set; }
            public IEnumerable<IWorkItem> WorkItems { get; set; }
        }

        [Serializable]
        internal class WorkItemEntity : IWorkItem
        {
            private string _outcome;
            public string Id { get; set; }
            public ulong Revision { get; set; }
            public Participant Participant { get; set; }
            public WorkItemStatus Status { get; set; }
            public DateTime? CompletedAt { get; set; }

            public string Outcome
            {
                get { return _outcome; }
                set
                {
                    _outcome = value;
                    if (value != null)
                    {
                        CompletedAt = DateTime.Now;
                        Status = WorkItemStatus.Done;
                    }
                }
            }
        }

        readonly List<WorkEntity> _db = new List<WorkEntity>();
        private static ulong wid = 0;
        private static ulong wiid = 0;

        public IWork Store(WorkEntity work)
        {
            if (work.Id == null)
            {
                wid++;
                work.Id = wid.ToString();
                foreach (var i in work.WorkItems)
                {
                    wiid++;
                    ((WorkItemEntity)i).Id = wiid.ToString();
                }
            }
            var found = _db.FirstOrDefault(x => x.Id == work.Id);
            if (found != null)
            {
                _db.Remove(found);
                _db.Add(found);
            }
            else
            {
                _db.Add(work);
            }
            return work;
        }

        public IList<WorkEntity> Works { get { return _db; } }

        public void Clear()
        {
            _db.Clear();
        }
    }

}