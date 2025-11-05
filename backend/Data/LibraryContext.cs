using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Data;

public class LibraryContext : DbContext
{
    public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

    public DbSet<Book> Books => Set<Book>();
    
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Seed data with fixed CreatedAt timestamps
        modelBuilder.Entity<Book>().HasData(
            new Book 
            { 
                Id = 1, 
                Title = "Learn Enough Git to Be Dangerous", 
                Author = "Michael Hartl", 
                Description = "An Introduction to Version Control with Git", 
                PublishedYear = 2016, 
                CreatedAt = new DateTime(2025, 11, 2, 0, 0, 0, DateTimeKind.Utc) 
            },
            new Book 
            { 
                Id = 2, 
                Title = "The Super Programmer", 
                Author = "Keyvan Kambakhsh", 
                Description = "A Colorful Introduction to Engineering!", 
                PublishedYear = 2024, 
                CreatedAt = new DateTime(2025, 11, 2, 0, 0, 0, DateTimeKind.Utc) 
            }
        );
    }
}
