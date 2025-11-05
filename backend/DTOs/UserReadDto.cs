namespace backend.DTOs;

// DTO returned by the API for authentication responses
public class UserReadDto
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }
}
