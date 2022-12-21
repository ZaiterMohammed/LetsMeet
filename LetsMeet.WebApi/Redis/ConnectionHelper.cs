using StackExchange.Redis;
using System.Configuration;

namespace LetsMeet.WebApi.Redis
{
    public class ConnectionHelper
    {
        private readonly IConfiguration Configuration;
        public ConnectionHelper(IConfiguration configuration)
        {
            Configuration = configuration;

        }
        public ConnectionHelper()
        {
            ConnectionHelper.lazyConnection = new Lazy<ConnectionMultiplexer>(() => {
                return ConnectionMultiplexer.Connect(configuration: Configuration["ConnectionString"]);
            });
        }
        private static Lazy<ConnectionMultiplexer> lazyConnection;
        public static ConnectionMultiplexer Connection
        {
            get
            {
                return lazyConnection.Value;
            }
        }
    }
}
