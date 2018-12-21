using System;

namespace AirlineDiscount.Models
{
    public class DiscountInput
    {
        public string Destination { get; set; }

        public DateTime? Birthday { get; set; }

        public DateTime? Departure { get; set; }

        public DateTime? Return { get; set; }


    }

}