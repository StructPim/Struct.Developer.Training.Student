using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Helpers
{
    public static class ConfigHelper
    {
        public static BootstrapOptions GetConfigValue()
        {
            //Init config reading and ApiClient
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);
            IConfiguration config = builder.Build();

            var participantNumber = config["ParticipantNumber"];
            var participantType = config["ParticipantType"];

            return new BootstrapOptions
            {
                ApiUrl = $"https://api.{participantType}{participantNumber}.cloudtest11.structpim.com/",
                ApiKey = config["StructApiConfig:Key"],
                MessageQueueName = $"{participantType}{participantNumber}",
                MessageQueueConnectionString = config["Azure:MessageQueue"],
                BlobContainerConnectionString = config["Azure:BlobContainer"]
            };
        }
    }

    public class BootstrapOptions
    {
        public string? ApiUrl { get; set; }
        public string? ApiKey { get; set; }
        public string? MessageQueueName { get; set; }
        public string? MessageQueueConnectionString { get; set; }
        public string? BlobContainerConnectionString { get; set; }
    }
}
