using System;
using System.Collections.Generic;
using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Description;
using FlexRule.Samples.CaseHandling.Server.Controllers;
using FlexRule.Samples.CaseHandling.Server.Workflow;
using FlexRule.Samples.CaseHandling.System;
using System.Diagnostics;


namespace FlexRule.Samples.CaseHandling.Server
{
    /// <summary>
    /// Service host shares its <see cref="ICaseHandlingHostContext"/> with all the requests
    /// This context is nothing but some shared variables from loaded service that is required
    /// to process the service operation. e.g. _workflowRepository, _caseHandlingRepository...
    /// </summary>
    public class CaseHandlingHost : ICaseHandlingService, ICaseHandlingHostContext
    {
        // ** Shared variables that can be placed into a context
        private readonly ICaseHandlingRepository _caseHandlingRepository;
        private readonly IWorkflowManager _workflowUtility;
        // ** End of shared variables

        static public void StartHost()
        {
            Console.WriteLine("Initializing FlexRule license...");
            FlexRule.License.UserLicense.Initialize();

            Console.WriteLine("Running service and host the contract...");
            //Create a URI to serve as the base address
            Uri httpUrl = new Uri(ConfigurationManager.AppSettings["CaseHandlingServer"]);
            //Create ServiceHost
            ServiceHost host = new ServiceHost(typeof(CaseHandlingHost), httpUrl);
            //Add a service endpoint
            host.AddServiceEndpoint(typeof(ICaseHandlingService), new WSHttpBinding(), string.Empty);
            //Enable metadata exchange
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            host.Description.Behaviors.Add(smb);
            //Start the Service
            host.Open();

            WorkflowManagerImpl.Initialize();

            Console.WriteLine("Service is hosted and ran successfully.");
        }

        internal CaseHandlingHost()
        {
            _caseHandlingRepository = RepositoryFactory.SystemRepository();
            _workflowUtility = new WorkflowManagerImpl();
        }

        TReturn ProcessRequestWithLog<TReturn>(string log, Func<object> action)
        {
            Console.ResetColor();
            Console.WriteLine(string.Format("{1} - Processing {0}...", log, DateTime.Now));
            Stopwatch sw = null;
            try
            {
                sw = Stopwatch.StartNew();
                return (TReturn)action();
            }
            catch (Exception ex)
            {
                sw.Stop();
                WriteError(ex);
                if (ex.InnerException != null)
                    WriteError(ex.InnerException);
                throw;
            }
            finally
            {
                sw.Stop();
                Console.ResetColor();
                Console.WriteLine(string.Format("{1} - {0} done. [{2} ms]", log, DateTime.Now, sw.ElapsedMilliseconds));
            }
        }
        void WriteError(Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);

        }
        #region Service contract implementation (ICaseHandlingHost)
        public void LaunchCase(string title, string description, string clientEmail)
        {
            ProcessRequestWithLog<object>("LauchCase",
                  () => new LaunchCaseController(this).Process(title, description, clientEmail)
                );
        }

        public Assignment Accept(Assignment co)
        {
            return ProcessRequestWithLog<Assignment>("Accept",
                         () => new AcceptController(this).Process(co)
                       );
        }

        public IEnumerable<Assignment> ListCaseOfficers()
        {
            return ProcessRequestWithLog<IEnumerable<Assignment>>("ListAssignments",
                         () => new ListCaseOfficersController(this).Process()
                       );
        }

        public IEnumerable<Assignment> ListAcceptables()
        {
            return ProcessRequestWithLog<IEnumerable<Assignment>>("ListAcceptables",
                        () => new ListAcceptableController(this).Process()
                      );
        }
        #endregion


        #region ICaseHandlingHostContext properties for running host context
        
        ICaseHandlingRepository ICaseHandlingHostContext.CaseHandlingRepository
        {
            get { return _caseHandlingRepository; }
        }

        IWorkflowManager ICaseHandlingHostContext.WorkflowManager
        {
            get { return _workflowUtility; }
        }
        #endregion

    }
}
