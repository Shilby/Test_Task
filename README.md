# Candidate Hub API

## Overview
This project is a web application that provides a REST API for storing and updating information about job candidates. The application is built using the .NET stack and adheres to best practices for maintainability and scalability.

## Features
- Add or update candidate information using a single API endpoint.
- Email is used as the unique identifier for candidates.
- Supports required fields: FirstName, LastName, Email, Comments.
- Caching mechanism to improve performance.
- Proper error handling and logging.

## Assumptions
- The application currently uses an SQL Server for data storage.
- The application should be self-deploying and run out-of-the-box with Visual Studio.
- The storage mechanism may change in the future, so the data access layer is abstracted.

## Improvements
- Implement a more advanced caching mechanism for frequently accessed data.
- Add more comprehensive unit tests.
- Implement validation for URLs (LinkedInUrl, GitHubUrl).
- Enhance logging with a centralized logging service.
- Extend the application to handle bulk insert/update operations.

## Running the Project
1. Clone the repository.
2. Open the solution in Visual Studio.
3. Ensure that the SQL Server connection string in `appsettings.json` is correct.
4. Build and run the application.

## Testing
Unit tests are included in the `Test_Task.Tests` project. To run the tests:
1. Open the Test Explorer in Visual Studio.
2. Run all tests to ensure they pass.

## Time Spent
- Development: 2 hour
- Testing: 0.5 hour
- Documentation: 0.5 hour
