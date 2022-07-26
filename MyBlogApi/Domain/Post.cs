using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBlogApi.Domain
{
    public class Post
    {
        public int id { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public int isPublished { get; set; }
        public int categoryId { get; set; }
        public Category Category { get; set; }
        public List<PostTag> PostTag { get; } = new();
    }
}
