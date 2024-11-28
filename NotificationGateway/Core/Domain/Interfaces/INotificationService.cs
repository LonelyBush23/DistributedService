namespace NotificationGateway.Core.Application.Services
{
    public interface INotificationService
    {
        Task<Result> SendNotificationAsync(NotificationDto notification);
    }
}
