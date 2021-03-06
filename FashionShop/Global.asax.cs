﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FashionShop
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Order", // Route name
                "Admin/Order/{action}/{param_0}/{param_1}", // URL with parameters
                new
                {
                    controller = "Order",
                    action = "Index",
                    param_0 = UrlParameter.Optional,
                    param_1 = UrlParameter.Optional
                }
            );

            routes.MapRoute(
                "Category", // Route name
                "Admin/Category/{action}/{param_0}/{param_1}", // URL with parameters
                new
                {
                    controller = "Category",
                    action = "Index",
                    param_0 = UrlParameter.Optional,
                    param_1 = UrlParameter.Optional
                }
            );

            routes.MapRoute(
                "Index", // Route name
                "Index/{action}/{param_0}/{param_1}", // URL with parameters
                new
                {
                    controller = "Index",
                    action = "Index",
                    param_0 = UrlParameter.Optional,
                    param_1 = UrlParameter.Optional
                }
            );

            routes.MapRoute(
                "Account", // Route name
                "Admin/Account/{action}/{param_0}/{param_1}", // URL with parameters
                new { 
                    controller = "Account",
                    action = "Index",
                    param_0 = UrlParameter.Optional,
                    param_1 = UrlParameter.Optional
                }
            );

            routes.MapRoute(
                "Manufacturer", // Route name
                "Admin/Manufacturer/{action}/{param_0}/{param_1}", // URL with parameters
                new
                {
                    controller = "Manufacturer",
                    action = "Index",
                    param_0 = UrlParameter.Optional,
                    param_1 = UrlParameter.Optional
                }
            );

            routes.MapRoute(
                "Product", // Route name
                "Admin/Product/{action}/{param_0}/{param_1}", // URL with parameters
                new
                {
                    controller = "Product",
                    action = "Index",
                    param_0 = UrlParameter.Optional,
                    param_1 = UrlParameter.Optional
                }
            );

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new {
                    controller = "Index",
                    action = "Index",
                    id = UrlParameter.Optional
                }
            );
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);
        }
    }
}