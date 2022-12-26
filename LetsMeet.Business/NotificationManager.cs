using LetsMeet.Abstractions.Store;
using LetsMeet.Notifications;
using LetsMeet.Redis;
using LetsMeet.WebApi.RabbitMQ;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LetsMeet.Business
{
    public class NotificationManager
    {
        private readonly INotificationStore notificationStore;

        public NotificationManager(INotificationStore notificationStore)
        {
            this.notificationStore = notificationStore ?? throw new ArgumentNullException(nameof(notificationStore));
        }

        public Task AddNotifications(NotificationType type, Guid Id)
        {
            return notificationStore.AddNotifications(type, Id);
        }

        public Task<int> GetNotificationsNumberByType(NotificationType type)
        {
            return notificationStore.GetNotificationsNumberByType(type);
        }

    }
}
