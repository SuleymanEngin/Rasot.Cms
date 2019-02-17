using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rasot.Web.Factories
{
    public interface IPostModelFactory
    {
        dynamic PreparePostModel(List<string> includes);
    }
}
