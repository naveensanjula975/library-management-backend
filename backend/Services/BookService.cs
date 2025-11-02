using backend.Data; // DbContext
using backend.Models; // Book model
using Microsoft.EntityFrameworkCore; // AsNoTracking, ToListAsync, FindAsync, OrderByDescending, Remove, SaveChangesAsync, Add

namespace backend.Services;

// Service using EF Core to manage books
public class BookService : IBookService
{
    private readonly LibraryContext _db; // injected DbContext
    
    // Constructor: receives the DbContext from the DI container
    public BookService(LibraryContext db) => _db = db;

    // Get all books (newest first)
    public async Task<IEnumerable<Book>> GetAllAsync() =>
        await _db.Books.AsNoTracking().OrderByDescending(b => b.Id).ToListAsync();

    // Get a book by id
    public async Task<Book?> GetByIdAsync(int id) =>
        await _db.Books.FindAsync(id);

    // Create and save a new book
    public async Task<Book> CreateAsync(Book book)
    {
        _db.Books.Add(book); // add
        await _db.SaveChangesAsync(); // save
        return book; // return created
    }

    // Delete a book by id
    public async Task<bool> DeleteAsync(int id)
    {
        var book = await _db.Books.FindAsync(id); // find
        if (book is null) return false; // not found
        _db.Books.Remove(book); // remove
        await _db.SaveChangesAsync(); // save
        return true; // deleted
    }

    // Save pending changes
    public async Task SaveChangesAsync() => await _db.SaveChangesAsync();
}
