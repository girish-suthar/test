using DemoOnionArchitecture.DataAccess.Common.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoOnionArchitecture.DataAccess.Configurations
{
    public class JwtConfiguration
    {
        public static string JWT_KEY = ConfigurationHelper.GetConfigurationSection("Jwt")["Key"];
    }
}
