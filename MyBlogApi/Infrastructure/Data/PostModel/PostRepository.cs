using static MyBlogApi.Infrastructure.Data.IRepository;
using MyBlogApi.Domain;

namespace MyBlogApi.Infrastructure.Data.PostModel
{
    public class PostRepository : IRepository<Post>
    {
        private readonly Context _dbContext;

        public PostRepository(Context dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Post> GetAll()
        {
            return _dbContext.Post.ToList();
        }

        public int Create(Post post)
        {
            int id = _dbContext.Post.Add(post).Entity.id;
            _dbContext.SaveChanges();
            return id;
        }

        public void Delete(Post post)
        {
            _dbContext.Post.Remove(post);
            _dbContext.SaveChanges();
        }

        public Post GetById(int id)
        {
            return _dbContext.Post.SingleOrDefault(post => post.id == id);
        }

        public void Update(Post post)
        {
            _dbContext.Post.Update(post);
            _dbContext.SaveChanges();
        }
    }
}
