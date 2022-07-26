using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlogApi.Domain;

namespace MyBlogApi.Infrastructure.Data.PostModel
{
    public class PostMap : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {

            builder.HasKey(x => x.id);
            builder.Property(x => x.id).ValueGeneratedOnAdd();
            builder.Property(x => x.title);
            builder.Property(x => x.content);
            builder.Property(x => x.isPublished);
            builder.Property(x => x.categoryId);
            builder
                .HasOne<Category>(s => s.Category)
                .WithMany(g => g.Post)
                .HasForeignKey(s => s.categoryId);
            builder
                .HasMany<PostTag>(g => g.PostTag)
                .WithOne(s => s.Post)
                .HasForeignKey(s => s.postId)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
