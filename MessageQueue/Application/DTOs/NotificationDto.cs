using DistributedService.MessageQueue.Domain.Entities;

namespace DistributedService.MessageQueue.Application.DTOs
{
    public class NotificationDto
    {
        public string Recipient { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
