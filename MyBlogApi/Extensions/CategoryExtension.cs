using MyBlogApi.Domain;
using MyBlogApi.Dto;

namespace MyBlogApi.Extensions
{
    public static class CategoryExtension
    {
        public static Category ConvertToCategories(this CategoryDto categoryDto)
        {
            return new Category
            {
                id = categoryDto.id,
                title = categoryDto.title
            };
        }
        public static CategoryDto ConvertToCategoriesDto(this Category category)
        {
            return new CategoryDto
            {
                id = category.id,
                title = category.title
            };
        }
    }
}
