using backend.Data; // DbContext
using backend.Models; // User model
using Microsoft.EntityFrameworkCore; // ToListAsync, FirstOrDefaultAsync, Add, SaveChangesAsync

namespace backend.Services;

// Service using EF Core to manage user authentication
public class AuthService : IAuthService
{
    private readonly LibraryContext _db; // injected DbContext
    
    // Constructor: receives the DbContext from the DI container
    public AuthService(LibraryContext db) => _db = db;

    // Register a new user with hashed password
    public async Task<User?> RegisterAsync(string name, string email, string password)
    {
        // Check if email already exists
        if (await EmailExistsAsync(email))
            return null;

        // Create new user with hashed password
        var user = new User
        {
            Name = name,
            Email = email.ToLower(), // normalize email to lowercase
            PasswordHash = HashPassword(password),
            CreatedAt = DateTime.UtcNow
        };

        _db.Users.Add(user); // add
        await _db.SaveChangesAsync(); // save
        return user; // return created user
    }

    // Login user by verifying email and password
    public async Task<User?> LoginAsync(string email, string password)
    {
        // Find user by email (case-insensitive)
        var user = await _db.Users
            .FirstOrDefaultAsync(u => u.Email == email.ToLower());

        // Return null if user not found or password doesn't match
        if (user == null || !VerifyPassword(password, user.PasswordHash))
            return null;

        return user; // return authenticated user
    }

    // Check if email already exists in database
    public async Task<bool> EmailExistsAsync(string email)
    {
        return await _db.Users.AnyAsync(u => u.Email == email.ToLower());
    }

    // Hash password using BCrypt
    public string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    // Verify password against stored hash using BCrypt
    public bool VerifyPassword(string password, string passwordHash)
    {
        return BCrypt.Net.BCrypt.Verify(password, passwordHash);
    }
}
