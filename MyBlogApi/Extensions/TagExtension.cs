using MyBlogApi.Domain;
using MyBlogApi.Dto;

namespace MyBlogApi.Extensions
{
    public static class TagExtension
    {
        public static Tag ConvertToTags(this TagDto tagDto)
        {
            return new Tag
            {
                id = tagDto.id,
                title = tagDto.title
            };
        }
        public static TagDto ConvertToTagsDto(this Tag tag)
        {
            return new TagDto
            {
                id = tag.id,
                title = tag.title
            };
        }
    }
}
