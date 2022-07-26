using static MyBlogApi.Infrastructure.Data.IRepository;
using MyBlogApi.Domain;

namespace MyBlogApi.Infrastructure.Data.TagModel 
{
    public class TagRepository : IRepository<Tag>
    {
        private readonly Context _dbContext;

        public TagRepository(Context dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Tag> GetAll()
        {
            return _dbContext.Tag.ToList();
        }

        public int Create(Tag tag)
        {
            int id = _dbContext.Tag.Add(tag).Entity.id;
            _dbContext.SaveChanges();
            return id;
        }

        public void Delete(Tag tag)
        {
            _dbContext.Tag.Remove(tag);
            _dbContext.SaveChanges();
        }

        public Tag GetById(int id)
        {
            return _dbContext.Tag.SingleOrDefault(tag => tag.id == id);
        }

        public void Update(Tag tag)
        {
            _dbContext.Tag.Update(tag);
            _dbContext.SaveChanges();
        }
    }
}


