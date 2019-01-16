using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace Rasot.Infrastructure.Modules
{
    public interface IModuleManager
    {
        void ConfigureServices(IServiceCollection services);
        void Configure(IApplicationBuilder app, HostingEnvironment env);
    }
}
