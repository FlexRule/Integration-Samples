using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AirlineDiscount.FlexRule;
using AirlineDiscount.Models;

namespace AirlineDiscount.Controllers
{
    public class RepositoryController : Controller
    {
        // GET: Rules
        public string Index()
        {
            var name = Request.QueryString["name"];
            var ruleContent = Rules.Read(name);
            if (ruleContent != null)
                return ruleContent;

            throw new Exception("Business rule document not found:" + name);
        }

        [HttpPost]
        public void Save(RuleItem item)
        {
            Rules.Update(item.Name, item.Content);
        }
    }
}