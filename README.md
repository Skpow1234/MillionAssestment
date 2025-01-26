# **RealEstateApp Backend**

## **Project Overview**

The RealEstateApp backend is a RESTful API built using **.NET 8**, **MongoDB**, and follows a **clean architecture** approach. It provides endpoints for managing property data, such as fetching, creating, updating, and deleting properties.

---

## **Technologies Used**

- **.NET 8**: For building the backend API.
- **MongoDB**: As the database for storing property and owner data.
- **Moq**: For unit testing with mocked dependencies.
- **xUnit**: For running unit tests.
- **Swagger**: For API documentation and testing.
- **FluentAssertions**: For fluent-style assertions in tests.

---

## **Project Structure**

The project uses a clean architecture with the following structure:

```bash
RealEstateApp/
├── RealEstateApp.Api/
│   ├── Application/
│   ├── Controllers/
│   ├── appsettings.json
│   └── Program.cs
├── RealEstateApp.Domain/
│   ├── Models/
│   └── Property.cs
├── RealEstateApp.Infrastructure/
│   ├── Context/
│   │   └── ApplicationDbContext.cs
│   ├── PropertyRepository.cs
│   ├── IPropertyRepository.cs
│   └── InfrastructureServiceExtensions.cs
├── RealEstateApp.Tests/
│   ├── UnitTests/
│   │   ├── Controllers/
│   │   ├── Repositories/
│   │   └── Services/
│   └── IntegrationTests/
├── RealEstateApp.sln
```

---

## **Setup Guide**

### **1. Prerequisites**

Before setting up the project, ensure you have the following installed:

- .NET 8 SDK ([Download here](https://dotnet.microsoft.com/))
- MongoDB ([Download here](https://www.mongodb.com/try/download/community))
- Visual Studio or VS Code (for development)

### **2. Clone the Repository**

Clone the project to your local machine:

```bash
git clone <https://github.com/Skpow1234/MillionAssestment>
cd RealEstateApp
```

### **3. Restore Dependencies**

Navigate to the root directory of the solution and run:

```bash
dotnet restore
```

This will restore all NuGet packages for the solution.

### **4. Set Up MongoDB**

1. **Start MongoDB**:
   Ensure your MongoDB instance is running. You can use the default connection string: `mongodb://localhost:27017`.

2. **Create a Database**:
   Open the MongoDB shell or any GUI (like MongoDB Compass) and create a database named `RealEstateApp`.

3. **Collections**:
   Inside the database, create the following collections:
   - `Properties`
   - `Owners`

### **5. Update `appsettings.json`**

Update the `appsettings.json` file in the **RealEstateApp.Api** project to include your MongoDB connection details:

```json
{
  "ConnectionStrings": {
    "MongoDB": "mongodb://localhost:27017"
  },
  "DatabaseName": "RealEstateApp"
}
```

### **6. Build the Project**

Build the solution to ensure there are no errors:

```bash
dotnet build
```

### **7. Run the Project**

Start the API by navigating to the **RealEstateApp.Api** folder and running:

```bash
dotnet run
```

By default, the API will be available at `https://localhost:5001`.

### **8. Test the API with Swagger**

Swagger is pre-configured and accessible at:

```bash
https://localhost:5001/swagger
```

You can use Swagger to test the endpoints and see the API documentation.

---

## **Available Endpoints**

- **GET** `/api/properties`: Fetch all properties with optional filters.
  - **Query Parameters**:
    - `name`: Filter by property name.
    - `address`: Filter by property address.
    - `minPrice`: Filter by minimum price.
    - `maxPrice`: Filter by maximum price.
- **GET** `/api/properties/{id}`: Fetch a property by its ID.
- **POST** `/api/properties`: Create a new property.
- **PUT** `/api/properties/{id}`: Update an existing property.
- **DELETE** `/api/properties/{id}`: Delete a property.

---

## **Testing the Application**

### **1. Run Unit Tests**

Navigate to the **RealEstateApp.Tests** folder and execute:

```bash
dotnet test
```

This will run all unit and integration tests.

### **2. Code Coverage**

For code coverage, use the `coverlet.collector` package by adding the following option to the test command:

```bash
dotnet test --collect:"XPlat Code Coverage"
```

---

## **Key Features**

1. **Clean Architecture**:
   - Separation of concerns with **Api**, **Domain**, and **Infrastructure** layers.
2. **MongoDB Integration**:
   - CRUD operations using `MongoDB.Driver`.
3. **Unit and Integration Tests**:
   - Comprehensive testing with `xUnit`, `Moq`, and `FluentAssertions`.
4. **Swagger Integration**:
   - Built-in API documentation for easy testing and integration.

---

## **Contributing**

1. Fork the repository.
2. Create a feature branch: `git checkout -b feature-name`.
3. Commit your changes: `git commit -m "Add some feature"`.
4. Push to the branch: `git push origin feature-name`.
5. Open a pull request.

---
