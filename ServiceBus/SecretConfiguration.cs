using Microsoft.Extensions.Configuration;

namespace ServiceBus
{
    public class SecretConfiguration
    {
        public static string GetSecret()
        {
            var secretConfig = new ConfigurationBuilder()
                .AddUserSecrets<Program>()
                .Build();
            return secretConfig["connectionstring"];
        }
    }
}