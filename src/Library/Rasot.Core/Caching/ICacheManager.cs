using System;

namespace Rasot.Core.Caching
{
    public interface ICacheManager:IDisposable
    {
        T Get<T>(string key, Func<T> acquire, int? cacheTime);
        void Set(string key, object data, int cacheTime);
        bool Contains(string key);
        void Remove(string key);
        void RemoveByPattern(string keyPattern);
        void Clear();
    }
}
