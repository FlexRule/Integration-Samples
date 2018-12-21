using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace FlexRule.Samples.CaseHandling.Server.System
{
    [Serializable]
    public class CaseHandlingException : Exception
    {
        public CaseHandlingException(string msg)
            : base(msg)
        {
        }
        public CaseHandlingException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
