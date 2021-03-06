﻿using DatabaseCommunicator;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Woodstore
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            string path = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.FullName + @"\DatabaseCommunicator\Database";
            AppDomain.CurrentDomain.SetData("DataDirectory", path);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Database.SetInitializer(new WoodStoreSeeder());
        }
    }
}
