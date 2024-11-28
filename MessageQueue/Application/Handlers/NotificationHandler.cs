using DistributedService.MessageQueue.Application.DTOs;
using DistributedService.MessageQueue.Domain.Entities;

namespace DistributedService.MessageQueue.Application.Handlers
{
    public class NotificationHandler
    {
        public async Task HandleAsync(NotificationDto notification)
        {
            // Обработка уведомления (например, валидация и отправка в очередь)
        }
    }
}
