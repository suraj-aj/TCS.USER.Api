# TCS.USER.Api

A comprehensive User Management REST API built with .NET 10, following Clean Architecture principles.

## Project Overview

TCS.USER.Api is a robust user management system that provides endpoints for creating, reading, updating, and deleting user information. The API is built using modern .NET technologies and follows industry best practices.

## Prerequisites

- .NET 10 SDK or later
- SQL Server (or SQL Server Express)
- Visual Studio 2026 Community or later (or any code editor)
- Git

## Project Structure

```
TCS.USER.Api/
├── Domain/              # Domain layer - Core business logic and entities
├── Application/         # Application layer - DTOs, business logic, and services
├── Infrastructure/      # Infrastructure layer - Data access and external services
├── WebApi/              # Presentation layer - API controllers and endpoints
└── README.md
```

## Technology Stack

- **Framework**: .NET 10
- **ORM**: Entity Framework Core 10.0.8
- **Database**: SQL Server
- **Authentication**: JWT Bearer (System.IdentityModel.Tokens.Jwt 8.18.0)
- **API Documentation**: Swagger/Swashbuckle 10.1.7
- **Authentication Package**: Microsoft.AspNetCore.Authentication.JwtBearer 10.0.8

## Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/suraj-aj/TCS.USER.Api.git
cd TCS.USER.Api
```

### 2. Install Dependencies

```bash
dotnet restore
```

### 3. Configure Database

Update the connection string in `appsettings.json`:

```json
{
  "ConnectionStrings": {
	"DefaultConnection": "Server=YOUR_SERVER;Database=TCS_USER_DB;Trusted_Connection=true;"
  }
}
```

### 4. Create Database

```bash
dotnet ef database update --project Infrastructure
```

### 5. Build the Project

```bash
dotnet build
```

### 6. Run the Application

```bash
cd WebApi
dotnet run
```

The API will be available at `https://localhost:5001` (or `http://localhost:5000`)

## API Documentation

Swagger UI is available at:
- `https://localhost:5001/swagger/index.html`
- `http://localhost:5000/swagger/index.html`

## Key Features

- ✅ User CRUD operations (Create, Read, Update, Delete)
- ✅ JWT-based authentication
- ✅ Comprehensive data validation
- ✅ Entity Framework Core with SQL Server
- ✅ API documentation with Swagger
- ✅ Clean Architecture implementation
- ✅ .NET 10 with latest frameworks

## API Endpoints

### Users

- **GET** `/api/users` - Get all users
- **GET** `/api/users/{id}` - Get user by ID
- **POST** `/api/users` - Create new user
- **PUT** `/api/users/{id}` - Update user
- **DELETE** `/api/users/{id}` - Delete user

### Sample Request

```bash
# Create a new user
curl -X POST https://localhost:5001/api/users \
  -H "Content-Type: application/json" \
  -d '{
	"name": "John Doe",
	"age": 30,
	"city": "New York",
	"state": "NY",
	"pincode": "10001",
	"email": "john@example.com"
  }'
```

## Project Layers

### Domain Layer
Contains core business entities and interfaces. No external dependencies.

### Application Layer
Contains DTOs, business logic, and application services. Depends only on the Domain layer.

### Infrastructure Layer
Contains data access logic, Entity Framework Core configurations, and repository implementations.

### WebApi Layer
Contains API controllers and endpoints. Orchestrates the application flow.

## Contributing

1. Create a feature branch (`git checkout -b feature/amazing-feature`)
2. Commit your changes (`git commit -m 'Add amazing feature'`)
3. Push to the branch (`git push origin feature/amazing-feature`)
4. Open a Pull Request

## License

This project is licensed under the MIT License - see the LICENSE file for details.

## Support

For issues or questions, please create an issue in the GitHub repository.

## Author

Suraj AJ

---

**Last Updated**: 2024
