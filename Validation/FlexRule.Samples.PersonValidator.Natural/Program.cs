using System;
using System.IO;
using FlexRule.License;

namespace FlexRule.Samples.PersonValidation
{
    // This example shows validation using a natural language with:
    // 1. Writing notification using $context
    // 2. Creating reusable 'when' logic 
    static class Program
    {
        static void Main()
        {
            UserLicense.Initialize();
            ValidatePersonIdentity_StructuredRoutine();
        }
        private static void ValidatePersonIdentity_StructuredRoutine()
        {
            var engine = RuntimeEngine.FromXml(File.OpenRead("PersonRule.nl"));

            var per = GetPerson();
            var result = engine.Run(new RunParameter("person has identity"), per);

            if (!result.Outcome.Value)
            {
                // Check errors
                foreach (var notice in result.Context.Notifications.Default.Notices)
                    Console.WriteLine("{0}: {1}", notice.Message, notice.Tag);
            }
        }
        static Person GetPerson()
        {
            var per = new Person
            {
                Name = "test name",
                Family = "test family"
            };
            // to fail the validation
            // remove the remark from thext line(email)
            // to pass the validation
            // per.Email = "test@test.com";
            return per;
        }

    }
}
