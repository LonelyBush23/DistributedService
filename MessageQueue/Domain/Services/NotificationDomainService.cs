using DistributedService.MessageQueue.Domain.Entities;

namespace DistributedService.MessageQueue.Domain.Services
{
    public class NotificationDomainService
    {
        public bool Validate(Notification notification)
        {
            return !string.IsNullOrEmpty(notification.Recipient) &&
                   notification.Content != null;
        }
    }
}
