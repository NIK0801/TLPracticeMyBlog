using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlogApi.Domain;

namespace MyBlogApi.Infrastructure.Data
{
    public class PostTagMap : IEntityTypeConfiguration<PostTag>
    {
        public void Configure(EntityTypeBuilder<PostTag> builder)
        {
            builder.HasKey(x => x.id);
            builder.Property(x => x.id).ValueGeneratedOnAdd();
            builder.Property(x => x.postId);
            builder.Property(x => x.tagId);
            builder
                .HasOne<Tag>(s => s.Tag) 
                .WithMany(g => g.PostTag)
                .HasForeignKey(s => s.tagId);
            builder
                .HasOne<Post>(s => s.Post) 
                .WithMany(g => g.PostTag)
                .HasForeignKey(s => s.postId);

        }
    }
}
