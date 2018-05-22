using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Passengers
{
    public static class WebApiConfig
    {
		/// <summary>
		/// Todo: disable XML formatter, so that JSON is the only format supported.
		/// </summary>
		/// <param name="config"></param>
        public static void Register(HttpConfiguration config)
        {
			


            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
