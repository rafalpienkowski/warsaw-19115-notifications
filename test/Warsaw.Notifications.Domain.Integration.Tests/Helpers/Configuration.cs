using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Warsaw.Notifications.Domain.Integration.Tests.Config
{
    public class Configuration
    {
        public string WarsawApiKey => GetApiKey();

        public static string GetApiKey()
        {            
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true)
                .Build();

            var warsawApiKey = configuration.GetSection("WarsawApiKey").Value;
            if (string.IsNullOrEmpty(warsawApiKey))
            {
                throw new Exception("Missing warsawApiKey in configuration");
            }
            return warsawApiKey;
        }
    }
}