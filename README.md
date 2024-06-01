# Candidate Hub API

## Overview
Candidate Hub API is a .NET-based web application providing a REST API for storing and updating job candidate information. This application is designed with scalability and maintainability in mind, enabling easy extension and potential migration to different storage backends in the future.

## Architecture
The application follows a layered architecture with clear separation of concerns:
- **Controllers**: Handle incoming HTTP requests and return responses.
- **Services**: Contain business logic and interact with repositories.
- **Repositories**: Handle data access and interact with the database.
- **DTOs (Data Transfer Objects)**: Used to transfer data between layers.
- **Models**: Represent the data structure stored in the database.
- **Dependency Injection**: Configured to inject services and repositories.

### Project Structure API
├── Controllers
│ └── CandidateController.cs
├── Data
│ └── CandidateContext.cs
├── DI
│ ├── RepositoryInjection.cs
│ └── ServiceInjection.cs
├── DTOs
│ ├── CandidateDto.cs
│ └── CandidateResponseDto.cs
├── Models
│ └── Candidate.cs
├── Repository
│ ├── CandidateRepository.cs
│ └── ICandidateRepository.cs
├── Services
│ ├── CandidateService.cs
│ └── ICandidateService.cs
├── Program.cs
├── appsettings.json
└── README.md

## Features
- Add or update candidate information using a single API endpoint.
- Uses email as the unique identifier for candidates.
- Enforces required fields: `FirstName`, `LastName`, `Email`, `Comments`.
- Implements caching to improve performance.
- Provides proper error handling and logging mechanisms.
- Designed to be easily extendable and maintainable.

## Prerequisites
- .NET 7.0 SDK
- SQL Server

## Setup Instructions
1. **Clone the repository**:
    ```sh
    git clone 
    cd 
    ```

2. **Configure the database connection**:
    - Update the connection string in `appsettings.json`:
      ```json
      {
          "ConnectionStrings": {
              "DefaultConnection": "Your-SQL-Server-Connection-String"
          }
      }
      ```

3. **Build and run the application**:
    ```sh
    dotnet build
    dotnet run
    ```

4. **Access the Swagger UI**:
    - Open your browser and navigate to `https://localhost:5001/swagger` to explore the API endpoints.

## Usage
- **Add or Update Candidate**:
    - POST `/Candidate`
    - Body:
      ```json
      {
          "firstName": "John",
          "lastName": "Doe",
          "phoneNumber": "123-456-7890",
          "email": "john.doe@example.com",
          "preferredCallTime": "10:00 AM - 11:00 AM",
          "linkedInUrl": "https://linkedin.com/in/johndoe",
          "gitHubUrl": "https://github.com/johndoe",
          "comments": "Available for immediate start"
      }
      ```

## Testing
- **Unit Tests**:
    - The project includes unit tests for services and controllers.
    - To run the tests:
      ```sh
      dotnet test
      ```

## Assumptions
- The application currently uses an SQL Server for data storage.
- It should be self-deploying and run out-of-the-box with Visual Studio.
- The storage mechanism may change in the future, so the data access layer is abstracted.

## Improvements
- Implement a more advanced caching mechanism for frequently accessed data.
- Add more comprehensive unit tests.
- Implement validation for URLs (LinkedInUrl, GitHubUrl).
- Enhance logging with a centralized logging service.
- Extend the application to handle bulk insert/update operations.
- Implement integration tests for end-to-end functionality verification.

## Total Time Spent
- Development: 2 hours
- Testing: 1 hour
- Documentation: 1 hour

## License
This project is licensed under the MIT License.

## Contact
For any inquiries, please contact [Your Name](mailto:your.email@example.com).

