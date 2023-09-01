using System.Collections.Generic;

namespace Beginner.Data.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PostTag> PostTags { get; set; }
    }
}
