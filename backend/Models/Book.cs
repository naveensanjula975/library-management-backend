using System.ComponentModel.DataAnnotations;

namespace backend.Models;

public class Book
{
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string Title { get; set; } = string.Empty;

    [Required, MaxLength(50)]
    public string Author { get; set; } = string.Empty;

    [MaxLength(500)]
    public string? Description { get; set; }

    [Range(1000, 2500)]
    public int PublishedYear { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}