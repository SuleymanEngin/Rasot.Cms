using Rasot.Core.Domain.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rasot.Core.Domain.Contents
{
    public  class PostCategoryMapping:BaseEntity
    {
        public int PostId { get; set; }
        public int CategoryId { get; set; }

        public virtual Post Post { get; set; }
        public virtual Category Category { get; set; }
    }
}
