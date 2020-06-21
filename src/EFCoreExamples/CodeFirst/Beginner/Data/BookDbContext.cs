using Beginner.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Beginner.Data
{

    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\;Database=EFCoreDemo;Trusted_Connection=True;MultipleActiveResultSets=true");
        }*/
    }

    public class TemporaryDbContextFactory : IDesignTimeDbContextFactory<BookDbContext>
    {
        public BookDbContext CreateDbContext(string[] args)
        {
            IConfigurationBuilder configBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");
            IConfigurationRoot configuration = configBuilder.Build();
            DbContextOptionsBuilder<BookDbContext> builder = new DbContextOptionsBuilder<BookDbContext>();
            builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            return new BookDbContext(builder.Options);
        }
    }
}
