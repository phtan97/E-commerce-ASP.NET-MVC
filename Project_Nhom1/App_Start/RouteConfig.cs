using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Project_Nhom1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Client",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new [] {"Project_Nhom1.Controllers"}
            );

            routes.MapRoute(
                name: "Add Cart",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Cart", action = "AddCart", id = UrlParameter.Optional },
                namespaces: new[] { "Project_Nhom1.Controllers" }
            );
        }
    }
}
