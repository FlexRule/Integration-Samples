using System;
using FlexRule;

namespace AirlineDiscount.Controllers
{
    class AgeExtensions
    {
        [Function("GetAge")]
        public static int GetAge(object date)
        {
            if (date == null)
                return int.MinValue;

            var dateOfBirth = (DateTime)date;

            var today = DateTime.Today;

            var a = (today.Year * 100 + today.Month) * 100 + today.Day;
            var b = (dateOfBirth.Year * 100 + dateOfBirth.Month) * 100 + dateOfBirth.Day;

            var age = (a - b) / 10000;
            return age;
        }
    }
}