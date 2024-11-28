using DistributedService.MessageQueue.Application.DTOs;

namespace DistributedService.MessageQueue.Application.Interfaces
{
    public interface INotificationQueue
    {
        Task PublishAsync(NotificationDto notificationDto);
    }
}
