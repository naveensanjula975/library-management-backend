using System.ComponentModel.DataAnnotations;

namespace backend.DTOs;

// DTO used when creating a new Book via POST /api/books
public class BookCreateDto
{
    [Required, MaxLength(100)]
    public string Title { get; set; } = string.Empty;

    [Required, MaxLength(50)]
    public string Author { get; set; } = string.Empty;

    // Optional short description of the book.
    [MaxLength(500)]
    public string? Description { get; set; }

    [Range(1000, 2500)]
    public int PublishedYear { get; set; }
}
