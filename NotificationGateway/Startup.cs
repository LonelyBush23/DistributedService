using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Connections;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using DistributedService.NotificationGateway.Core.Infrastructure.Messaging;
using DistributedService.NotificationGateway.Core.Application.Services;
using DistributedService.NotificationGateway.Core.Domain.Interfaces;

namespace DistributedService.NotificationGateway
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Настройка RabbitMQ
            services.AddSingleton<IConnection>(sp =>
            {
                var factory = new ConnectionFactory() { HostName = "localhost" };
                return (IConnection)factory.CreateConnectionAsync();
            });

            // Регистрация сервисов
            services.AddScoped<IMessageQueueService, RabbitMqMessageQueueService>();
            services.AddScoped<INotificationService, NotificationService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
