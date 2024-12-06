using DistributedService.NotificationGateway;
using DistributedService.NotificationGateway.Core.Application.Services;
using DistributedService.NotificationGateway.Core.Domain.Interfaces;
using DistributedService.NotificationGateway.Core.Infrastructure.Messaging;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
// ��������� API
builder.Services.AddControllers();

var factory = new ConnectionFactory()
{
    HostName = "localhost"
};

var conn = await factory.CreateConnectionAsync();
builder.Services.AddSingleton<IConnection>(conn);

// ���������� ��������
builder.Services.AddScoped<IMessageQueueService, RabbitMqMessageQueueService>();
builder.Services.AddScoped<INotificationService, NotificationService>();
//Startup.ConfigureServices(builder.Services);

// ��������� ��������� �����������
builder.Logging.AddConsole(); // ����������� � �������
builder.Logging.AddDebug();   // ����������� ��� �������

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// �������� ����������� ��������
app.Use(async (context, next) =>
{
    var logger = app.Services.GetRequiredService<ILogger<Program>>();
    logger.LogInformation($"Request: {context.Request.Method} {context.Request.Path}");
    await next.Invoke();
});

app.UseHttpsRedirection();
app.UseStaticFiles();

// ������������� middleware
app.UseRouting();
app.MapControllers(); ;

app.UseAuthorization();

app.MapRazorPages();

app.Run();

