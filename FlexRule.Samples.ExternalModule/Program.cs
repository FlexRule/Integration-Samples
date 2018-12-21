using System;
using FlexRule.Core.Languages.Xml;
using FlexRule.Core.Model;
using FlexRule.Core.Model.SourceConnections;
using FlexRule.Procedural;
using System.IO;

namespace FlexRule.Sample.ExternalModule
{
    class Program
    {
        static void Main(string[] args)
        {
            FlexRule.License.UserLicense.Initialize();
            IElementModel model = ReadRule("Rules/Module/ExternalModule.xml");

            ProcedureEngine engine = CreateEngine(model);

            string src1, src2;
            src1 = File.ReadAllText("Rules/Module/module1.xml");
            src2 = File.ReadAllText("Rules/Module/module2.xml");

            engine.Run(src1, src2);

            Console.WriteLine("Press enter to end...");
            Console.ReadLine();
        }

        private static ProcedureEngine CreateEngine(IElementModel model)
        {
            var proc = new Procedure(model);
            return new ProcedureEngine(proc);
        }

        public static IElementModel ReadRule(string rulePath)
        {
            return LoadAdapterUtility.LoadModel(rulePath);
        }
    }
}
