using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using MassTransit.Definition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ServiceBus
{
    public static class MassTransitRabbitMQ
    {
        public static IServiceCollection AccessRabbitMqBus(this IServiceCollection services, string host, string serviceName)
        {
            services.AddMassTransit(service =>
            {
                service.AddConsumers(Assembly.GetEntryAssembly());
                service.UsingRabbitMq((context, configurator) => {
                    configurator.Host(host);
                    configurator.ConfigureEndpoints(context, new KebabCaseEndpointNameFormatter(serviceName, false));
                });
            });
            services.AddMassTransitHostedService();
            return services;
        }
    }
}
