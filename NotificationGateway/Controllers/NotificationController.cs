using Microsoft.AspNetCore.Mvc;
using DistributedService.NotificationGateway.Core.Domain.Interfaces;
using DistributedService.NotificationGateway.Core.Application.DTOs;

namespace DistributedService.NotificationGateway.Controllers
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

        //[HttpPost]
        //public async Task<IActionResult> SendNotification([FromBody] NotificationDto notification)
        //{
        //    var result = await _notificationService.SendNotificationAsync(notification);
        //    if (result.Success)
        //        return Ok(new { message = "Notification sent successfully!" });
        //    else
        //        return BadRequest(new { message = result.Message });
        //}

        // Endpoint для отправки уведомлений
        [HttpPost("send")]
        public async Task<IActionResult> SendNotification([FromBody] NotificationDto notification)
        {
            if (notification == null)
            {
                return BadRequest("Invalid notification data");
            }

            var result = await _notificationService.SendNotificationAsync(notification);

            if (result.Success)
            {
                return Ok(new { message = "Notification sent successfully" });
            }

            return StatusCode(500, new { message = "Failed to send notification", details = result.Message });
        }

        // Endpoint для получения статуса уведомления (пример)
        [HttpGet("status/{id}")]
        public async Task<IActionResult> GetNotificationStatus(int id)
        {
            var status = await _notificationService.GetNotificationStatusAsync(id);

            if (status == null)
            {
                return NotFound(new { message = "Notification not found" });
            }

            return Ok(status);
        }
    }
}
