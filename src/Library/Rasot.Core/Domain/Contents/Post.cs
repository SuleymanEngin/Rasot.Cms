using Rasot.Core.Domain.Customers;
using System.Collections.Generic;

namespace Rasot.Core.Domain.Contents
{
    public class Post:BaseEntity
    {
        private List<PostCategoryMapping> postCategories;

        public string Title { get; set; }
        public string Content { get; set; }
        public virtual List<PostCategoryMapping> PostCategories {
            get => postCategories ?? (postCategories = new List<PostCategoryMapping>());
            protected set => postCategories = value;
        }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}