using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlogApi.Domain;

namespace MyBlogApi.Infrastructure.Data.CategoryModel
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.id);
            builder.Property(x => x.id).ValueGeneratedOnAdd();
            builder.Property(x => x.title);
            builder
                .HasMany<Post>(g => g.Post)
                .WithOne(s => s.Category)
                .HasForeignKey(s => s.categoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
