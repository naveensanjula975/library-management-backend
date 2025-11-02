using backend.Models; // Book model

namespace backend.Services; // Service layer

// Book related operations used by controllers
public interface IBookService
{
    // Get all books
    Task<IEnumerable<Book>> GetAllAsync();

    // Get book by id
    Task<Book?> GetByIdAsync(int id);

    // Create a book
    Task<Book> CreateAsync(Book book);

    // Delete a book by id
    Task<bool> DeleteAsync(int id);

    // Save changes
    Task SaveChangesAsync();
}
