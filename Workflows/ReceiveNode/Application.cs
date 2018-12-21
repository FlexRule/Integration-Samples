using System;

namespace FlexRule.Samples.Receive
{
    public enum Status
    {
        Rejected = 1,
        Approved,
    }

    [Serializable]
    public class Application
    {
        public Status Status { get; set; }
        public string Fullname { get; set; }

        public int Age { get; set; }
        public string Comment { get; set; }
    }
}
