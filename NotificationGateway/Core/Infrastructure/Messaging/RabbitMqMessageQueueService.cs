using NotificationGateway.Core.Application.Interfaces;
using NotificationGateway.Core.Application.DTOs;
//using RabbitMQ.Client;
using System.Text;
//using Newtonsoft.Json;

namespace NotificationGateway.Infrastructure.Messaging
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
            using (var channel = _connection.CreateModel())
            {
                channel.QueueDeclare(queue: _queueName,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var message = JsonConvert.SerializeObject(notification);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: _queueName,
                                     basicProperties: null,
                                     body: body);
            }
        }
    }
}
