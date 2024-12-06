using System.Text;
using RabbitMQ.Client;
using Newtonsoft.Json;
using DistributedService.NotificationGateway.Core.Domain.Interfaces;
using DistributedService.NotificationGateway.Core.Application.DTOs;

namespace DistributedService.NotificationGateway.Core.Infrastructure.Messaging
{
    public class RabbitMqMessageQueueService : IMessageQueueService
    {
        private readonly string _queueName = "notification_queue";
        private readonly IConnection _connection;

        public RabbitMqMessageQueueService(IConnection connection)
        {
            _connection = connection;
        }

        public async Task SendMessageAsync(NotificationDto notification)
        {
            using (var channel = await _connection.CreateChannelAsync())
            {
                await channel.QueueDeclareAsync(queue: _queueName,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var message = JsonConvert.SerializeObject(notification);
                var body = Encoding.UTF8.GetBytes(message);

                await channel.BasicPublishAsync(exchange: "",
                                     routingKey: _queueName,
                                     body: body);
            }
        }
    }
}
