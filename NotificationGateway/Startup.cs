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

        public async void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();


            var factory = new ConnectionFactory()
            {
                HostName = "localhost:5050",
                // Добавьте другие параметры конфигурации, если нужно
            };

            var conn = await factory.CreateConnectionAsync();

            services.AddSingleton<IConnection>(conn);

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
