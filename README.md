# EHBBProjectBackend

## About the Project

EHBBProjectBackend is a backend application designed to manage and process data for platforms, lasers, and emitters. It provides RESTful APIs for CRUD operations and integrates with a PostgreSQL database. The project is built using .NET 8.0 and follows a modular architecture.

---

## Technologies Used

- **Framework**: .NET 8.0
- **Language**: C#
- **Database**: PostgreSQL
- **ORM**: Entity Framework Core
- **Validation**: FluentValidation
- **Mapping**: AutoMapper
- **API Documentation**: Swagger
- **Dependency Injection**: Built-in .NET DI

---


## Project Structure

The project follows a modular architecture with the following structure:
- **ProjectBackend.Application**: Contains the API controllers and application-level configurations.
- **ProjectBackend.Business**: Contains business logic, services, and validations.
- **ProjectBackend.Data**: Contains database entities, repositories, and DbContext.
- **ProjectBackend.Contracts**: Contains interfaces for repositories and services.

---

## Architecture Overview

The EHBBProjectBackend follows a clean and modular architecture to ensure scalability, maintainability, and testability. Below are the key architectural highlights:

### Layers
1. **Application Layer**:
   - Contains API controllers to handle HTTP requests and responses.
   - Implements dependency injection to resolve services and validators.
   - Configures middleware such as Swagger for API documentation and CORS policies.

2. **Business Layer**:
   - Contains the core business logic, services, and validation rules.
   - Uses FluentValidation for input validation.
   - Implements AutoMapper for mapping between DTOs and entities.

3. **Data Layer**:
   - Manages database entities, repositories, and the DbContext.
   - Uses Entity Framework Core for database operations.
   - Implements repository patterns for data access abstraction.

4. **Contracts Layer**:
   - Defines interfaces for repositories and services to enforce separation of concerns.
   - Provides a contract for dependency injection and ensures loose coupling.

### Design Patterns
- **Repository Pattern**: Abstracts data access logic and ensures separation of concerns.
- **Dependency Injection**: Promotes testability and modularity by injecting dependencies.
- **DTOs (Data Transfer Objects)**: Used to transfer data between layers, ensuring encapsulation and reducing over-fetching.


## Contact

- **Author**: Bahar Gunes
- **Email**: [bahargns06@gmail.com](mailto:bahargns06@gmail.com)
- **GitHub**: [bahargunes](https://github.com/bahargunes)
