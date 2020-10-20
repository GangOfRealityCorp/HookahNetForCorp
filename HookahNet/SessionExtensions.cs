using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using Newtonsoft.Json;


namespace HookahNet
{
    public enum SessionKeys { organizationFilterComposition };
    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, SessionKeys key, T value)
        {
            session.SetString(key.ToString(), JsonConvert.SerializeObject(value));
        }

        public static T Get<T>(this ISession session, SessionKeys key)
        {
            var value = session.GetString(key.ToString());
            return value == null ? default : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
