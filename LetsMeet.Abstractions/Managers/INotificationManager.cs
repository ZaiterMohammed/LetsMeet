
namespace LetsMeet.Abstractions.Managers
{
    using LetsMeet.Notifications;
    using System;
    using System.Threading.Tasks;

    public interface INotificationManager
    {
        public Task AddNotifications(NotificationType type, Guid Id);
        public Task<int> GetNotificationsNumberByType(NotificationType type);
    }
}
