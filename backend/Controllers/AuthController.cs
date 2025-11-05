using backend.DTOs; // DTO classes for requests/responses
using backend.Services; // Service layer (IAuthService)
using Microsoft.AspNetCore.Mvc; // ControllerBase and routing attributes

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService; // service for authentication logic

    // Constructor injection of service
    public AuthController(IAuthService authService) => _authService = authService;

    [HttpPost("register")] // POST /api/auth/register
    public async Task<ActionResult<AuthResponseDto>> Register(UserRegisterDto dto)
    {
        // Check if email already exists
        if (await _authService.EmailExistsAsync(dto.Email))
        {
            return BadRequest(new { message = "Email already registered" });
        }

        // Register new user
        var user = await _authService.RegisterAsync(dto.Name, dto.Email, dto.Password);

        if (user == null)
        {
            return BadRequest(new { message = "Registration failed" });
        }

        // Return success response with user data
        var response = new AuthResponseDto
        {
            User = ToUserReadDto(user),
            Message = "Registration successful"
        };

        return CreatedAtAction(nameof(Register), new { id = user.Id }, response); // 201
    }

    [HttpPost("login")] // POST /api/auth/login
    public async Task<ActionResult<AuthResponseDto>> Login(UserLoginDto dto)
    {
        // Attempt to login user
        var user = await _authService.LoginAsync(dto.Email, dto.Password);

        if (user == null)
        {
            return Unauthorized(new { message = "Invalid email or password" }); // 401
        }

        // Return success response with user data
        var response = new AuthResponseDto
        {
            User = ToUserReadDto(user),
            Message = "Login successful"
        };

        return Ok(response); // 200
    }

    // Map User entity to UserReadDto
    private static UserReadDto ToUserReadDto(backend.Models.User u) => new()
    {
        Id = u.Id,
        Name = u.Name,
        Email = u.Email,
        CreatedAt = u.CreatedAt
    };
}
