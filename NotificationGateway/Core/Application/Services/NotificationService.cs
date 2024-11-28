using NotificationGateway.Core.Application.DTOs;
using NotificationGateway.Core.Application.Interfaces;
using NotificationGateway.Core.Domain.Entities;

namespace NotificationGateway.Core.Application.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IMessageQueueService _messageQueueService;

        public NotificationService(IMessageQueueService messageQueueService)
        {
            _messageQueueService = messageQueueService;
        }

        public async Task<Result> SendNotificationAsync(NotificationDto notification)
        {
            try
            {
                // Маршрутизация уведомления в соответствующую очередь
                await _messageQueueService.SendMessageAsync(notification);
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }
    }
}
