using System;
using System.Linq;

public class Crud
{
    Blog? blog = new();
    private BloggingContext db;
    
    public Crud(BloggingContext db)
    {
        this.db = db;
    }

    public void Create()
    {
        Console.WriteLine("Inserting a new blog");
        db?.Add(new Blog {Url = "http://blogs.msdn.com/adonet"});
        db?.SaveChanges();
    }

    public void Read()
    {
        Console.WriteLine("Querying for a blog");
        blog = db?.Blogs?.OrderBy(b => b.BlogId).First();

        Console.WriteLine($"Id: {blog?.BlogId}");
        Console.WriteLine($"Url: {blog?.Url}");

        foreach (var item in blog.Posts)
        {
            Console.WriteLine($"Title: {item.Title}");
            Console.WriteLine($"Content: {item.Content}");
        }       
    }

    public void Update()
    {
        Console.WriteLine("Updating the blog and adding a post");
        blog.Url = "https://devblogs.microsoft.com/dotnet";
        blog.Posts.Add(new Post {Title = "Hello World", Content = "I wrote an app using Entity Framework"});
        db?.SaveChanges();
    }

    public void Delete()
    {
        Console.WriteLine("Delete the blog");
        db?.Remove(blog);
        db?.SaveChanges();
    }
}