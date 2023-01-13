using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace DA
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            using(var context = new web_demoEntities() )
            {
                ConfigurationManager.AppSettings["web_demo_url"] = context.company_data.FirstOrDefault().Domain +"/WebDemo";
            }

            ServicePointManager.ServerCertificateValidationCallback
                += (sender, cert, chain, sslPolicyErrors) =>
                {
                    if (sslPolicyErrors == SslPolicyErrors.None)
                    {
                        return true;
                    }
                    var request = sender as HttpWebRequest;
                    if (request != null)
                    {
                        var result = request.RequestUri.Host == ConfigurationManager.AppSettings["remote_host"];

                        return result;
                    }
                    return false;
                };
        }
    }
}
