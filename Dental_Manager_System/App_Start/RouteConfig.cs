using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Dental_Manager_System
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
                name: "ADMIN",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "ADMIN", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "LeTan",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "LeTan", action = "TrangChu", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "User",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "User", action = "Trang_Chu", id = UrlParameter.Optional }
            );
        }
    }
}
