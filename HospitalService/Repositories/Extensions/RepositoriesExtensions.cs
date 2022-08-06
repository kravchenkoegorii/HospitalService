using HospitalService.Data;
using HospitalService.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace HospitalService.Repositories.Extensions
{
    public static class RepositoriesExtensions
    {
        public static void AddRepositoriesServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IAdminRepository, AdminRepository>();

            services.AddDbContext<HospitalDbContext>(opt => opt.UseNpgsql(Environment.GetEnvironmentVariable("HOSPITALDB_KEY")));
        }
    }
}
