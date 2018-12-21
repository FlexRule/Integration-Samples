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
        private static IRuntimeEngine _validator = RuntimeEngine.FromXml(File.ReadAllBytes("SampleValidationRule.xml"));
        private static IRuntimeEngine _procedure = RuntimeEngine.FromRuleSet(BuildRuleset(), "SampleValidationRule.xml");

        private static IRuleSet BuildRuleset()
        {
            // getting file paths
            string[] paths = {"SampleValidationRule.xml","SampleProcedureRule.xml"};

            // building RuleFile based on the path
            var files = paths.Select(f => new RuleSetFactory.RuleFile(f, string.Empty, File.ReadAllBytes(f)));

            // creating ruleset
            return RuleSetFactory.FromRuleFiles(files);
        }

        static void Main()
        {
            UserLicense.Initialize();
            ValidateUsingValidationEngine();
            ValidateUsingValidationEngineAndExpando();
            ValidateUsingProceduralEngine();
        }

        private static void ValidateUsingProceduralEngine()
        {
            // we called a procedure and then it called a validation
            // this console application -> procedure -> validation
            var person = GetPerson();
            var result = _procedure.Run(person);
            
            // We still collect the notification for validation 
            // although if was called indirectly from a procedure
            foreach (var item in result.Context.Notifications.Default.Notices)
                Console.WriteLine(item.Message);
        }


        static Person GetPerson()
        {
            var a = new Address() { Country = "AU", Line1 = "34 Station street", State = "VIC" };
            return new Person() { Name = "Arash", Address = a, Email = "test123" };
        }

        
        static private void ValidateUsingValidationEngine()
        {
            Person person = GetPerson();
            // This runs the first logic (complete person test)
            // which as the result (complete person test) calls the other logic as well

            var result = _validator.Run(person);
            Console.WriteLine("Was the input person valid?  {0}", result.Outcome);
            foreach (var item in result.Context.Notifications.Default.Notices)
                Console.WriteLine(item.Message);

            person.Email = "arash@1111.org";
            person.Family = "Aghlara";
            result = _validator.Run(person);
            Console.WriteLine("Was the input person valid?  {0}", result.Outcome);
        }


        static private void ValidateUsingValidationEngineAndExpando()
        {
            IDictionary<string, object> person = new ExpandoObject();
            person.Add("Name", "arash");
            person.Add("Family", "aghlara");

            var validationInput = new Dictionary<string, object>() { { "person", person } };

            // Using RunParameter, you can directly tagret a specific Logic within a Validation
            var result = _validator.Run(new RunParameter("basic validation"), validationInput);

            // retrieve the notification for basic validation
            foreach (var item in result.Context.Notifications.Default.Notices)
                Console.WriteLine(item.Message);
        }
    }
}
