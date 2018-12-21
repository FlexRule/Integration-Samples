using System;
using System.IO;
using System.Linq;
using FlexRule.Flows;
using FlexRule.Flows.Workflows;
using FlexRule.Flows.Workflows.Managers.Tasks;
using FlexRule.Flows.Workflows.Model;

namespace FlexRule.Samples.Task
{
    /*
     * This example shows integration and running Workflow using Receive nodes.
     * Receive node allows running couple of options is parallel and ask user for options.
     * 
     * In this example, the operator user will decide on Approval or Rejection of an application.
     * 
     */
    class Program
    {
        private string ContextFilename = "voting.workflow.context";

        static void Main(string[] args)
        {
            var app = new Program();
            var eng = RuntimeEngine.FromXml(File.OpenRead("VotingWorkflow.xml"));
            eng.Workflow.Registry.AddService<ITaskService>(new TaskRepository());
            eng.Workflow.Registry.AddService<IDirectoryService>(new UserRepository());
            app.Vote(eng);

            Console.ReadLine();
        }

        private void Vote(IRuntimeEngine eng)
        {
            // Run the workflow voting on majority vote 50% and higher decide on the output
            var votingThreshold = 0.5;
            var res = eng.Run(votingThreshold);

            var ctx = (WorkflowExecutionContext)res.Context;
            WriteContext(ctx);

            // Keep resuming the workflow while it is in the Waiting state
            while (ctx.State == FlowState.Waiting)
            {
                // Retrieve the available options from the Workflow
                var task = ctx.GetReceivers().ToList();
                Console.WriteLine("Please select options below:");
                var workIdentity = task[0];
                var outcomes = workIdentity.Outcomes;
                var service = eng.Workflow.Registry.GetService<ITaskService>();
                var options = outcomes.Select(x => x.Name).ToArray();
                var work = service.Load(new WorkLoadParameters() { Category = workIdentity.Category, Name = workIdentity.Name, Title = workIdentity.Title });
                foreach (var wi in work.WorkItems.Where(x => x.Status == WorkItemStatus.PenddingResponse))
                {
                    var actor = wi.Participant.Name;
                    Console.WriteLine("{0} ({1})", actor, string.Join("/", options));
                }

                Console.Write("Select answer in this format:User Answer\r\nFor example enter 'Arash Yes' will send the Arash's answer as Yes to workflow.\r\nAnswer>");
                // Get user input
                var value = Console.ReadLine();

                var workItem = UpdateWorkItem(work, value, options);
                if (workItem != null)
                {
                    // Load the context from storage
                    ctx = ReadContext();

                    // creating a signal
                    var signal = new ReceiverSignal(workIdentity.Title) { Outcome = workItem.Outcome };

                    // resume the workflow using a signal
                    res = eng.Workflow.Resume(ctx, signal);

                    ctx = (WorkflowExecutionContext)res.Context;

                    // update the context in the storage
                    WriteContext(ctx);
                }

                // and keep doing it until it is finished!
                Console.WriteLine();
            }

            Console.WriteLine("State of workflow: {0}", ctx.State);
        }

        private IWorkItem UpdateWorkItem(IWork work, string value, string[] options)
        {
            var items = value.Split(' ');
            if (items.Length != 2)
                return null;
            var actor = items[0].Trim();
            var answer = items[1].Trim();

            answer = options.FirstOrDefault(x => String.Compare(x, answer, StringComparison.OrdinalIgnoreCase) == 0);
            if (answer == null)
                return null;

            var wi = work.WorkItems.SingleOrDefault(x => String.Compare(x.Participant.Name, actor, StringComparison.OrdinalIgnoreCase) == 0);
            if (wi == null)
                return null;
            wi.Outcome = answer;
            return wi;
        }

        private void WriteContext(WorkflowExecutionContext ctx)
        {
            // Get the context binary form
            var context = ctx.Serialize();
            // Save context on a storage for later use
            File.WriteAllBytes(ContextFilename, context);
        }

        private WorkflowExecutionContext ReadContext()
        {
            var context = File.ReadAllBytes(ContextFilename);
            return WorkflowExecutionContext.Deserialize(context);
        }
    }
}
