using System.Configuration;
using System.ServiceModel;

namespace FlexRule.Samples.CaseHandling.System
{
    /// <summary>
    /// This is a proxy that is used by client to communicate to service host
    /// The address of the host will be read from configuration file
    /// </summary>
    public class CaseHandlingServiceProxy : ClientBase<ICaseHandlingService>, ICaseHandlingService
    {
        public CaseHandlingServiceProxy()
            : this(ConfigurationManager.AppSettings["CaseHandlingServer"])
        {
        }

        public CaseHandlingServiceProxy(string address)
            : base(new WSHttpBinding(), new EndpointAddress(address))
        {

        }
        public void LaunchCase(string title, string description, string clientEmail)
        {
            Channel.LaunchCase(title, description, clientEmail);
        }

        public global::System.Collections.Generic.IEnumerable<Assignment> ListCaseOfficers()
        {
            return Channel.ListCaseOfficers();
        }


        public global::System.Collections.Generic.IEnumerable<Assignment> ListAcceptables()
        {
            return Channel.ListAcceptables();
        }

        public Assignment Accept(Assignment co)
        {
            return Channel.Accept(co);
        }
    }
}
