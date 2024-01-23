using Microsoft.Extensions.Configuration;

namespace SenderSQS.Commons
{
    public static class ConfigurationLoader
    {

        public static IConfiguration LoadConfiguration()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfiguration config = builder.Build();
            return config;
        }
    }
}
