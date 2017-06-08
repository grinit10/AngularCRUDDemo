using Microsoft.Practices.Unity;
using System.Web.Http;
using Api.Resolver;
using Repository.Interfaces;
using Repository.Repositories;
using Dac.DbContext;
using Dac.Interfaces;

namespace Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterType<IPropertyRepository, PropertyRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IApplicationDBContext, ApplicationDBContext>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "ApiByAction",
                routeTemplate: "api/{controller}/{action}",
                defaults: new { action = "Get" }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
