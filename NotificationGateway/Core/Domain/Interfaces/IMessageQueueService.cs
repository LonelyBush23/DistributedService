using DistributedService.NotificationGateway.Core.Application.DTOs;

namespace DistributedService.NotificationGateway.Core.Domain.Interfaces
{
    public interface IMessageQueueService
    {
        Task SendMessageAsync(NotificationDto notification);
    }
}
