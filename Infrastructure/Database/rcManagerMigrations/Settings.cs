using Microsoft.Extensions.Configuration;
using System.IO;

namespace rcDbSqlServerEF
{
    public class Settings
    {
        public static IConfiguration GetSettings()
        {
            IConfigurationRoot configuration;

            ConfigurationBuilder builder = new ConfigurationBuilder();

            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");

            configuration = builder.Build();

            return configuration;
        }

        public static string GetSettings(string sectionName, string key)
        {
            IConfigurationSection section;

            section = GetSettings().GetSection(sectionName);

            return section.GetValue<string>(key);
        }

        public static string GetSettings(string key)
        {
            return GetSettings("Settings", key);
        }

        public static string GetConnectionString()
        {
            return GetSettings("ConnectionStrings", "DefaultConnection");
        }

        public static string GetConnectionString(string key)
        {
            return GetSettings("ConnectionStrings", key);
        }
    }
}
