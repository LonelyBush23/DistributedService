using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace DistributedService.MessageQueue.Infrastructure.Queue
{
    public class RabbitMQConsumer
    {
        //private readonly RabbitMQConfig _config;

        //public RabbitMQConsumer(RabbitMQConfig config)
        //{
        //    _config = config;
        //}

        //public void Consume(Action<string> processMessage)
        //{
        //    var factory = new ConnectionFactory() { HostName = _config.Host };
        //    using var connection = factory.CreateConnection();
        //    using var channel = connection.CreateModel();

        //    channel.QueueDeclare(queue: _config.QueueName, durable: true, exclusive: false, autoDelete: false, arguments: null);

        //    var consumer = new EventingBasicConsumer(channel);
        //    consumer.Received += (model, ea) =>
        //    {
        //        var body = ea.Body.ToArray();
        //        var message = Encoding.UTF8.GetString(body);
        //        processMessage(message);
        //    };

        //    channel.BasicConsume(queue: _config.QueueName, autoAck: true, consumer: consumer);
        //}
    }
}
