using System;
using System.Collections.Generic;
using System.Text;

namespace Rasot.Infrastructure.Modules
{
    public interface IModuleConfigurationManager
    {
        IEnumerable<Module> GetModules();
    }
}
