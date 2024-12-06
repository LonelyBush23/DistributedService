using DistributedService.NotificationGateway.Core.Application.DTOs;
using DistributedService.NotificationGateway.Core.Domain.Interfaces;
using System.Threading.Tasks;

namespace DistributedService.NotificationGateway.Core.Application.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IMessageQueueService _messageQueueService;

        public NotificationService(IMessageQueueService messageQueueService)
        {
            _messageQueueService = messageQueueService;
        }

        public async Task<string> GetNotificationStatusAsync(int notificationId)
        {
            // Получение статуса уведомления (например, из базы данных)
            // Здесь возвращаем просто пример
            return await Task.FromResult("Sent");
        }

        public async Task<Domain.Interfaces.IResult> SendNotificationAsync(NotificationDto notification)
        {
            try
            {
                // Маршрутизация уведомления в соответствующую очередь
                await _messageQueueService.SendMessageAsync(notification);
                return (Domain.Interfaces.IResult)Result.Ok();
            }
            catch (Exception ex)
            {
                return (Domain.Interfaces.IResult)Result.BadRequest(ex.Message);
            }
        }
    }
}
