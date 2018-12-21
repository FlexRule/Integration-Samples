using System;
using System.Configuration;
using System.IO;
using System.Linq;
using FlexRule.Core.Model;

namespace FlexRule.Samples.CaseHandling.Server.Workflow
{
    /// <summary>
    /// Loading models from folder address
    /// </summary>
    class ModelLoaderUtility
    {
        
        private static string _basePath;

        static ModelLoaderUtility()
        {
            ReadDefinitionPath();
        }

        public static IRuleSet LoadRuleSet()
        {
            var rules = Directory.GetFiles(_basePath, "*.xml", SearchOption.AllDirectories)
                .Select(x => new RuleSetFactory.RuleFile(Path.GetFileName(x), null, File.ReadAllBytes(x)));
            var rs =  RuleSetFactory.FromRuleFiles(rules);
            return rs;
        }

        private static void ReadDefinitionPath()
        {
            _basePath = ConfigurationManager.AppSettings["WorkflowDefinitionPath"].Replace("|CurrentDirectory|", Environment.CurrentDirectory);
            _basePath = Path.GetFullPath(_basePath);
        }
    }
}
