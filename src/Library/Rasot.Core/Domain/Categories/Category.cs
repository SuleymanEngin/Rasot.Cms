using System;
using System.Collections.Generic;
using System.Text;

namespace Rasot.Core.Domain.Categories
{
    public  class Category:BaseEntity
    {


        public string Name { get; set; }
        public bool  Deleted { get; set; }
    }
}
