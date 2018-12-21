using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace FlexRule.Samples.CaseHandling.System
{
    /// <summary>
    /// This is the case officer that handles the case
    /// </summary>
    [DataContract]
    [Serializable]
    public class Officer
    {
        /// <summary>
        /// ID of the officer
        /// </summary>
        [DataMember]
        public Guid Identifier { get; set; }

        /// <summary>
        /// Name of case officer
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Role of case officer
        /// </summary>
        [DataMember]
        public string Role { get; set; }

        /// <summary>
        /// Manager of this officer
        /// </summary>
        [DataMember]
        public Officer Manager { get; set; }

        /// <summary>
        /// All the staff under this officer
        /// </summary>
        [DataMember]
        public IList<Officer> Subordinate { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}