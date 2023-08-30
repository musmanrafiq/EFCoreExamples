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
            // created db context
            var dbContext = new BlogDbContext();
            // created a post object
            var postObject = new Post
            {
                Title = "My First Post",
                Category = new Category { Name = "General" }
            };
            // associate a comment
            postObject.Comments.Add(
                new Comment { Body = "This is my first comment " });
            // post object to database
            dbContext.Posts.Add(postObject);
            _ = await dbContext.SaveChangesAsync();


            var posts = await dbContext.Posts
                .Include(x => x.Comments)
                .Include(x => x.Category).ToListAsync();

            foreach (var post in posts)
            {
                Console.WriteLine($"The title is {post.Title} , and the category is {post.Category.Name}");

                foreach (var comment in post.Comments)
                {
                    Console.WriteLine(comment.Body);
                }
            }
            Console.WriteLine("Entity Framework Core");

        }
    }
}
