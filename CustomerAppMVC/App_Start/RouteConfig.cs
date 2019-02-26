using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CustomerAppMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "QueryCustomers",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Customers", action = "QueryCustomers", id = UrlParameter.Optional }
            );

            //routes.MapRoute(
            //    name: "Customer",
            //    url: "Customer/Index/{id}",
            //    defaults: new { controller = "Customer", action = "Index", id = UrlParameter.Optional}
            //);

            //routes.MapRoute(
            //    name: "QueryCustomers",
            //    url: "Customer/QueryCustomers/{id}",
            //    defaults: new { controller = "Customer", action = "QueryCustomers", id = UrlParameter.Optional }
            //);
        }
    }
}
