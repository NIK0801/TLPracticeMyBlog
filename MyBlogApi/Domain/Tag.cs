using System.ComponentModel.DataAnnotations.Schema;

namespace MyBlogApi.Domain
{
    public class Tag
    {
        public int id { get; set; }
        public string title { get; set; }
        public List<PostTag> PostTag { get; } = new();
    }
}
