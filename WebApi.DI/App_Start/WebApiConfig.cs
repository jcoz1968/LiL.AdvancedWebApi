using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using Unity;
using Unity.Lifetime;
using WebApi.DI.Custom;
using WebApi.DI.CustomHandlers;
using WebApi.DI.Data;
using WebApi.DI.Data.DependencyResolver;

namespace WebApi.DI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Custom Message Handlers
            config.MessageHandlers.Add(new RequestValidateHandler());

            // CORS
            config.EnableCors();

            // Configure Unity Container
            var container = new UnityContainer();
            container.RegisterType<IStudentRepository, StudentRepository>(new TransientLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Services.Replace(typeof(IHttpControllerSelector), new CustomControllerSelector(config));

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // JSON Formatter

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            //config.Routes.MapHttpRoute(
            //    name: "StudentsV1",
            //    routeTemplate: "api/v1/students/{id}",
            //    defaults: new { controller="StudentsV1", id = RouteParameter.Optional }
            //);

            //config.Routes.MapHttpRoute(
            //    name: "StudentsV2",
            //    routeTemplate: "api/v2/students/{id}",
            //    defaults: new { controller = "StudentsV2", id = RouteParameter.Optional }
            //);
        }
    }
}
