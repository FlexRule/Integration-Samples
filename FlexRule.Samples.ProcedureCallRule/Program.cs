using System;
using System.IO;

namespace FlexRule.Samples.ProcedureCallRule
{
    /// <summary>
    /// This sample shows how 
    /// 1. A procedure logic calls to another procedure logic (CallProc)
    /// 2. How to enable tracing
    /// </summary>
    class Program
    {
        static string RulePath = Environment.CurrentDirectory + "\\FindNameAge.xml";
        static void Main(string[] args)
        {
            // initializing License for faster execution
            // so the other parts of framework will work with the
            // initialized license during execution
            FlexRule.License.UserLicense.Initialize();

            var p = new Program();
            var engine = RuntimeEngine.FromXml(File.OpenRead(RulePath));
            p.RunEngine(engine);

            Console.ReadLine();
        }

        /// <summary>
        /// RuntimeEngine class simplifies the integration and is a tread-safe class and one instance of it should be used to execute multiple requests.
        /// </summary>
        /// <param name="engine"></param>
        private void RunEngine(IRuntimeEngine engine)
        {
            var result = engine.Run("Joe");
            WriteResult(result.Context.VariableContainer);
        }


        private static void WriteResult(IVariableContainer container)
        {
            int age = (int)container["age"];
            Console.WriteLine("Age: {0}", age);
        }
    }
}
