using System;
using System.IO;


namespace FlexRule.Samples.DrinkingLaw
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Program();
            p.Run();

            Console.ReadLine();
        }

        private void Run()
        {
            Console.WriteLine("---");
            DinkingUsingValidation();
            Console.WriteLine("---");
            DinkingUsingDecisionTable();
        }

        private static void DinkingUsingDecisionTable()
        {
            Console.WriteLine("Drinking regulation using Decision Table...");
            var engine = RuntimeEngine.FromXml(File.OpenRead("DrinkingDecisionTable.xml"));
            Check_Young_Female(engine);
            Check_Adult_Female(engine);
            Check_Adult_Pregnant_Female(engine);
        }
        private static void DinkingUsingValidation()
        {
            Console.WriteLine("Drinking regulation using Validation Tree...");
            var engine = RuntimeEngine.FromXml(File.OpenRead("DrinkingValidation.xml"));
            Check_Young_Female(engine);
            Check_Adult_Female(engine);
            Check_Adult_Pregnant_Female(engine);
        }

        private static void Check_Young_Female(IRuntimeEngine engine)
        {
            var person = new Person("Meagan", 16, Gender.Female);
            var result = engine.Run(person);

            if (!(bool)result.Context.VariableContainer["canDrink"])
            {
                foreach (var n in result.Context.Notifications.Default.Notices)
                    Console.WriteLine("{0}: {1}", n.Type, n.Message);
            }
            else
            {
                Console.WriteLine("{0}, Cheerrrssss!", person.Name);
            }
        }
        private static void Check_Adult_Female(IRuntimeEngine engine)
        {
            var person = new Person("Ava", 36, Gender.Female);
            var result = engine.Run(person);
            if (!(bool)result.Context.VariableContainer["canDrink"])
            {
                foreach (var n in result.Context.Notifications.Default.Notices)
                    Console.WriteLine("{0}: {1}", n.Type, n.Message);
            }
            else
            {
                Console.WriteLine("{0}, Cheerrrssss!", person.Name);
            }
        }
        private static void Check_Adult_Pregnant_Female(IRuntimeEngine engine)
        {
            var person = new Person("Olivia", 36, Gender.Female) { Pregnant = true };
            var result = engine.Run(person);
            if (!(bool)result.Context.VariableContainer["canDrink"])
            {
                foreach (var n in result.Context.Notifications.Default.Notices)
                    Console.WriteLine("{0}: {1}", n.Type, n.Message);
            }
            else
            {
                Console.WriteLine("{0}, Cheerrrssss!", person.Name);
            }
        }

    }
}
