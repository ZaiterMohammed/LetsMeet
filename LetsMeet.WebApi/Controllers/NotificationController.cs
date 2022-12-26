using LetsMeet.Abstractions.Managers;
using LetsMeet.Abstractions.Models;
using LetsMeet.Business;
using LetsMeet.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace LetsMeet.WebApi.Controllers
{
    public class NotificationController : Controller
    {
        private readonly INotificationManager notificationManager;

        public NotificationController(INotificationManager notificationManager)
        {
            this.notificationManager = notificationManager;
        }

        [HttpGet]
        [Route("api/notifications/{NotificationType}")]
        [ProducesResponseType(200, Type = typeof(Notification))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetNotificationsNumberByType([FromRoute] NotificationType notififType)
        {
            return Ok(await notificationManager.GetNotificationsNumberByType(notififType));
        }
    }
}
