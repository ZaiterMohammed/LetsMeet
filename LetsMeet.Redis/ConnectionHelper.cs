﻿
namespace LetsMeet.Redis
{
    using StackExchange.Redis;
    using System;

    public class ConnectionHelper
    {
        private static readonly Lazy<ConnectionMultiplexer> lazyConnection;

        static ConnectionHelper()
        {
            lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {
                return ConnectionMultiplexer.Connect(ConfigurationManager.AppSetting["RedisURL"]);
            });
        }

        public static ConnectionMultiplexer Connection
        {
            get
            {
                return lazyConnection.Value;
            }
        }
    }
}
