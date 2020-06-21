using Beginner.Data;
using Beginner.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Beginner
{
    class Program
    {
        private static IConfigurationRoot Configuration { get; set; }

        static async Task Main(string[] args)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json");
            Configuration = builder.Build();

            IServiceCollection services = new ServiceCollection();
            services.AddDbContext<BookDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            var ServiceProvider = services.BuildServiceProvider();

            var dbContext = ServiceProvider.GetService<BookDbContext>();

            dbContext.Books.Add(new Book { Title = "Good", Author = new Author { FirstName = "Usman", LastName = "Rafiq" } });
            _ = await dbContext.SaveChangesAsync().ConfigureAwait(false);

            var book = await dbContext.Books.FirstOrDefaultAsync();

            Console.WriteLine("Hello World!");

            Console.WriteLine($"First book is {book.Title}");
        }
    }
}
