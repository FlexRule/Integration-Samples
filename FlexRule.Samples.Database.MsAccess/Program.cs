using System;
using System.Collections.Generic;
using System.IO;
using FlexRule.Core.Model;

namespace FlexRule.Samples.Database.MsAccess
{
    static class Program
    {
        static void Main()
        {

            License.UserLicense.Initialize();

            // This rule loads data from access file so make sure you have the driver installed
            // download it (ACE engine) from: http://www.microsoft.com/download/en/details.aspx?id=13255
            var engine = RuntimeEngine.FromXml(File.OpenRead("ReadMsAccessData.xml"));
            var result = engine.Run();

            // list variable contains rows
            var list = (IList<FlexRule.Data.IMetaObject>)result.Context.VariableContainer["list"];
            foreach (var obj in list)
            {
                string [] allProperties = obj.GetProperties();
                foreach (string p in allProperties)
                    Console.WriteLine("{0}={1}", p, obj.GetValue(p));

                Console.WriteLine();
            }
        }
    }
}
