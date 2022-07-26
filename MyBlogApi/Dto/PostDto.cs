namespace MyBlogApi.Dto
{
    public class PostDto
    {
        public int id { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public int isPublished { get; set; }
        public int categoryId { get; set; }
    }
}
