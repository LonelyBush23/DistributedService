using DistributedService.MessageQueue.Application.DTOs;
using DistributedService.MessageQueue.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DistributedService.MessageQueue.API.Controllers
{
    [ApiController]
    [Route("api/notifications")]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationQueue _notificationQueue;

        public NotificationController(INotificationQueue notificationQueue)
        {
            _notificationQueue = notificationQueue;
        }

        [HttpPost]
        public async Task<IActionResult> SendNotification([FromBody] NotificationDto notification)
        {
            await _notificationQueue.PublishAsync(notification);
            return Ok();
        }
    }
}
