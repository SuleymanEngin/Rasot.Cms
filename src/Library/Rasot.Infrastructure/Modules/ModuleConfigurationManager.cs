using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Rasot.Infrastructure.Modules
{
    public class ModuleConfigurationManager : IModuleConfigurationManager
    {
        public static readonly string ModulesFileName = "modules.json";
        public IEnumerable<Module> GetModules()
        {

            var modulesPath = Path.Combine(GlobalConfiguration.ContentRootPath, ModulesFileName);
            using(var reader=new StreamReader(modulesPath))
            {
                string content = reader.ReadToEnd();
                dynamic modulesData = JsonConvert.DeserializeObject(content);
                foreach (dynamic item in modulesData)
                {
                    yield return new Module()
                    {
                         FriendlyName=item.FriendlyName,
                         Version=Version.Parse(item.Version.ToString()),
                    };
                }
            }
        }
    }
}
