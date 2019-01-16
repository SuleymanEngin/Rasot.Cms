using System;
using System.Reflection;

namespace Rasot.Infrastructure.Modules
{
    public class Module
    {
        public string FriendlyName { get; set; }
        public string DisplayName { get; set; }
        public Version Version { get; set; }
        public string Author { get; set; }
        public Assembly Assembly { get; set; }
    }
}
