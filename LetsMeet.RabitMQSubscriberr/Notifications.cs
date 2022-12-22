
namespace LetsMeet.RabitMQSubscriber
{
    using global::Notifications;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Threading.Tasks;

    public class Notifications
    {
        private readonly IConfiguration Configuration;

        public Notifications()
        {
          
        }
        public Notifications(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public async Task AddNotifications(Notification nofification)
        {
            using SqlConnection con = new SqlConnection("Server=localhost,1440;Data Source=sqldata;Initial Catalog=master;Persist Security Info=True;User ID=SA;Password=vV5r9tn0M4@;Integrated Security=false;");
            string sql = "usp_CreateNotification";
            using SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NotificationType", nofification.NotificationType);
            cmd.Parameters.AddWithValue("@CreatedDateNotification", DateTime.UtcNow);
            await con.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
        }
    }
}
