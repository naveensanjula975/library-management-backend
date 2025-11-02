using System.ComponentModel.DataAnnotations;

namespace backend.DTOs;

// DTO used to update an existing Book via PUT /api/books/{id}
public class BookUpdateDto
{
    [Required, MaxLength(100)]
    public string Title { get; set; } = string.Empty;

    [Required, MaxLength(50)]
    public string Author { get; set; } = string.Empty;

    // Optional updated description of the book.
    [MaxLength(500)]
    public string? Description { get; set; }

    [Range(1000, 2500)]
    public int PublishedYear { get; set; }
}
