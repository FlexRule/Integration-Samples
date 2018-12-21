using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FlexRule.Core.Model;

namespace FlexRule.Samples.FlowCarsDiscount
{
    class Program
    {
        // Connection string that retrieves a list of cars
        // Here is the database you need to prepare: http://wiki.flexrule.com/index.php?title=Car-Insurance-Sample-v1#Thefts
        const string ConnectionString = @"Data Source=.\SqlExpress;Initial Catalog=Car-Insurance;User ID=sa;Password=123;MultipleActiveResultSets=True";
        static void Main(string[] args)
        {
            // initialize the license
            FlexRule.License.UserLicense.Initialize();

            Console.WriteLine("-- From file location");
            RunFromFileAddress();

            Console.WriteLine("-- From ruleset");
            RunFromRuleSet();

            Console.ReadLine();
        }

        private static void RunFromRuleSet()
        {
            // get list of lofic files
            var list = new[] {"CarsDiscountFlow.xml", "YearDiscount.xml"};

            // create a set of file
            var ruleFiles = list.Select(x => new RuleSetFactory.RuleFile(x, null, File.ReadAllBytes(x)));

            var rs = RuleSetFactory.FromRuleFiles(ruleFiles);
            var engine = RuntimeEngine.FromRuleSet(rs, "CarsDiscountFlow.xml");

            var result = engine.Run(ConnectionString);
            var cars = result.Context.VariableContainer["cars"] as IEnumerable;
            foreach (IDictionary<string, object> car in cars)
            {
                Console.WriteLine("{0} {1} {2} Discount: {3}", car["Made"], car["Model"], car["Year"], car["Discount"]);
            }
        }

        private static void RunFromFileAddress()
        {
            var engine = RuntimeEngine.FromXml(File.OpenRead("CarsDiscountFlow.xml"));
            var result = engine.Run(ConnectionString);
            var cars = result.Context.VariableContainer["cars"] as IEnumerable;
            foreach (IDictionary<string, object> car in cars)
            {
                Console.WriteLine("{0} {1} {2} Discount: {3}", car["Made"], car["Model"], car["Year"], car["Discount"]);
            }
        }

    }
}
