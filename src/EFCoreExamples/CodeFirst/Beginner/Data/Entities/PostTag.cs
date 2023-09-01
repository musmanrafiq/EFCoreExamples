using Microsoft.EntityFrameworkCore;

namespace Beginner.Data.Entities
{
    [PrimaryKey(nameof(PostsId), nameof(TagsId))]
    public class PostTag
    {
        public int PostsId { get; set; }
        public virtual Post Posts { get; set; }
        public int TagsId { get; set; }
        public virtual Tag Tags { get; set; }
    }
}
