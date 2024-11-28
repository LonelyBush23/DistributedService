namespace DistributedService.MessageQueue.Domain.Entities
{
    public class MessageContent
    {
        public string Subject { get; private set; }
        public string Body { get; private set; }

        public MessageContent(string subject, string body)
        {
            if (string.IsNullOrEmpty(body)) throw new ArgumentException("Message body cannot be empty.");
            Subject = subject;
            Body = body;
        }
    }
}
