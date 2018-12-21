
using FlexRule.Samples.CaseHandling.System;

namespace FlexRule.Samples.CaseHandling.Server
{
    /// <summary>
    /// This factory creates the repositories for different implementation of System and Workflow
    /// </summary>
    public static class RepositoryFactory
    {
        static public ICaseHandlingRepository SystemRepository()
        {
            return new System.Repository.RepositoryImplEntityFramework();
        }
    }
}
