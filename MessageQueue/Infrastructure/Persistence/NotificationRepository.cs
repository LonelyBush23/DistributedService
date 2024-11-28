using DistributedService.MessageQueue.Domain.Entities;
using DistributedService.MessageQueue.Domain.Repositories;

namespace DistributedService.MessageQueue.Infrastructure.Persistence
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly List<Notification> _storage = new();

        public Task SaveAsync(Notification notification)
        {
            _storage.Add(notification);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Notification>> GetFailedNotificationsAsync()
        {
            return Task.FromResult(_storage.AsEnumerable());
        }
    }
}
