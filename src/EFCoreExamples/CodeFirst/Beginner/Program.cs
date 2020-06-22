using Beginner.Data;
using Beginner.Data.Entities;
using System;
using System.Threading.Tasks;

namespace Beginner
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var dbContext = new BlogDbContext();

            var postObject = new Post { Title = "My First Post" };
            postObject.Comments.Add(new Comment { Body = "This is my first comment " });

            dbContext.Posts.Add(postObject);
            _ = await dbContext.SaveChangesAsync();


            Console.WriteLine("Entity Framework Core");

        }
    }
}
