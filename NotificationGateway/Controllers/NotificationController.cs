using Microsoft.AspNetCore.Mvc;
using NotificationGateway.Core.Application.Services;
using NotificationGateway.Core.Application.DTOs;

namespace NotificationGateway.Controllers
{
    [Route("api/notifications")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpPost]
        public async Task<IActionResult> SendNotification([FromBody] NotificationDto notification)
        {
            var result = await _notificationService.SendNotificationAsync(notification);
            if (result.IsSuccess)
                return Ok(new { message = "Notification sent successfully!" });
            else
                return BadRequest(new { message = result.ErrorMessage });
        }
    }
}
