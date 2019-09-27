using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApi.OData.Models;

namespace WebApi.OData
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
            );

            // OData Configuration
            ODataModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Student>("Students");
            config.Select().Expand().Filter().OrderBy().Count();

            config.MapODataServiceRoute(routeName: "ODataRoute", routePrefix: null, model: builder.GetEdmModel());

        }
    }
}
