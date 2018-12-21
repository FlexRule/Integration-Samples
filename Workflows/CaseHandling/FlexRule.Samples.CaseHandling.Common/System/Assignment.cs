using System;
using System.Runtime.Serialization;

namespace FlexRule.Samples.CaseHandling.System
{
    /// <summary>
    /// Officer info that works on the case
    /// </summary>
    [DataContract]
    [Serializable]
    public class Assignment
    {
        /// <summary>
        /// ID of case officer
        /// </summary>
        [DataMember]
        public Guid Identifier { get; set; }

        /// <summary>
        /// Date time information that case has been assigned to an officer
        /// </summary>
        [DataMember]
        public DateTime? Assigned { get; set; }

        /// <summary>
        /// Date time information that case has been accepted by officer
        /// </summary>
        [DataMember]
        public DateTime? Accepted { get; set; }

        /// <summary>
        /// Date time information of the officer handling the case
        /// </summary>
        [DataMember]
        public Officer Officer { get; set; }

        /// <summary>
        /// Date time information of the officer handling the case
        /// </summary>
        [DataMember]
        public CaseInfo Case { get; set; }

        /// <summary>
        /// Indicates if this case officer is an active one for the case
        /// </summary>
        [DataMember]
        public bool Active { get; set; }

        /// <summary>
        /// ID of case officer
        /// </summary>
        [DataMember]
        public Guid? FlowInstanceIdentifier { get; set; }

    }
}