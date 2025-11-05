using System.ComponentModel.DataAnnotations;

namespace backend.DTOs;

// DTO used when logging in via POST /api/auth/login
public class UserLoginDto
{
    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;
}
