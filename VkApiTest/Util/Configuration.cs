using System;
using Microsoft.Extensions.Configuration;

namespace VkApiTest.Util
{
    public static class Configuration
    {
        public static IConfiguration Config;
        public static string Env;

        static Configuration()
        {
            Config = new ConfigurationBuilder()
                .AddJsonFile("config.prod.json")
                .AddJsonFile("config.dev.json")
                .AddEnvironmentVariables()
                .Build();
            Env = Config["env"] ?? "prod";
        }

        public static string Get(string parameter)
        {
            return Config[Env + ":" + parameter];
        }
    }
}
