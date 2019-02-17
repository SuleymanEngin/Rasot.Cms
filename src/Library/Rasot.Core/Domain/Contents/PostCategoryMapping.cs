using Rasot.Core.Domain.Categories;

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
