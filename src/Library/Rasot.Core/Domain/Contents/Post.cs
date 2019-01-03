using System.Collections.Generic;

namespace Rasot.Core.Domain.Contents
{
    public class Post:BaseEntity
    {
        private ICollection<PostCategoryMapping> postCategories;

        public string Title { get; set; }
        public string Content { get; set; }
        public ICollection<PostCategoryMapping> PostCategories {
            get => postCategories ?? (postCategories = new List<PostCategoryMapping>());
            protected set => postCategories = value;
        }
    }
}