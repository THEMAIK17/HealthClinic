
# HealthClinic

HealthClinic is a .NET 8 console application designed to manage a veterinary clinic. It allows registering, displaying, updating, and deleting information about customers, pets, veterinarians, and appointments. The application is designed to be simple, functional, and modular, facilitating comprehensive clinic management.

## Features

Register, edit, delete, and search:

- Customers

- Pets

- Veterinarians

- Appointments

- Basic data validation (email format, age, dates, etc.)

- Prevents duplicates in documents, emails, and licenses

- Clear and interactive menus for easy navigation

- Seed data for testing and demonstration purposes

## Technologies

- .NET 8

- C#

- Object-oriented programming

- Repository pattern for data access

- Service layer for business logic

- Console application with interactive menus

## Requirements

- .NET 8.0 SDK or later installed

- Supported operating system for .NET (Windows, macOS, Linux)

## Installation and Running

### Clone the repository:

git clone https://github.com/THEMAIK17/HealthClinic.git


### Navigate to the project folder:

- cd HealthClinic


### Restore dependencies and build the project:

- dotnet restore
- dotnet build


### Run the application:

- dotnet run 

## Usage

Upon starting, you will see a main menu with options to manage:

- Customers

- Pets

- Veterinarians

- Appointments

Each section has its own submenu to register, list, search by ID, update, and delete records.

Data is entered via the console, with validations ensuring data integrity.

## Project Structure

The solution is organized using a layered architecture with separation of concerns. It follows SOLID principles and is easy to maintain or scale.
```
 HealthClinic/
│
├── App.csproj # Project file
├── Program.cs # Entry point (Main menu loop)
│
├── Models/ # Domain entities (data models)
│ ├── Customer.cs
│ ├── Pet.cs
│ ├── Veterinarian.cs
│ └── Appointment.cs
│
├── Interfaces/ # Interface definitions for repositories and services
│ ├── ICustomerRepository.cs
│ ├── IPetRepository.cs
│ ├── IVeterinarianRepository.cs
│ ├── IAppointmentRepository.cs
│ └── ... (additional service interfaces if needed)
│
├── Repositories/ # Data access layer (implements interfaces)
│ ├── CustomerRepository.cs
│ ├── PetRepository.cs
│ ├── VeterinarianRepository.cs
│ ├── AppointmentRepository.cs
│ └── DatabaseContext.cs # In-memory data storage
│
├── Services/ # Business logic layer
│ ├── CustomerService.cs
│ ├── PetService.cs
│ ├── VeterinarianService.cs
│ └── AppointmentService.cs
│
├── Utils/ # Console UI (menus and helpers)
│ ├── ShowMenuCustomer.cs
│ ├── ShowMenuPet.cs
│ ├── ShowMenuVeterinarian.cs
│ └── ShowMenuAppointment.cs
```
### Layer Responsibilities

- **Models**: Define core entities and their properties.  
- **Interfaces**: Declare contracts for repositories and services.  
- **Repositories**: Implement data access logic using the in-memory `DatabaseContext`.  
- **Services**: Contain application logic, validations, and operations.  
- **Utils**: Handle console menus and user interaction.  
- **Program.cs**: Main loop with the application's top-level navigation.

## Future Improvements

- Real database persistence (e.g., SQL Server or SQLite).

- Graphical or web interface for improved user experience.

- Reports and statistics.

- User and role management.

## Author

(maikold774@gmail.com)

## License

This project is licensed under the MIT License. See the LICENSE file for details.