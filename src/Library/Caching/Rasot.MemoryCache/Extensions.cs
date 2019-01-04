using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Rasot.Core.Caching;

namespace Rasot.MemoryCache
{
    public static class Extensions
    {
        public static void AddMemoryCacheManager(this IServiceCollection services)
        {
            services.AddTransient<ICacheManager, MemoryCacheManager>();
        }
    }
}
