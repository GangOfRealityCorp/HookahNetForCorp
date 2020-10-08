using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace HookahNet.Controllers.Account
{
    public class AuthOptions
    {
        private static IConfigurationRoot GetConfig()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");

            IConfigurationRoot AppConfiguration = builder.Build();
            return AppConfiguration;
        }

        public static string ISSUER => GetConfig()["TokenConfigs:ISSUER"]; // издатель токена
        public static string AUDIENCE = GetConfig()["TokenConfigs:AUDIENCE"]; // потребитель токена
        private static string KEY = GetConfig()["TokenConfigs:KEY"];   // ключ для шифрации
        public static int LIFETIME = int.Parse(GetConfig()["TokenConfigs:LIFETIME"]); // время жизни токена - 5 + 15 минут

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
