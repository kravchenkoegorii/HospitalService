using HospitalService.RabbitMQ;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace HospitalService.RabbitMQ.Extensions
{
    public static class RabbitMqExtensions
    {
        public static IServiceCollection AddRabbitMqServices(this IServiceCollection services)
        {
            services.AddScoped<IEventSender, RabbitMqSender>();
            services.AddMassTransit(x =>
            {

                //x.UsingRabbitMq();
                x.AddBus(context => Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    cfg.Host("rabbitmq://localhost", h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });
                }));
            });

            return services;
        }
    }
}
