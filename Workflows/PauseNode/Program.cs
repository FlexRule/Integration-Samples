using System;
using System.IO;
using FlexRule.Flows;
using FlexRule.Flows.Workflows;


namespace FlexRule.Samples.LetterDataCollection
{
    /*
     * This example shows integration and running Workflow using Pause step.
     * For instance, Pause step allows you to grab information bit by bit form users.
     * 
     * In this example, user will be asked for Title and Body of a Letter step by step.
     * 
     */
    class Program
    {
        private string ContextFilename = "letter.workflow.context";

        static void Main(string[] args)
        {
            var app = new Program();
            var eng = RuntimeEngine.FromXml(File.OpenRead("LetterWorkflow.xml"));
            app.AskUserForDetails(eng, new Letter());

            Console.ReadLine();
        }

        private void AskUserForDetails(IRuntimeEngine eng, Letter letter)
        {
            var res = eng.Run(letter);
            var ctx = (WorkflowExecutionContext)res.Context;
            WriteContext(ctx);
            
            // Keep resuming the workflow while it is in the Suspended state
            while (ctx.State == FlowState.Suspended)
            {
                var state = (string)ctx.VariableContainer["state"];
                Console.Write("Enter '{0}' Message> ", state);
                
                // Get user input
                var value = Console.ReadLine();

                // Load the context from storage
                ctx = ReadContext();

                // update the value in the context
                switch (state.ToLower())
                {
                    case "title":
                        ((Letter)ctx.VariableContainer["letter"]).Title = value;
                        break;

                    case "body":
                        ((Letter)ctx.VariableContainer["letter"]).Body = value;
                        break;
                }

                // resume the workflow
                res = eng.Workflow.Resume(ctx);
                ctx = (WorkflowExecutionContext)res.Context;

                // update the context in the storage
                WriteContext(ctx);

                // and keep doing it until it is finished!
            }
            letter = (Letter)res.Context.VariableContainer["letter"];
            Console.WriteLine("State of workflow: {0}", ctx.State);
            Console.WriteLine("Letter:\r\n\t{0}\r\n\t{1}", letter.Title, letter.Body);
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
