using System.ComponentModel.DataAnnotations.Schema;

namespace MyBlogApi.Domain
{
    public class Category
    {
        public int id { get; set; }
        public string title { get; set; }
        public List<Post> Post { get; } = new();
    }
}
