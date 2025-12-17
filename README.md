# Auth & User Management API

This project is a backend REST API built with ASP.NET Core, designed specifically as a **portfolio project for junior backend / LIA roles**.  
It demonstrates real-world backend fundamentals such as authentication flows, layered architecture, and database persistence.

## Overview
The API provides user registration, authentication using JWT, and protected endpoints backed by a SQL database.  
There is no frontend by design — the focus is entirely on backend architecture, security, and responsibility separation.

## Key Features
- User registration with hashed passwords  
- User login with JWT token generation  
- Protected endpoint using JWT authorization  
- SQL database persistence with Entity Framework Core  
- Clean architecture using Controller → Service → Repository pattern  
- Dependency Injection throughout the application  

## Technology Stack
- ASP.NET Core Web API  
- Entity Framework Core  
- SQLite / SQL Server  
- JWT (JSON Web Tokens)  
- Dependency Injection  

## Architecture
The project follows a layered backend architecture:
- **Controllers** handle HTTP requests and responses  
- **Services** contain business logic and authentication flow  
- **Repositories** handle data access and persistence  
- **DTOs** are used for input and output validation  

This structure reflects how production-level backend systems are commonly built.

## API Endpoints
| Method | Endpoint              | Description |
|------|----------------------|------------|
| POST | `/api/auth/register` | Register a new user |
| POST | `/api/auth/login`    | Authenticate user and return JWT |
| GET  | `/api/auth/me`       | Get current authenticated user (protected) |

## Example Requests

### Register
```json
POST /api/auth/register
Content-Type: application/json

{
  "username": "meg",
  "email": "meg@example.com",
  "password": "Test123!"
}

```
### Login
```json
POST /api/auth/login
Content-Type: application/json

{
  "email": "meg@example.com",
  "password": "Test123!"
}

```
### Login Response
```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
}

```

### Purpose

- This project was built to demonstrate:
- Backend system structure and responsibility separation
- Authentication and authorization using JWT
- Secure handling of user credentials
- Database integration using Entity Framework Core
It is intended as a portfolio project for junior backend developer and LIA applications.

### Next Steps

- Add refresh tokens
- Implement role-based authorization
- Add unit tests
- Add Swagger documentation
