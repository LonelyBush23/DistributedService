using Microsoft.AspNetCore.Connections;
using System.Text;
using RabbitMQ.Client;
using System.Threading.Tasks;

namespace DistributedService.MessageQueue.Infrastructure.Queue
{
    public class RabbitMQProducer
    {
        //private readonly RabbitMQConfig _config;

        //public RabbitMQProducer(RabbitMQConfig config)
        //{
        //    _config = config;
        //}

        //public async Task PublishAsync(string message)
        //{
        //    var factory = new ConnectionFactory() { HostName = _config.Host };
        //    using var connection = factory.CreateConnection();
        //    using var channel = connection.CreateModel();

        //    channel.QueueDeclare(queue: _config.QueueName, durable: true, exclusive: false, autoDelete: false, arguments: null);
        //    var body = Encoding.UTF8.GetBytes(message);

        //    channel.BasicPublish(exchange: "", routingKey: _config.QueueName, basicProperties: null, body: body);
        //}
    }
}
