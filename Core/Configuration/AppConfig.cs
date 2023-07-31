using Microsoft.Extensions.Configuration;

namespace Core.Configuration
{
    public class AppConfig
    {
        public static BrowserConfig Browser => BindConfiguration<BrowserConfig>();
        public static RealUserConfig RealUser => BindConfiguration<RealUserConfig>();
        private static IConfigurationRoot configurationRoot;

        static AppConfig()
        {
            configurationRoot = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                //.AddJsonFile($"appsettings.custom.json", optional: true, reloadOnChange: true)
                .Build();
        }

        private static T BindConfiguration<T>() where T : IConfiguration, new()
        {
            var config = new T();
            configurationRoot.GetSection(config.SectionName).Bind(config);
            return config;
        }

        public static string GetValue(string key)
        {
            return configurationRoot[key];
        }
    }
}
