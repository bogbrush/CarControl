using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace CarControl2
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        //protected void Application_BeginRequest(Object Sender, EventArgs e)
        //{
        //    string uniqueid = Guid.NewGuid().ToString();
        //    string logfile = String.Format("d:\\{0}.txt", uniqueid);
        //    Request.SaveAs(logfile, true);
        //}
    }
}
