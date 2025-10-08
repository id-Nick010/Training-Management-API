# Training Management API

A RESTful ASP.NET Core Web API for managing training programs, trainers, and participants.

## Features

- CRUD operations for Training Programs, Trainers, and Participants
- Entity relationships: Trainers lead Training Programs; Participants enroll in Training Programs
- Data validation and error handling
- AutoMapper for DTO mapping
- Swagger/OpenAPI documentation

## Project Structure & Tech

- `Controllers/` — API endpoints
- `Models/` — Entity definitions
- `DTOs/` — Data Transfer Objects
- `Repositories/` — Data access layer
- `Services/` — Business logic
- `Mappings/` — AutoMapper profiles
- `Data/` — EF Core DbContext
- `Migrations/` — Database migrations

### This project uses the following technologies:

- ASP.NET Core 8.0 — Web API framework
- Entity Framework Core — ORM for data access
- AutoMapper — Object-to-object mapping
- Swagger/OpenAPI — API documentation
- SQL Server — Database backend
- etc.

## Getting Started

1. **Configure Database**  
   Update `appsettings.json` with your SQL Server connection string.

2. **Run Migrations**  
    `dotnet ef database update` or `Update-Database` for VS

3. **Start the API**  
    `dotnet run`

4. **Explore Endpoints**  
Visit `/swagger` for API documentation.