using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using FlexRule.Core.Model;
using FlexRule.License;
using FlexRule.Validation;

namespace FlexRule.Samples.PersonValidation
{
    static class Program
    {
        private static IRuntimeEngine _engine = RuntimeEngine.FromXml(File.ReadAllBytes("concept1.xml"));

        static void Main()
        {
            UserLicense.Initialize();
            ValidateByFactConcept1();
            ValidateByFactConcept2();
            ValidateByFactConcept3();
        }

        private static void ValidateByFactConcept1()
        {
            Console.WriteLine();
            Console.WriteLine("Scenario 1: Using static types");
            // Invalid object based on type, 
            var p1 = new Person()
            {
                Name = "Arash",
                Address = new Address()
                {
                    Country = "AU",
                    Line1 = "34 Station street",
                    State = "VIC"
                },
                Email = "test123"
            };
            // run object against the fact name "Person"
            var result = _engine.RunConcept("Person", p1);
            WriteResult(result);
        }

        private static void ValidateByFactConcept2()
        {
            Console.WriteLine();
            Console.WriteLine("Scenario 2: Using anonymous types");
            // Valid object based on type, 
            var p1 = new
            {
                Family = "Aghlara",
                Address = new
                {
                    Country = "AU",
                    Line1 = "34 Station street",
                    State = "VIC"
                },
                Email = "test123@yahoo.com"
            };
            // run object against the fact name "Person"
            var result = _engine.RunConcept("Person", p1);
            WriteResult(result);
        }

        private static void ValidateByFactConcept3()
        {
            Console.WriteLine();
            Console.WriteLine("Scenario 3: Using dynamic objects");
            // Valid object based on type, 
            dynamic p2 = new ExpandoObject();
            p2.Family = "Aghlara";
            p2.Address = new ExpandoObject();
            p2.Address.Country = "AU";
            p2.Address.Line1 = "34 Station street";
            p2.Address.State = "VIC";
            p2.Email = "test123";

            // run object against the fact name "Person"
            var result = _engine.RunConcept("Person", (object)p2);
            WriteResult(result);
        }

        private static void WriteResult(RuntimeResult result)
        {
            Console.WriteLine("Result: " + result.Outcome);
            foreach (var n in result.Context.Notifications.Default.Notices)
            {
                // On fact concept, each notice has properties related to the invalid field
                var fact = n.Properties["fact"];
                var member = n.Properties["member"];
                // If property definition in the Fact was an array
                // this would have had the index of the invalid item
                // var index = n.Properties["index "];
                Console.WriteLine("{0}: {1} ({2}.{3})", n.Type, n.Message, fact, member);
            }
        }
    }
}
