using System;
using System.Runtime.Serialization;

namespace FlexRule.Samples.CaseHandling.System
{
    /// <summary>
    /// The task/case information that needs to be handled
    /// </summary>
    [DataContract]
    [Serializable]
    public class CaseInfo
    {
        /// <summary>
        /// ID of case
        /// </summary>
        [DataMember]
        public Guid Identifier { get; set; }

        /// <summary>
        /// Task that needs to be done
        /// </summary>
        [DataMember]
        public string Task { get; set; }

        /// <summary>
        /// Description of task
        /// </summary>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// Date time information that case has been created
        /// </summary>
        [DataMember]
        public DateTime? Created { get; set; }

        /// <summary>
        /// Has the case been finished
        /// </summary>
        [DataMember]
        public DateTime? Finished { get; set; }

        /// <summary>
        /// Has the case been finished
        /// </summary>
        [DataMember]
        public string ClientAddress { get; set; }

    }
}
