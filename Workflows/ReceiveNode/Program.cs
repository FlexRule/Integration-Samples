using System;
using System.IO;
using System.Linq;
using FlexRule.Flows;
using FlexRule.Flows.Workflows;
using FlexRule.Flows.Workflows.Model;

namespace FlexRule.Samples.Receive
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
        private string ContextFilename = "Application.workflow.context";

        static void Main(string[] args)
        {
            var app = new Program();
            var eng = RuntimeEngine.FromXml(File.OpenRead("ApplicationWorkflow.xml"));
            app.AskOptions(eng, new Application());

            Console.ReadLine();
        }

        private void AskOptions(IRuntimeEngine eng, Application app)
        {
            var res = eng.Run(app);
            var ctx = (WorkflowExecutionContext)res.Context;
            WriteContext(ctx);

            // Keep resuming the workflow while it is in the Waiting state
            while (ctx.State == FlowState.Waiting)
            {
                // Retrieve the available options from the Workflow
                var options = ctx.GetReceivers().ToList();
                Console.WriteLine("Please select options below:");
                for (int index = 0; index < options.Count; index++)
                {
                    var op = options[index];
                    Console.WriteLine("({0}) {1} ({2})", index + 1, op.Title, op.DisplayName);
                }
                Console.Write("Select the number>");
                // Get user input
                var value = Console.ReadLine();

                int selection = 0;
                if (int.TryParse(value, out selection))
                {
                    // Load the context from storage
                    ctx = ReadContext();

                    // creating a signal
                    var signal = new ReceiverSignal(options[selection - 1].Title);

                    // resume the workflow using a signal
                    res = eng.Workflow.Resume(ctx, signal);
                }

                ctx = (WorkflowExecutionContext)res.Context;

                // update the context in the storage
                WriteContext(ctx);

                // and keep doing it until it is finished!
            }
            app = (Application)res.Context.VariableContainer["app"];
            Console.WriteLine("Your application is: {0}", app.Status);
            Console.WriteLine("State of workflow: {0}", ctx.State);
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
