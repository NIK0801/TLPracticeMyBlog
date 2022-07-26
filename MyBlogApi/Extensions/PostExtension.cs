using MyBlogApi.Domain;
using MyBlogApi.Dto;

namespace MyBlogApi.Extensions
{
    public static class PostExtension
    {
        public static Post ConvertToPosts(this PostDto postDto)
        {
            return new Post
            {
                id = postDto.id,
                title = postDto.title,
                content = postDto.content,
                isPublished = postDto.isPublished,
                categoryId = postDto.categoryId
            };
        }
        public static PostDto ConvertToPostsDto(this Post post)
        {
            return new PostDto
            {
                id = post.id,
                title = post.title,
                content = post.content,
                isPublished = post.isPublished,
                categoryId = post.categoryId
            };
        }
    }
}
