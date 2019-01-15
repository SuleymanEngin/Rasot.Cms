using Rasot.Core.Domain.Contents;
using System.Collections.Generic;

namespace Rasot.Core.Domain.Customers
{
    public class Customer : BaseEntity
    {
        private ICollection<Post> posts;
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public int PasswordFormatType { get; set; }

        public virtual ICollection<Post> Posts
        {
            get { return posts ?? (posts = new List<Post>()); }
            protected set { posts = value; }
        }
    }
}
