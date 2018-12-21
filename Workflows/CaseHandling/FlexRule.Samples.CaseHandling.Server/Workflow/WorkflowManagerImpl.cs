using System;
using System.Linq;
using System.Collections.Generic;
using FlexRule.Flows;
using FlexRule.Flows.Workflows.Managers;
using FlexRule.Samples.CaseHandling.System;
using System.Configuration;
using FlexRule.Flows.Workflows;
using FlexRule.Flows.Workflows.Managers.InstanceStore;
using FlexRule.Flows.Workflows.Managers.Monitors;
using FlexRule.Flows.Workflows.Model;

namespace FlexRule.Samples.CaseHandling.Server.Workflow
{
    /// <summary>
    /// This is a utility class to create and load workflow from the model.
    /// It also creates an engine for processing every requires (if required)
    /// </summary>
    class WorkflowManagerImpl : IWorkflowManager
    {
        // engine instance is tread-safe and we share it between all the server requests
        private static IRuntimeEngine _engine;

        private const string FlowAddress = "CaseHandlingWorkflow.xml";

        /// Initializing the Workflow engine
        public static void Initialize()
        {
            if (_engine != null) return;

            // loading the models/ruleset
            var rs = ModelLoaderUtility.LoadRuleSet();

            // create a workflow engine
            _engine = RuntimeEngine.FromRuleSet(rs, FlowAddress);
            var config = new LongRunningProcessConfig(ConfigurationManager.ConnectionStrings["ProcessStateStore"].ConnectionString)
            {
                TimeoutNodeExpiredCallback = timeout_node_expired,
                TimeoutCheckCycle = TimeSpan.FromMinutes(1)
            };
            _engine.Workflow.EnableLongRunningProcess(config);

            FillTypeIdRegistry();
        }

        static void timeout_node_expired(object sender, ExpiredWorkflowInstanceEventArgs e)
        {
            Console.WriteLine("{0} - expired: {1}", DateTime.Now, e.WorkflowInstanceId);
        }

        /// <summary>
        /// Fills all the typeId(s) related to the workflow definition
        /// </summary>
        private static void FillTypeIdRegistry()
        {
            _engine.RegisterType(typeof(DateTime));
            _engine.RegisterType(typeof(Assignment), "Assignment");
            _engine.RegisterType(typeof(CaseInfo), "Case"); // override with the original name
            _engine.RegisterType(typeof(Officer));
            _engine.RegisterType(typeof(Guid));
        }

        /// <summary>
        /// Creates an engine to process a new request
        /// </summary>
        /// <returns></returns>
        public WorkflowExecutionContext New(params object[] inputs)
        {
            var res = _engine.Run(inputs);
            return (WorkflowExecutionContext)res.Context;
        }

        /// <summary>
        /// Creates an engine to process the request based on existing context
        /// </summary>
        /// <param name="instanceId"></param>
        /// <returns></returns>
        public WorkflowExecutionContext Resume(Guid instanceId, IReceiverSignal signal)
        {
            var res = _engine.Workflow.Resume(instanceId.ToString(), null, signal);
            return (WorkflowExecutionContext)res.Context;
        }

        /// <summary>
        /// Lists all the available stored processes that are waiting for a signal
        /// </summary>
        /// <param name="instanceIds"></param>
        /// <returns></returns>
        public IEnumerable<Guid> ListAvailables(IEnumerable<Guid> instanceIds)
        {
            var store = _engine.Workflow.Registry.GetHandler<IWorkflowInstanceStateManager>();
            return store.ListByState(FlowState.Waiting, _engine.Workflow.Identity).Select(Guid.Parse);
        }
    }
}
