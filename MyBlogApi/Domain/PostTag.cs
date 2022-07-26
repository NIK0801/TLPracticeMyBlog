namespace MyBlogApi.Domain
{
    public class PostTag
    {
        public int id { get; set; }
        public int postId { get; set; }
        public int tagId { get; set; }
        public Tag Tag { get; set; }
        public Post Post { get; set; }
    }
}
