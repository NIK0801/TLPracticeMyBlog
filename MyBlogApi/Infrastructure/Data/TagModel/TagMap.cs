using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlogApi.Domain;

namespace MyBlogApi.Infrastructure.Data.TagModel
{
    public class TagMap : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasKey(x => x.id);
            builder.Property(x => x.id).ValueGeneratedOnAdd();
            builder.Property(x => x.title);
            builder
                .HasMany<PostTag>(g => g.PostTag)
                .WithOne(s => s.Tag)
                .HasForeignKey(s => s.tagId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
