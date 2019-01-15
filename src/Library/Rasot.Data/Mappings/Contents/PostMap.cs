using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rasot.Core.Domain.Contents;

namespace Rasot.Data.Mappings.Contents
{
    public class PostMap : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Post");
            builder.HasKey(p => p.Id);
            builder.HasOne(p => p.Customer).WithMany(p => p.Posts).HasForeignKey(f => f.CustomerId);
            builder.Ignore(p => p.PostCategories);
          
        }
    }
}
