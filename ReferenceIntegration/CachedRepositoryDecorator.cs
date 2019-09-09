using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReferenceIntegration
{
    public class CachedRepositoryDecorator<T>
    {
        public CachedRepositoryDecorator()
        {
            //5 second cache
            //cacheOptions = 
        }

        public static IMemoryCache _cache = null;
        public static bool CreateEntry(string key, object Value)
        {
            if (!IsKeyAlreadyExists(key))
            {
                XCreateEntry(key, Value);
                return true;
            }
            return false;
        }

        private static bool RemoveEntry(string Key)
        {
            try
            {
                CachedRepositoryDecorator<T>.RemoveEntry(Key);
                return true;
            }
            catch (Exception) { }
            return false;
        }

        private static void XCreateEntry(string Key, object Value)
        {
            using (var entry = _cache.CreateEntry(Key))
            {
                entry.Value = Value;
                entry.AbsoluteExpiration = DateTime.UtcNow.AddSeconds(120);
            }
        }

        public static bool IsKeyAlreadyExists(string key)
        {
            object val = null;
            bool success_ = _cache.TryGetValue(key, out val);
            return success_;
        }

        public static T Find(string key)
        {
            if (_cache.TryGetValue(key, out T entry))
            {
                return entry;
            }
            return default;
        }
    }
}
