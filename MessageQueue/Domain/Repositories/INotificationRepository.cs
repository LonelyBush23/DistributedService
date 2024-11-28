using DistributedService.MessageQueue.Domain.Entities;

namespace DistributedService.MessageQueue.Domain.Repositories
{
    public interface INotificationRepository
    {
        Task SaveAsync(Notification notification);
        Task<IEnumerable<Notification>> GetFailedNotificationsAsync();
    }
}
