using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
// here where we define our routes 
namespace quotesApiCourse
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }

                // example https://localhost:44355/api/Quotes Quotes is a controller
            );
        }
    }
}
