using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;
using Rasot.Core.Caching;

namespace Rasot.MemoryCache
{
    public class MemoryCacheManager : ICacheManager
    {
        private readonly IMemoryCache _cache;
        protected static readonly ConcurrentDictionary<string, bool> _allKeys;
        protected CancellationTokenSource _cancellationTokenSource;

        static MemoryCacheManager()
        {
            _allKeys = new ConcurrentDictionary<string, bool>();
        }


        protected string AddKey(string key)
        {
            _allKeys.TryAdd(key, true);
            return key;
        }
        protected string RemoveKey(string key)
        {
            TryRemoveKey(key);
            return key;
        }

        protected void TryRemoveKey(string key)
        {
            if(_allKeys.TryRemove(key,out _))
            {
                _allKeys.TryUpdate(key, false, true);
            }
        }

        public MemoryCacheManager(IMemoryCache cache)
        {
            this._cache = cache;
            _cancellationTokenSource = new CancellationTokenSource();
        }
        public void Clear()
        {
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource.Dispose();
            _cancellationTokenSource = new CancellationTokenSource();
        }

        private void ClearKeys()
        {
            foreach (var key in _allKeys.Where(p => !p.Value).Select(p => p.Key).ToList())
            {
                RemoveKey(key);
            }
        }

        public bool Contains(string key)
        {
            return _cache.TryGetValue(key, out object _);
        }

        public void Dispose()
        {
           
        }

        public T Get<T>(string key, Func<T> acquire, int? cacheTime)
        {
            return GetAsync(key, () => Task.Run(acquire), cacheTime).Result;
        }

        public async Task<T> GetAsync<T>(string key,Func<Task<T>> acquire, int? cacheTime)
        {
            if (_cache.TryGetValue(key, out T value))
                return value;

            var result = await acquire();

            Set(key, result, cacheTime.GetValueOrDefault(60));

            return result;
        }
        public void Remove(string key)
        {
            _cache.Remove(key);
        }

        public void RemoveByPattern(string keyPattern)
        {
            var regex = new Regex(keyPattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var matchesKeys = _allKeys.Where(p => p.Value).Select(p => p.Key).Where(p => regex.IsMatch(p)).ToList();
            foreach (var item in matchesKeys)
            {
                _cache.Remove(item);
            }
        }

        public void Set(string key, object data, int cacheTime)
        {
            if (data != null)
                _cache.Set(AddKey(key), data, GetMemoryCacheEntryOptions(TimeSpan.FromMinutes(cacheTime)));
        }

        protected MemoryCacheEntryOptions GetMemoryCacheEntryOptions(TimeSpan cacheTime)
        {
            var options = new MemoryCacheEntryOptions()
                .AddExpirationToken(new CancellationChangeToken(_cancellationTokenSource.Token))
                .RegisterPostEvictionCallback(PostEviction);

            options.AbsoluteExpirationRelativeToNow = cacheTime;
            return options;
        }

        private void PostEviction(object key, object value, EvictionReason reason, object state)
        {
            if (reason == EvictionReason.Replaced)
                return;
            ClearKeys();
            TryRemoveKey(key.ToString());
        }
    }
}
