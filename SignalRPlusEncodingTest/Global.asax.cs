﻿using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using SignalRPlusEncodingTest.App_Start;

namespace SignalRPlusEncodingTest
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}