
namespace LetsMeet.Abstractions.Store
{
    using LetsMeet.Notifications;
    using System;
    using System.Threading.Tasks;

    public interface INotificationStore
    {
        public Task AddNotifications(NotificationType type, Guid Id);
        public Task<int> GetNotificationsNumberByType(NotificationType type);

    }
}
