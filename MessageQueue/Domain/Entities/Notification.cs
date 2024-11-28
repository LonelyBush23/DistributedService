namespace DistributedService.MessageQueue.Domain.Entities
{
    public class Notification
    {
        public Guid Id { get; private set; }
        public string Recipient { get; private set; }
        public MessageContent Content { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public Notification(string recipient, MessageContent content)
        {
            Id = Guid.NewGuid();
            Recipient = recipient;
            Content = content;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
