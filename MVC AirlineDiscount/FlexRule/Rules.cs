using System;
using AirlineDiscount.Controllers;
using FlexRule;
using FlexRule.Events;

namespace AirlineDiscount.FlexRule
{
    public static class Rules
    {
        static readonly object PropertyAccessLock = new object();
        private static IRuntimeEngine _inputValidator;
        private static IRuntimeEngine _discountDecision;

        public static IRuntimeEngine InputValidator
        {
            get
            {
                lock (PropertyAccessLock)
                    return _inputValidator;
            }
            private set
            {
                lock (PropertyAccessLock)
                    _inputValidator = value;
            }
        }

        public static IRuntimeEngine DiscountDecision
        {
            get
            {
                lock (PropertyAccessLock)
                    return _discountDecision;
            }
            private set
            {
                lock (PropertyAccessLock)
                    _discountDecision = value;
            }
        }

        static Rules()
        {
            // Build validation plan for validating input data from user
            BuildValidator();
            BuildDiscountDecision();
        }

        private static void BuildValidator()
        {
            InputValidator = RuntimeEngine.FromXml(InMemoryFileStore.GetByName("inputValidator.xml").AsBytes());
        }

        private static void BuildDiscountDecision()
        {
            DiscountDecision = RuntimeEngine.FromXml(InMemoryFileStore.GetByName("DiscountDecision.xml").AsBytes());
            // Capture events 
            DiscountDecision.Events = EventNames.All;
            // registering custom function
            DiscountDecision.RegisterFunction(typeof(AgeExtensions));
            // build validation plan for executing decision table 
            // Creates a reader to access an excel file
            DiscountDecision.Entries.Add("Y", "true", true);
            DiscountDecision.Entries.Add("N", "false", true);
        }

        public static void Update(string name, string content)
        {
            InMemoryFileStore.UpdateByName(name, content);

            // Update the new rules content (in-memory)
            if (String.Compare(name, "DiscountDecision.xml", StringComparison.OrdinalIgnoreCase) == 0)
                BuildDiscountDecision();
        }

        public static string Read(string name)
        {
            return InMemoryFileStore.GetByName(name);
        }
    }
}