using System;
using System.Collections.Generic;
using System.Linq;
using FlexRule.Notifications;

namespace AirlineDiscount.Models
{
    public class ErrorResult
    {
        public class Message
        {
            public Message(string type, string error)
            {
                Type = type;
                Error = error;
            }

            public string Type { get; private set; }
            public string Error { get; private set; }
        }
        public ErrorResult(INotificationSet notifications)
        {
            Messages = notifications.Default.Notices.Select(x => new Message(x.Type.ToString(), x.Message)).ToList();
        }

        public IEnumerable<Message> Messages { get; private set; }
    }


    public class DiscountResult
    {
        public DiscountResult(DiscountInput model, int discount)
        {
            Destination = model.Destination;
            Return = model.Return.Value;
            Departure = model.Departure.Value;
            Discount = discount;
        }
        public DateTime Departure { get; private set; }
        public DateTime Return { get; private set; }
        public string Destination { get; private set; }
        public int Discount { get; private set; }
    }
}
