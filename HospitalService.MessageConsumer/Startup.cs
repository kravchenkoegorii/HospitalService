using HospitalService.DTOs;
using HospitalService.MessageConsumer.Data;
using HospitalService.MessageConsumer.Repositories;
using HospitalService.MessageConsumer.RabbitMQ;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using HospitalService.Repositories.Extensions;

namespace HospitalService.MessageConsumer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MessageDbContext>(opt => opt.UseNpgsql(Configuration.GetConnectionString()), ServiceLifetime.Transient);
            services.AddScoped<IMessageConsumerRepository, MessageConsumerRepository>();
            services.AddScoped<IConsumer<CreateObjectMessageDto>, MessageConsumerService>();
            services.AddMassTransit(x =>
            {
                x.AddConsumer<MessageConsumerService>();

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.ConfigureEndpoints(context);
                });
            });
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MESSAGECONSUMER API", Version = "v1" });
            });
            services.AddCors();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My MessageConsumer API"); });

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors(builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}