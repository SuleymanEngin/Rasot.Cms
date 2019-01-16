using Rasot.Infrastructure.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rasot.Infrastructure
{
    public static class GlobalConfiguration
    {
        public static IList<Module> Modules { get; set; } = new List<Module>();

        //public static IList<Culture> Cultures { get; set; } = new List<Culture>();

        public static string DefaultCulture => "en-US";

        public static string WebRootPath { get; set; }

        public static string ContentRootPath { get; set; }
    }
}
