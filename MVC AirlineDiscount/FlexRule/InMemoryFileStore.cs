using System;
using System.Collections.Concurrent;
using System.IO;
using System.Web;

namespace AirlineDiscount.FlexRule
{
    class InMemoryFileStore
    {
        static readonly ConcurrentDictionary<string, string> _rulesStore = new ConcurrentDictionary<string, string>(StringComparer.CurrentCultureIgnoreCase);
        public static string GetByName(string name)
        {
            return _rulesStore.GetOrAdd(name, ReadRule);
        }
        public static void UpdateByName(string name, string content)
        {
            _rulesStore[name] = content;
        }

        private static string ReadRule(string ruleFileName)
        {
            if (string.IsNullOrWhiteSpace(ruleFileName) || !Exists(ruleFileName))
                return null;
            return File.ReadAllText(GetPath(ruleFileName));
        }

        private static bool Exists(string ruleFileName)
        {
            var path = GetPath(ruleFileName);
            return System.IO.File.Exists(path);
        }

        private static string GetPath(string ruleFileName)
        {
            return HttpContext.Current.Server.MapPath("~/app_data/Rules/" + ruleFileName);
        }
    }
}