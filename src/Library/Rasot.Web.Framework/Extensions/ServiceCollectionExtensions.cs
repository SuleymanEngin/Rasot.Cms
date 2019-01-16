using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Rasot.Infrastructure;
using Rasot.Infrastructure.Modules;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Rasot.Web.Framework.Extensions
{
    public static class ServiceCollectionExtensions
    {
        private static readonly IModuleConfigurationManager _modulesConfig = new ModuleConfigurationManager();

        public static IServiceCollection AddRasotMvc(this IServiceCollection services,IList<Infrastructure.Modules.Module> modules)
        {
            var mvcBuilder = services.AddMvc(options => options.EnableEndpointRouting = false).SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_2);

            foreach (var item in modules)
            {
                mvcBuilder.AddApplicationPart(item.Assembly);
            }

            return services;
        }
        public static IServiceCollection AddModules(this IServiceCollection services,string rootPath)
        {
            const string moduleManifestName = "module.json";
            var modulesFolder = Path.Combine(rootPath, "Modules");
            foreach (var module in _modulesConfig.GetModules())
            {
                var moduleFolder = new DirectoryInfo(Path.Combine(modulesFolder,  module.FriendlyName, "netcoreapp2.2"));
                var moduleSettings = Path.Combine(moduleFolder.FullName, moduleManifestName);
                using(var reader=new StreamReader(moduleSettings))
                {
                    string content = reader.ReadToEnd();
                    dynamic moduleMetaData = JsonConvert.DeserializeObject(content);
                    module.DisplayName = moduleMetaData.DisplayName;
                }


                module.Assembly = Assembly.LoadFrom(Path.Combine(moduleFolder.FullName, module.FriendlyName + ".dll"));

                GlobalConfiguration.Modules.Add(module);

                RegisterModuleManager(module, ref services);

            }

            return services;
        }

        private static void RegisterModuleManager(Infrastructure.Modules.Module module, ref IServiceCollection services)
        {
           var moduleManagerType= module.Assembly.GetTypes().FirstOrDefault(t => typeof(IModuleManager).IsAssignableFrom(t));
           if(moduleManagerType !=null  && moduleManagerType != typeof(IModuleManager))
            {
                services.AddSingleton(typeof(IModuleManager), moduleManagerType);
            }

        }
    }
}
