using Beginner.Data;
using Beginner.Data.Entities;
using Microsoft.EntityFrameworkCore;
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

            var posts = await dbContext.Posts.ToListAsync();
            foreach (var post in posts)
            {
                Console.WriteLine($"The title is {post.Title}");
            }
            Console.WriteLine("Entity Framework Core");

        }
    }
}
