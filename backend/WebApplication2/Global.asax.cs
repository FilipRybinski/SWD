﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebApplication2.App_Start;
using WebApplication2.Utils;

namespace WebApplication2
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            SmileUtils.AttachLicense();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}