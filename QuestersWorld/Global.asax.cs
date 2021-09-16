using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace QuestersWorld
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public string SENDGRID_APIKEY = "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";
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
