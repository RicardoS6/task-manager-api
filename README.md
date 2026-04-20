# Task Manager API

A RESTful Task Management API built with ASP.NET Core, featuring JWT authentication and user-based authorization.

## 🚀 Features

- User registration and login with JWT authentication
- Secure endpoints using `[Authorize]`
- Each user can only access their own tasks
- Full CRUD operations for tasks
- Data validation using DTOs and Data Annotations
- Entity Framework Core with SQLite
- Tested using Swagger UI

## 🛠 Tech Stack

- ASP.NET Core Web API
- C#
- Entity Framework Core
- SQLite
- JWT Authentication
- Swagger (OpenAPI)

## 📦 API Endpoints

### Auth
- `POST /api/Auth/register`
- `POST /api/Auth/login`

### Tasks (Protected)
- `GET /api/Tasks`
- `POST /api/Tasks`
- `PUT /api/Tasks/{id}`
- `DELETE /api/Tasks/{id}`

## 🔐 Authentication

After login, copy the JWT token and use it in Swagger:
Authorization: Bearer <your_token>


## 🧪 Example Request (Create Task)

```json
{
  "title": "My task",
  "description": "Testing API",
  "status": "ToDo",
  "dueDate": "2026-04-20T16:00:00Z"
}
```
asdasd

Running the Project:
 dotnet run

Then Open
 http://localhost:5063/swagger

