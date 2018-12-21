using System;
using System.Collections.Generic;
using System.Linq;
using FlexRule.Flows.Workflows.Managers.Tasks;

namespace FlexRule.Samples.Task
{
    /// <summary>
    /// This repository should provide ways of retrieving users from your repository
    /// </summary>
    public class UserRepository : IDirectoryService
    {
        public IEnumerable<Participant> ListUsersByRole(IEnumerable<DirectoryServiceEntry> roles)
        {
            // i.e. list participant based on role
            //      in this example we don't use DS to query based on roles
            throw new NotImplementedException();
        }

        public IEnumerable<Participant> ListUsersByName(IEnumerable<DirectoryServiceEntry> names)
        {
            // i.e. load the participant form your database or service

            var participants = new List<Participant>();
            foreach (var p in names)
            {
                participants.Add(
                    new Participant(p.Name) { Email = p.Metadata["email"] }
                    );
            }
            return participants;
        }
    }

    public class TaskRepository : ITaskService
    {
        readonly InMemoryWorkRepository _dbContext = new InMemoryWorkRepository();
        public IWork CreateWorkItems(TaskContext context)
        {
            var work = CreateWorkEntityFromContext(context);
            _dbContext.Store(work);
            return work;
        }

        private static InMemoryWorkRepository.WorkEntity CreateWorkEntityFromContext(TaskContext context)
        {
            var work = new InMemoryWorkRepository.WorkEntity();
            var workItems = new List<IWorkItem>();
            var task = (IMultiParticipantTask) context.Task;
            work.Task = task;
            foreach (var p in task.Participants)
            {
                workItems.Add(new InMemoryWorkRepository.WorkItemEntity()
                {
                    Participant = (Participant) p,
                });
            }
            work.Owner = (Participant) context.Owner;
            work.WorkItems = workItems;
            return work;
        }

        public void UpdateWorkItem(IWorkItem workItem)
        {
            var found = _dbContext.Works.SelectMany(x => x.WorkItems).FirstOrDefault(x => x == workItem);
            if (found != null)
            {
                found.Outcome = workItem.Outcome;
                found.Status = workItem.Status;
                found.CompletedAt = workItem.CompletedAt;
            }
        }

        public IWork Load(WorkLoadParameters args)
        {
            return _dbContext.Works.SingleOrDefault(x => x.Id == args.WorkId);
        }
    }
}
