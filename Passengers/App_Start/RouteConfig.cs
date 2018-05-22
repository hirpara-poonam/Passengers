using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Passengers
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //   "PassengersApiController", // Route name
            //   "Api/PassengersApiController/{action}",
            //   new { controller = "PassengersApi", action = "Index" },
            //   new[] { "Passengers.Controllers.Api" });

            //routes.MapRoute(
            //   "Api", // Route name
            //   "Api/PassengersApiController/{action}",
            //   new { controller = "PassengersApiController", action = "Index" },
            //   new[] { "Controllers.Api" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
