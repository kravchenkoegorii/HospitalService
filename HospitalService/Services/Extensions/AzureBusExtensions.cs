using HospitalService.Services.Interfaces;
using HospitalService.Services.ServiceBusMessaging;
using Microsoft.Extensions.DependencyInjection;

namespace HospitalService.Services.Extensions
{
    public static class AzureBusExtensions
    {
        public static IServiceCollection AddAzureBus(this IServiceCollection services)
        {
            services.AddScoped<IServiceBusSender, ServiceBusSender>();
            return services;
        }
    }
}
