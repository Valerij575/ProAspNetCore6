﻿using System.Text.Json;

namespace SportsStore.Infrastructure
{
    public static class SessionExtensions
    {
        public static void SetJson<T>(this ISession session, string key, T value) 
        {
            var serialize = JsonSerializer.Serialize(value);
            session.SetJson(key, serialize);
        }

        public static T? GetJson<T> (this ISession session, string key)
        {
            var sessionData = session.GetString(key);
            return sessionData == null 
                        ? default(T) 
                        : JsonSerializer.Deserialize<T>(sessionData); 
        }
    }
}
