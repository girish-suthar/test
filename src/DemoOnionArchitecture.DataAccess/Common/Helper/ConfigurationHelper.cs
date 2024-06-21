using Microsoft.Extensions.Configuration;

namespace DemoOnionArchitecture.DataAccess.Common.Helper
{
    public static class ConfigurationHelper
    {
        private static IConfiguration _configuration = null;

        public static void config(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public static IConfigurationSection GetConfigurationSection(string key)
        {
            var section = _configuration.GetSection(key);
            return section;
        }
    }
}
