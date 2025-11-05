namespace backend.DTOs;

// DTO returned by the API for GET requests for Books
public class BookReadDto
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Author { get; set; } = string.Empty;

    // Optional description
    public string? Description { get; set; }

    public int PublishedYear { get; set; }
}
