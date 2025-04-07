# HealthApp – ASP.NET Core Full Stack App

This is a health-focused web application developed as part of a final academic project. It demonstrates a layered architecture using ASP.NET Core, Entity Framework Core, and Razor Pages, applying clean code principles and real-world practices for web app development.

## Tech Stack  
- .NET 8.0  
- ASP.NET Core Razor Pages  
- Entity Framework Core  
- Microsoft Identity (Authentication & Authorization)  
- SQL Server (LocalDB)  
- Bogus – For generating fake test data  
- User Secrets – For storing local sensitive data securely  

## Project Structure  
```
HealthApp  
│  
├── HealthApp.API              # Entry point for APIs (In progress)  
├── HealthApp.Razor            # Main front-end with Razor Pages  
├── HealthApp.Domain           # Core domain models and business rules  
├── HealthApp.Test             # Unit tests project  
```  

## Features Implemented  
- User registration with Identity (Doctors and Patients)  
- Role-based registration form (UserType dropdown)  
- Clean separation of architecture using Domain, Infrastructure, and UI  
- Connected database using EF Core and migrations  
- Basic test structure ready with xUnit  
- Secure local configuration using User Secrets  
- Razor Pages-based UI and role logic in progress  

## Known Issues  
- Registration currently requires “Specialization” for all users (UI/validation bug)  
- Logic separation between Doctors and Patients is incomplete  
- Not all controller endpoints and services are wired in yet  
- Doctor-specific functionality and data not fully implemented  

## How to Run  
```bash  
dotnet restore  
dotnet build  
dotnet run --project HealthApp.Razor  
```  
Make sure SQL Server LocalDB is running and that your connection string is set in appsettings.json or User Secrets.

To initialize secrets:  
```bash  
dotnet user-secrets init  
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "YourConnectionStringHere"  
```  

To apply migrations:  
```bash  
dotnet ef migrations add InitialCreate --project HealthApp.Infrastructure  
dotnet ef database update --project HealthApp.Infrastructure  
```  

## Preview  
![Registration Screenshot](./preview.png)  

## Notes  
- The code follows Clean Architecture to enable scalability and maintainability.  
- Domain layer is pure and only contains business rules and interfaces.  
- Infrastructure handles persistence logic with EF Core.  
- Razor handles user interactions and Identity authentication logic.  
- API layer is scaffolded and intended for future use with Angular/React or mobile apps.


