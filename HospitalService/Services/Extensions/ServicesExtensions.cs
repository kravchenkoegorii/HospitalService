﻿using HospitalService.Interfaces;
using HospitalService.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace HospitalService.Services.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IAdminService, AdminService>();

            return services;
        }
    }
}
