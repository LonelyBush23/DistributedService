using NotificationGateway.Core.Application.DTOs;

namespace NotificationGateway.Core.Application.Interfaces
{
    public interface IMessageQueueService
    {
        Task SendMessageAsync(NotificationDto notification);
    }
}
