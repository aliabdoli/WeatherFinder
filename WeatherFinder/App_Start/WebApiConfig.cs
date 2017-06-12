using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using Microsoft.Practices.Unity;
using BusinessLogic.Main;
using BusinessLogic.Core;
using BusinessLogic.GobalWeatherService;

namespace WeatherFinder
{
    public static class WebApiConfig
    {
        private const string GlobalWeatherFinderResolver = "GlobalWeatherFinder";
        private const string OpenWeatherFinderResolver = "OpenWeatherFinder";
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            ConfigContainer(config);
            
        }
        public static void ConfigContainer(HttpConfiguration config)
        {
            var container = new UnityContainer();


            container.RegisterType<IGlobalWeatherServiceClient, GlobalWeatherServiceClient>(new PerThreadLifetimeManager());
            container.RegisterType<IOpenWeatherServiceClient, OpenWeatherServiceClient>(new PerThreadLifetimeManager());

            container.RegisterType<IWeatherFinder, GlobalWeatherFinder>(GlobalWeatherFinderResolver, new PerThreadLifetimeManager());
            container.RegisterType<IWeatherFinder, OpenWeatherFinder>(OpenWeatherFinderResolver, new PerThreadLifetimeManager());
            container.RegisterType<IWeatherModel, WeatherModel>();

            container.RegisterType<IWeatherModel, WeatherModel>(new PerThreadLifetimeManager(),
                                                                new InjectionConstructor(
                                                                    new ResolvedParameter<IWeatherFinder>(GlobalWeatherFinderResolver), 
                                                                    new ResolvedParameter<IWeatherFinder>(OpenWeatherFinderResolver))
                                                                );

            config.DependencyResolver = new UnityResolver(container);
        }
    }
}
