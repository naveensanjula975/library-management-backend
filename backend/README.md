# Library Management API

[![.NET 9.0](https://img.shields.io/badge/.NET-9.0-512BD4?logo=dotnet)](https://dotnet.microsoft.com/) [![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](LICENSE)

> Production-ready RESTful API for library management with user authentication.

## 🚀 Quick Start

```bash
cd backend
dotnet restore
dotnet ef database update
dotnet run
```

**Open:** http://localhost:5119/swagger

## 📦 What's Inside

- ✅ Book CRUD operations (Create, Read, Update, Delete)
- ✅ User authentication (Register, Login with BCrypt)
- ✅ SQLite database with Entity Framework Core
- ✅ Auto-generated Swagger documentation
- ✅ Input validation & error handling
- ✅ Async/await for scalability

## 🛠️ Tech Stack

**Backend:** ASP.NET Core 9.0 | **Database:** SQLite | **ORM:** EF Core 9.0.10 | **Security:** BCrypt

## 📡 API Endpoints

### Books
- `GET /api/books` - List all books
- `GET /api/books/{id}` - Get book by ID
- `POST /api/books` - Create new book
- `PUT /api/books/{id}` - Update book
- `DELETE /api/books/{id}` - Delete book

### Auth
- `POST /api/auth/register` - Register user
- `POST /api/auth/login` - Login user

## 🏗️ Project Structure

```
Controllers/  → HTTP endpoints
Services/     → Business logic
Data/         → Database context
Models/       → Domain entities
DTOs/         → API contracts
```

## 🔧 Setup

**Prerequisites:** [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)

**First-time setup (EF Tools):**
```bash
dotnet tool install --global dotnet-ef
```

**Environment:**
```json
// appsettings.json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=library.db"
  }
}
```

## 🧪 Testing

**Swagger UI:** http://localhost:5119/swagger  
**HTTP File:** Open `backend.http` in VS Code with REST Client extension

## 📚 Example Request

```http
POST http://localhost:5119/api/books
Content-Type: application/json

{
  "title": "Clean Code",
  "author": "Robert C. Martin",
  "publishedYear": 2008
}
```

## 🗄️ Database

**Create migration:**
```bash
dotnet ef migrations add MigrationName
```

**Reset database:**
```bash
del library.db && dotnet ef database update
```

## 🔒 Security

- BCrypt password hashing (never store plain text)
- Email validation & uniqueness checks
- Input validation with Data Annotations
- CORS enabled for `http://localhost:5173`
