using HospitalService.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace HospitalService.Services.Extensions
{
    public static class AzureBusExtensions
    {
        public static IServiceCollection AddAzureBus(this IServiceCollection services)
        {
            services.AddScoped<IMessagePublisher, MessagePublisher>();
            return services;
        }
    }
}
