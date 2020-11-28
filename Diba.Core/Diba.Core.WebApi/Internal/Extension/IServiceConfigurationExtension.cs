using Diba.Core.WebApi.Internal.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diba.Core.WebApi.Internal.Extension
{
    public static class ServiceConfigurationExtension
    {
        public static IServiceCollection AddFromConfigurationFile(this IServiceCollection services, IConfigurationSection configuration)
        {
            var servicesConfiguration = configuration.Get<ServicesConfiguration>();
            if (servicesConfiguration.Singleton != null)
            {
                foreach (var service in servicesConfiguration.Singleton)
                {
                    services.AddSingleton(Type.GetType(service.Service), Type.GetType(service.Implementation));
                }
            }

            if (servicesConfiguration.Transient != null)
            {
                foreach (var service in servicesConfiguration.Transient)
                {
                    services.AddTransient(Type.GetType(service.Service), Type.GetType(service.Implementation));
                }
            }

            if (servicesConfiguration.Scoped != null)
            {
                foreach (var service in servicesConfiguration.Scoped)
                {
                    services.AddScoped(Type.GetType(service.Service), Type.GetType(service.Implementation));
                }
            }

            //Other scopes here...
            return services;
        }
    }
}
