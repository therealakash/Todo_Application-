# Todo Application - C# Web API

A RESTful Todo API built with ASP.NET Core Web API that supports full CRUD operations, search, priority levels, categories, and custom exception handling.

## Tech Stack

- **Backend:** C# .NET 9 Web API
- **Database:** SQL Server with Entity Framework Core 9
- **Documentation:** Swagger / OpenAPI

## Features

- **CRUD Operations** – Create, Read, Update, and Delete todo items
- **Search** – Search todos by keyword (title and description)
- **Priority Levels** – Categorize todos by priority: `low`, `medium`, `high`
- **Categories** – Categorize todos: `work`, `personal` and filter accordingly
- **Exception Handling** – Custom `NotFoundException` with global exception handling middleware
- **CORS** – Configured for React frontend

## Project Structure

```
Todo_assginment/
├── Controllers/
│   └── TodoController.cs
├── Models/
│   ├── Todo.cs
│   ├── categorize.cs
│   └── priority.cs
├── Service/
│   ├── ITodoService.cs
│   └── TodoService.cs
├── Repository/
│   └── Appdbcontext.cs
├── custom_exceptions/
│   └── NotFoundException.cs
├── Middleware/
│   └── ExceptionMiddleware.cs
└── Program.cs
```

## API Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/todo` | Get all todos |
| GET | `/api/todo/{id}` | Get todo by ID |
| POST | `/api/todo` | Create a new todo |
| PUT | `/api/todo/{id}` | Update a todo |
| DELETE | `/api/todo/{id}` | Delete a todo |
| GET | `/api/todo/search?keyword=` | Search todos by keyword |
| GET | `/api/todo/categorize/{categorize}` | Filter by category |
| GET | `/api/todo/priority/{priority}` | Filter by priority |

## Request Body Example

```json
{
  "title": "Complete assignment",
  "description": "Finish the todo API project",
  "categorize": "work",
  "priority": "high"
}
```

## Setup & Run

1. Update connection string in `appsettings.json`
2. Run `dotnet ef database update`
3. Run `dotnet run`
4. Open Swagger: `https://localhost:PORT/swagger`

## Error Handling

| Status Code | Description |
|-------------|-------------|
| 200 | Success |
| 201 | Created |
| 204 | No Content (Update/Delete) |
| 400 | Bad Request (Validation) |
| 404 | Not Found (NotFoundException) |
| 500 | Internal Server Error |