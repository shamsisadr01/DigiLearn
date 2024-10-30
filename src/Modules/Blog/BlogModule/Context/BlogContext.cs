using BlogModule.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogModule.Context;

public class BlogContext : DbContext
{
    public BlogContext(DbContextOptions<BlogContext> options) : base(options)
    {
        
    }

    public DbSet<Post> Posts { get; set; }
    public DbSet<Category> Categories { get; set; }
}