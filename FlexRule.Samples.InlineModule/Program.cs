using System;
using System.Linq;
using FlexRule.Core.Languages.Xml;
using FlexRule.Core.Model;
using FlexRule.Core.Model.SourceConnections;
using FlexRule.Procedural;

namespace FlexRule.Sample.InlineModule
{
    class Program
    {
        static void Main(string[] args)
        {
            FlexRule.License.UserLicense.Initialize();
            IElementModel model = ReadRule("Rules/Module/InlineModule.xml");

            ProcedureEngine engine = CreateEngine(model);
            engine.Run();
            Console.WriteLine("Press enter to end...");
            Console.ReadLine();
        }

        static private ProcedureEngine CreateEngine(IElementModel model)
        {
            Procedure proc = new Procedure(model);
            return new ProcedureEngine(proc);
        }

        public static IElementModel ReadRule(string rulePath)
        {
            return LoadAdapterUtility.LoadNavigableSource(rulePath).GetElementModels(0).First();
        }
    }
}
