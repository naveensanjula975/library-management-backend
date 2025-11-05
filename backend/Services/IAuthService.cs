using backend.Models; // User model

namespace backend.Services; // Service layer

// Authentication related operations used by controllers
public interface IAuthService
{
    // Register a new user
    Task<User?> RegisterAsync(string name, string email, string password);

    // Login user and verify credentials
    Task<User?> LoginAsync(string email, string password);

    // Check if email already exists
    Task<bool> EmailExistsAsync(string email);

    // Hash password securely
    string HashPassword(string password);

    // Verify password against hash
    bool VerifyPassword(string password, string passwordHash);
}
