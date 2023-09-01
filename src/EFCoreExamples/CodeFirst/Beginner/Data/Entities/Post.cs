using Beginner.Data.Entities;
using System.Collections.Generic;

namespace Beginner.Data
{
    public class Post
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<PostTag> PostTags { get; set; }
    }
}
