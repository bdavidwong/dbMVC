using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Web.Caching;

namespace dbMVC.Lib
{
    public static class CacheExtensions
    {
        private static object sync = new object();

        private class Container<T>
        {
            public T Value;
        }

        public static TValue GetOrStore<TValue>(this Cache cache, string key, Func<TValue> create, TimeSpan slidingExpiration)
        {
            return cache.GetOrStore(key, create, Cache.NoAbsoluteExpiration, slidingExpiration);
        }

        public static TValue GetOrStore<TValue>(this Cache cache, string key, Func<TValue> create, DateTime absoluteExpiration)
        {
            return cache.GetOrStore(key, create, absoluteExpiration, Cache.NoSlidingExpiration);
        }

        //public static TValue GetOrStore<TValue>(this Cache cache, string key, Func<TValue> create, DateTime absoluteExpiration, TimeSpan slidingExpiration)
        //{
        //    return cache.GetOrStore(key, x=> create());
            
        //}

        public static TValue GetOrStore<TValue>(this Cache cache, string key, Func<string, TValue> create, DateTime absoluteExpiration, TimeSpan slidingExpiration)
        {
            var instance = cache.GetOrStoreContainer<TValue>(key, absoluteExpiration, slidingExpiration);
            if (instance.Value == null)
                lock (instance)
                    if (instance.Value == null)
                        instance.Value = create(key);

            return instance.Value;
        }

        private static Container<TValue> GetOrStoreContainer<TValue>(this Cache cache, string key, DateTime absoluteExpiration, TimeSpan slidingExpiration)
        {
            var instance = cache[key];
            if (instance == null)
                lock (cache)
                {
                    instance = cache[key];
                    if (instance == null)
                    {
                        instance = new Container<TValue>();

                        cache.Add(key, instance, null, absoluteExpiration, slidingExpiration, CacheItemPriority.Default, null);
                    }
                }

            return (Container<TValue>)instance;
        }
    }
}
