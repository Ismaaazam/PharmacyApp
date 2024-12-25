# Pharmacy Management System

This project is a **Pharmacy Management System** implemented in C#, showcasing basic **Object-Oriented Programming (OOP)** principles. The system allows administrators to manage medicines and users to purchase medicines through a console-based application.

## Features

1. **Admin Functionality**:
   - Add new medicines to the inventory.
   - Remove existing medicines.
   - View the list of available medicines.

2. **User Functionality**:
   - Search and purchase medicines.
   - View purchased medicines and their total cost at checkout.

3. **Authentication System**:
   - Role-based access (Admin/User) with authentication using predefined credentials.

4. **Modular Design**:
   - Encapsulation of logic within classes such as `Medicine`, `Admin`, `User`, and `Login`.
   - Clear separation of concerns for better code maintainability.

5. **Interactive Console Interface**:
   - User-friendly menu system for both Admins and Users.
   - Dynamic redirection and message display for enhanced user experience.

## Object-Oriented Principles Used

1. **Encapsulation**:
   - Data and methods are encapsulated in classes like `Medicine`, `Admin`, `User`, and `Login`.

2. **Inheritance**:
   - While not directly applied here, the system architecture is designed for extensibility.

3. **Modularity**:
   - Each core functionality is encapsulated within its respective class.

4. **Polymorphism**:
   - The `ToString` method in the `Medicine` class is overridden for meaningful output formatting.

## Installation and Usage

### Prerequisites
- .NET Framework installed on your system.
- A C# IDE or text editor like Visual Studio or Visual Studio Code.

### Running the Application
1. Clone or download the repository.
2. Open the project in your preferred IDE.
3. Compile and run the `PharmacySystem` application.
4. Follow the on-screen instructions to use Admin or User functionalities.

### Credentials
- **Admin Credentials**:
  - Username: `admin`
  - Password: `admin123`
- **User Credentials**:
  - Username: `user`
  - Password: `user123`

## Testing

The project includes basic unit testing for a major method:
- Example: Testing the addition of new medicines in the Admin class.

### Running Unit Tests
1. Add a unit test project in your IDE.
2. Write tests for core methods like `AddMedicine`, `Authenticate`, or `PurchaseMedicine`.
3. Execute tests through the test explorer in your IDE.

## Git Version Control

The project demonstrates proper version control practices with at least three commits:
1. **Initial**: Setting up the project structure and creating basic classes.
2. **second commit**: Implementing core functionalities (Admin/User operations, authentication, etc.).
3. **last commit**: Adding testing, documentation, and code cleanup.

## Application Structure

- **Classes**:
  - `Medicine`: Represents a medicine with ID, name, price, and quantity.
  - `Admin`: Provides functionalities to manage medicines.
  - `User`: Allows users to purchase medicines and checkout.
  - `Login`: Handles authentication.
  - `PharmacySystem`: Main entry point for the application.

- **Key Methods**:
  - `AddMedicine`, `RemoveMedicine` (Admin functionalities).
  - `PurchaseMedicine`, `CheckOut` (User functionalities).
  - `Authenticate` (Login).

