# Training Management API

A RESTful ASP.NET Core Web API for managing training programs, trainers, and participants.

## Features

### This API supports:

- Creating, updating, deleting training programs
- Assigning trainers and participants
- Viewing training details including trainer and participant list

- CRUD operations for Training Programs, Trainers, and Participants
- Entity relationships: Trainers lead Training Programs; Participants enroll in Training Programs
- Data validation and error handling
- AutoMapper for DTO mapping
- Swagger/OpenAPI documentation (check the docs directory)

## Project Structure & Tech

- `Controllers/` — API HTTP endpoints
- `Models/` — Entity data definitions
- `DTOs/` — Data Transfer Objects
- `Repositories/` — Data access layer using EFCore SQL Server
- `Services/` — Business logic
- `Mappings/` — AutoMapper profiles
- `Data/` — EF Core DbContext
- `Migrations/` — Database migrations

### Architecture Principles

- Clean separation via Controller → Service → Repository layers
- Dependency Injection for all services and repositories
- AutoMapper for DTO projection
- Async/await for all EF Core operations
- Validation via Data Annotations (`[Required]`, `[EmailAddress]`, etc.)


### This project uses the following technologies:

- ASP.NET Core 8.0 — Web API framework
- Entity Framework Core — ORM for data access
- AutoMapper — Object-to-object mapping
- Swagger/OpenAPI — API documentation
- SQL Server — Database backend
- etc.

## Getting Started

### Adding SQL Server Variables
Use Visual Studio’s `launchSettings.json` to set environment variables for local development.

1. Open `Properties/launchSettings.json`

2. Add under your profile update the connectionStrings with your SQL Server connection string:
   ```json
   "environmentVariables": {
     "ConnectionStrings__DefaultConnection": "Server=...;Database=TraningManagementDB;User Id=...;Password=...;TrustServerCertificate=True;"
   }
   ```

3. In `Program.cs`:
   ```csharp
   builder.Configuration.AddEnvironmentVariables();
   ```

4. Leave `appsettings.json` blank:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": ""
   }
   ```

### Apply Database Migration
1. **Create Migration InitialDB**
   `Add-Migration InitialDB` for VS Package Manager Console

2. **Run Migrations**  
    `dotnet ef database update` or `Update-Database` for VS

3. **Start the API**  
    `dotnet run`

4. **Export SQL Script**
   - `Script-Migration -Output dbsetup.sql` for VS
   - the generated sql script is in the docs directory

4. **Explore Endpoints**  
   Visit `/swagger` for API documentation.
   - swagger documentation json is in docs directory


