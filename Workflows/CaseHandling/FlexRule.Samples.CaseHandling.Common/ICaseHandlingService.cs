using System.Collections.Generic;
using System.ServiceModel;
using FlexRule.Samples.CaseHandling.System;

namespace FlexRule.Samples.CaseHandling
{
    /// <summary>
    /// This is the main service will be host at the server and 
    /// client communicate to service via this contract model
    /// </summary>
    [ServiceContract]
    public interface ICaseHandlingService
    {
        /// <summary>
        /// This operation launches new case
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="clientEmail"></param>
        [OperationContract]
        void LaunchCase(string title, string description, string clientEmail);

        /// <summary>
        /// This lists all the cases and offices for monitoring purpose
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        IEnumerable<Assignment> ListCaseOfficers();

        /// <summary>
        /// This lists all the cases that can be accepted
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        IEnumerable<Assignment> ListAcceptables();

        /// <summary>
        /// This operation applies accept command on a <see cref="Assignment"/>
        /// </summary>
        /// <param name="assignment"></param>
        /// <returns></returns>
        [OperationContract]
        Assignment Accept(Assignment assignment);
    }
}