
namespace LetsMeet.Store
{
    using LetsMeet.Abstractions.Models;
    using LetsMeet.Abstractions.Store;
    using LetsMeet.Notifications;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Threading.Tasks;

    public class NotificationStore
    {
        private readonly IConfiguration Configuration;

        public NotificationStore()
        {

        }
        public NotificationStore(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public async Task AddNotifications(NotificationType type, Guid Id)
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);

            using SqlCommand cmd = new SqlCommand("usp_CreateNotification", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@notificationId", Id);
            cmd.Parameters.AddWithValue("@notificationType", type);
            cmd.Parameters.AddWithValue("@createdDateNotification", DateTime.UtcNow);

            await con.OpenAsync();

            try
            {
                await cmd.ExecuteNonQueryAsync();
            }
            finally
            {
                await con.CloseAsync();
            }
        }


        public async Task<int> GetNotificationsNumberByType(NotificationType type)
        {
            using SqlConnection con = new SqlConnection(Configuration["ConnectionString"]);

            using SqlCommand cmd = new SqlCommand("usp_NotificationsNumberByType", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@notificationType", type);

            await con.OpenAsync();

            try
            {
                await cmd.ExecuteNonQueryAsync();
            }
            finally
            {
                await con.CloseAsync();
            }

            var notifications = new List<NotificationMessage>();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    notifications.Add(new NotificationMessage()
                    {
                        Id = reader.GetGuid("NotificationId"),
                        Type = Enum.Parse<NotificationType>(reader.GetString("NotificationType"))
                    });
                }
            }
            return notifications.Count;
        }


    }
}

