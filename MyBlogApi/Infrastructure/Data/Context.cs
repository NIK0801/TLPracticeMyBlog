using MyBlogApi.Domain;
using MyBlogApi.Infrastructure.Data.CategoryModel;
using MyBlogApi.Infrastructure.Data.PostModel;
using MyBlogApi.Infrastructure.Data.TagModel;
using Microsoft.EntityFrameworkCore;
using MyBlogApi.Infrastructure.Data.UoW;

namespace MyBlogApi.Infrastructure.Data
{
    public class Context : DbContext, IUnitOfWork
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        public DbSet<Post> Post { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Tag> Tag { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new PostMap());
            builder.ApplyConfiguration(new CategoryMap());
            builder.ApplyConfiguration(new TagMap());
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            await SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
