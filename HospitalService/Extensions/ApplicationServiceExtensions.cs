using HospitalService.Data;
using HospitalService.Interfaces;
using HospitalService.RabbitMQ.Sender;
using HospitalService.Repositories;
using HospitalService.Services;
using HospitalService.Services.Interfaces;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HospitalService.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddDbContext<HospitalDbContext>(opt => opt.UseNpgsql("User ID=postgres;Password=12345;Server=localhost;Port=5432;Database=HospitalService;"), ServiceLifetime.Transient);

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
