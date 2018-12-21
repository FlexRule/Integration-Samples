using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using FlexRule.License;

namespace AirlineDiscount
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            UserLicense.Initialize(new MyLicense());
        }

        class MyLicense : ILicenseProvider
        {
            public string ReadLicense()
            {
                var path = HttpContext.Current.Server.MapPath("app_data/flexrule.license.lic");
                return File.ReadAllText(path);
            }
        }
    }
}
