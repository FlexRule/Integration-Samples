using System;
using System.Collections.Generic;
using System.Text;

namespace FlexRule.Samples
{
    public class Person
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public DateTime Birthday { get; set; }
        public Address Address { get; set; }
        public string Email { get; set; }
    }

    public class Address
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string Suburb { get; set; }
    }
}
