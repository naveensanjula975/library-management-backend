namespace backend.DTOs;

// DTO returned after successful login containing user info and token placeholder
public class AuthResponseDto
{
    public UserReadDto User { get; set; } = null!;
    
    public string Message { get; set; } = string.Empty;
}
