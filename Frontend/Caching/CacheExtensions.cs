using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glav.CacheAdapter.Core;
using Glav.CacheAdapter.DependencyManagement;

namespace ScalabiltyHomework.Frontend.Caching
{
    public static class CacheExtensions
    {
        public static T Get<T>(this ICacheProvider provider, CacheKey cacheKey, DateTime absoluteExpiryDate,
            Func<T> getData, string parentKey = null,
            CacheDependencyAction actionForDependency = CacheDependencyAction.ClearDependentItems) where T : class
        {
            return provider.Get<T>(cacheKey.ToString(), absoluteExpiryDate, getData, parentKey);
        }


        public static T Get<T>(this ICacheProvider provider, CacheKey cacheKey, TimeSpan slidingExpiryWindow,
            Func<T> getData, string parentKey = null,
            CacheDependencyAction actionForDependency = CacheDependencyAction.ClearDependentItems) where T : class
        {
            return provider.Get<T>(cacheKey.ToString(), slidingExpiryWindow, getData, parentKey, actionForDependency);
        }


        public static void InvalidateCacheItem(this ICacheProvider provider, CacheKey cacheKey)
        {
            provider.InvalidateCacheItem(cacheKey.ToString());
        }

        public static void InvalidateCacheItems(this ICacheProvider provider, IEnumerable<CacheKey> cacheKeys)
        {
            var keys = cacheKeys.Select(x => x.ToString());
            provider.InvalidateCacheItems(keys);
        }
    }
}