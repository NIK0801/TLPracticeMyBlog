using MyBlogApi.Domain;
using MyBlogApi.Dto;
using MyBlogApi.Extensions;
using MyBlogApi.Infrastructure;
using MyBlogApi.Infrastructure.Data.UoW;
using static MyBlogApi.Infrastructure.Data.IRepository;

namespace MyBlogApi.Services
{
    public class CategoryService : IService<Category, CategoryDto>
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IRepository<Category> categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public List<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public int Create(CategoryDto categoryDto)
        {
            if (categoryDto == null)
            {
                throw new Exception($"{nameof(categoryDto)} not found");
            }

            Category categoryEntity = categoryDto.ConvertToCategories();

            int id = _categoryRepository.Create(categoryEntity);
            _unitOfWork.SaveEntitiesAsync();

            return id;
        }

        public void Update(CategoryDto categoryDto)
        {
            if (categoryDto == null)
            {
                throw new Exception($"{nameof(categoryDto)} not found");
            }
            Category category = categoryDto.ConvertToCategories();

            _categoryRepository.Update(category);
            _unitOfWork.SaveEntitiesAsync();
        }

        public void Delete(int Id)
        {
            Category category = _categoryRepository.GetById(Id);
            if (category == null)
            {
                throw new Exception($"{nameof(category)} not found, #id - {Id}");
            }
            _categoryRepository.Delete(category);
            _unitOfWork.SaveEntitiesAsync();
        }

        public Category GetById(int Id)
        {
            Category category = _categoryRepository.GetById(Id);
            if (category == null)
            {
                throw new Exception($"{nameof(category)} not found, #id - {Id}");
            }

            return category;
        }
    }
}
