using Beginner.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Beginner.Data
{
    public class BlogDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost;Database=BlogDb;Trusted_Connection=True;MultipleActiveResultSets=true;");
        }
    }
}
