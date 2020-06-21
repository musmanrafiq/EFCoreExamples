using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Beginner.Data.Entities
{
    public class Author
    {
        public Author()
        {
            Books = new HashSet<Book>();
        }
        public int AuthorId { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
