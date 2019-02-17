using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rasot.Web.Models.Customers
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<string> Roles { get; set; }
    }
}
