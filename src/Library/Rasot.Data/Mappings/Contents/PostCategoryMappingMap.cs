using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rasot.Core.Domain.Contents;

namespace Rasot.Data.Mappings.Contents
{
    public class PostCategoryMappingMap : IEntityTypeConfiguration<PostCategoryMapping>
    {
        public void Configure(EntityTypeBuilder<PostCategoryMapping> builder)
        {
            builder.ToTable("PostCategoryMapping");
            builder.HasKey(p => p.Id);
            builder.HasOne(p => p.Category).WithMany().HasForeignKey(p => p.CategoryId);
            builder.HasOne(p => p.Post).WithMany(p => p.PostCategories).HasForeignKey(p => p.PostId);
        }
    }
}
