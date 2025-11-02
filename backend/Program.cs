using backend.Data; // DbContext and data models
using backend.Services; // Service interfaces and implementations
using Microsoft.EntityFrameworkCore; // EF Core for DbContext configuration

var builder = WebApplication.CreateBuilder(args); // create app builder / host

// Add services to the container.
builder.Services.AddControllers(); // register MVC controllers
builder.Services.AddEndpointsApiExplorer(); // enable minimal API explorer for swagger
builder.Services.AddSwaggerGen(); // add swagger generation

// Configure EF Core with SQLite using connection string from config
builder.Services.AddDbContext<LibraryContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Service layer registration (inject IBookService with BookService implementation)
builder.Services.AddScoped<IBookService, BookService>();

// CORS (allow Vite dev server by default)
builder.Services.AddCors(options =>
{
    options.AddPolicy("dev", policy =>
        policy.WithOrigins("http://localhost:5173") // allow local frontend dev server
              .AllowAnyHeader()
              .AllowAnyMethod());
});

var app = builder.Build(); // build the app

// Configure the HTTP request pipeline.
app.UseSwagger(); // enable middleware that generates swagger.json
app.UseSwaggerUI(); // enable swagger UI at /swagger

app.UseHttpsRedirection(); // HTTP to HTTPS
app.UseCors("dev"); // apply the named CORS policy
app.MapControllers(); // map controller routes to endpoints

app.Run();
