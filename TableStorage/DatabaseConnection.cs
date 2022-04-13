using Microsoft.Extensions.Configuration;

namespace TableStorage
{
    public class DatabaseConnection<T>
        where T : class
    {
        public static string Get()
        {
            var secretConfig = new ConfigurationBuilder()
                .AddUserSecrets<T>()
                .Build();
            return secretConfig["connectionstring"];
        }
    }
}