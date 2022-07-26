using static MyBlogApi.Infrastructure.Data.IRepository;
using MyBlogApi.Domain;

namespace MyBlogApi.Infrastructure.Data.CategoryModel
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly Context _dbContext;

        public CategoryRepository(Context dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Category> GetAll()
        {
            return _dbContext.Category.ToList();
        }

        public int Create(Category category)
        {
            int id = _dbContext.Category.Add(category).Entity.id;
            _dbContext.SaveChanges();
            return id;
        }

        public void Delete(Category category)
        {
            _dbContext.Category.Remove(category);
            _dbContext.SaveChanges();
        }

        public Category GetById(int id)
        {
            return _dbContext.Category.SingleOrDefault(category => category.id == id);
        }

        public void Update(Category category)
        {
            _dbContext.Category.Update(category);
            _dbContext.SaveChanges();
        }
    }
}
