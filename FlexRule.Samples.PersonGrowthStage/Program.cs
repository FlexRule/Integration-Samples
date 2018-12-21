using System;
using System.IO;
using System.Linq;
using FlexRule.Events;

namespace FlexRule.Samples.PersonAge
{
    class Program
    {
        // You should cache this instance and reuse it for subsequent requests

        static void Main(string[] args)
        {
            // initializing License for faster execution
            // so the other parts of framework will work with the
            // initialized license during execution
            FlexRule.License.UserLicense.Initialize();

            Console.WriteLine("--");
            RunByExcelDecisionTable();
            Console.WriteLine("--");
            RunByXmlDecisionTable();
            Console.ReadLine();
        }

        private static void RunByExcelDecisionTable()
        {
            Console.WriteLine("Decision table using EXCEL...");
            // Loading decision table from excel document
            IRuntimeEngine engine = RuntimeEngine.FromSpreadSheet(File.OpenRead("AgeTitle.xlsx"), "Sheet1");

            // set events to be captured
            engine.EnableFullLog = true;

            // executing the decision table
            ExecuteDecisionTable(engine);
        }

        private static void RunByXmlDecisionTable()
        {
            Console.WriteLine("Decision table using XML...");
            // Loading decision table from excel document
            IRuntimeEngine engine = RuntimeEngine.FromXml(File.OpenRead("AgeTitle.xml"), "Sheet1");

            // set events to be captured
            engine.EnableFullLog = true;

            // executing the decision table
            ExecuteDecisionTable(engine);
        }

        static private void ExecuteDecisionTable(IRuntimeEngine engine)
        {
            // getting a fact
            var person = new { Age = 10 };

            // running the fact against decision table
            var result = engine.Run(person);

            // read values from context
            var title = result.Context.VariableContainer["title"];

            Console.WriteLine("Title: {0}", title);

            Console.WriteLine();
            Console.WriteLine("** Events Log: {0} events are created.", result.Events.Count());
            Console.WriteLine("** Below log is generated based on events:");
            Console.WriteLine(result.ConclusionLog);
        }

    }
}
