using HospitalService.Data;
using HospitalService.Interfaces;
using HospitalService.Repositories;
using HospitalService.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HospitalService.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddDbContext<HospitalDbContext>(opt => opt.UseNpgsql("User ID=postgres;Password=12345;Server=localhost;Port=5432;Database=HospitalService;"), ServiceLifetime.Transient);          
            return services;
        }
    }
}
