using backend.DTOs; // DTO classes for requests/responses
using backend.Models; // models Book
using backend.Services; // Service layer (IBookService)
using Microsoft.AspNetCore.Mvc; // ControllerBase and routing attributes

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBookService _service; // service for business logic

    // Constructor injection of service
    public BooksController(IBookService service) => _service = service;

    [HttpGet] // GET /api/books
    public async Task<ActionResult<IEnumerable<BookReadDto>>> GetAll()
    {
        var list = (await _service.GetAllAsync()).Select(ToReadDto); // map to DTOs
        return Ok(list); // 200 + list
    }

    [HttpGet("{id:int}")] // GET /api/books/{id}
    public async Task<ActionResult<BookReadDto>> GetById(int id)
    {
        var book = await _service.GetByIdAsync(id); // find by id
        return book is null ? NotFound() : Ok(ToReadDto(book)); // 404 or 200
    }

    [HttpPost] // POST /api/books
    public async Task<ActionResult<BookReadDto>> Create(BookCreateDto dto)
    {
        // build entity from DTO
        var book = new Book
        {
            Title = dto.Title,
            Author = dto.Author,
            Description = dto.Description,
            PublishedYear = dto.PublishedYear
        };

        await _service.CreateAsync(book); // persist
        return CreatedAtAction(nameof(GetById), new { id = book.Id }, ToReadDto(book)); // 201
    }

    [HttpPut("{id:int}")] // PUT /api/books/{id}
    public async Task<ActionResult> Update(int id, BookUpdateDto dto)
    {
        var book = await _service.GetByIdAsync(id); // fetch entity
        if (book is null) return NotFound(); // 404 if missing

        // apply updates
        book.Title = dto.Title;
        book.Author = dto.Author;
        book.Description = dto.Description;
        book.PublishedYear = dto.PublishedYear;

        await _service.SaveChangesAsync();
        return NoContent(); // 204
    }

    [HttpDelete("{id:int}")] // DELETE /api/books/{id}
    public async Task<ActionResult> Delete(int id)
    {
        var ok = await _service.DeleteAsync(id); // attempt delete
        return ok ? NoContent() : NotFound(); // 204 or 404
    }

    // Map Book entity to BookReadDto
    private static BookReadDto ToReadDto(Book b) => new()
    {
        Id = b.Id,
        Title = b.Title,
        Author = b.Author,
        Description = b.Description,
        PublishedYear = b.PublishedYear
    };
}
