using System.ComponentModel.DataAnnotations;

namespace Beginner.Data.Entities
{
    public class Book
    {
        public int Id { get; set; }
        [StringLength(200)]
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
