using DistributedService.NotificationGateway.Core.Application.DTOs;

namespace DistributedService.NotificationGateway.Core.Domain.Interfaces
{
    public interface INotificationService
    {
        Task<IResult> SendNotificationAsync(NotificationDto notification);
    }
}
