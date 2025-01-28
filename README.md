# **RealEstateApp Backend & Frontend**

## **Project Overview**

The RealEstateApp project is a full-stack application consisting of a **.NET 8** backend and a **Next.js** frontend. It provides a platform for managing property data, including fetching, creating, updating, and deleting properties.

---

## **Technologies Used**

### Backend

- **.NET 8**: For building the backend API.
- **MongoDB**: As the database for storing property and owner data.
- **Moq**: For unit testing with mocked dependencies.
- **xUnit**: For running unit tests.
- **Swagger**: For API documentation and testing.
- **FluentAssertions**: For fluent-style assertions in tests.

### Frontend

- **Next.js**: For building the frontend.
- **TypeScript**: For type-safe development.
- **Axios**: For making HTTP requests to the backend.
- **SCSS**: For styling the application.

---

## **Project Structure**

The project uses a clean architecture with the following structure:

```bash
RealEstateApp/
├── RealEstateApp.Api/          # Backend
│   ├── Application/
│   ├── Controllers/
│   ├── appsettings.json
│   └── Program.cs
├── RealEstateApp.Domain/       # Domain Models
│   ├── Models/
│   └── Property.cs
├── RealEstateApp.Infrastructure/ # Infrastructure
│   ├── Context/
│   │   └── ApplicationDbContext.cs
│   ├── PropertyRepository.cs
│   ├── IPropertyRepository.cs
│   └── InfrastructureServiceExtensions.cs
├── RealEstateApp.Tests/        # Backend Tests
│   ├── UnitTests/
│   │   ├── Controllers/
│   │   ├── Repositories/
│   │   └── Services/
│   └── IntegrationTests/
├── RealEstateApp.Frontend/     # Frontend
│   ├── public/
│   │   └── images/             # Static images
│   ├── src/
│   │   ├── components/         # Reusable components
│   │   │   ├── Layout.tsx
│   │   │   └── Navbar.tsx
│   │   ├── pages/              # Pages
│   │   │   ├── api/
│   │   │   │   └── hello.ts
│   │   │   ├── index.tsx
│   │   │   ├── _app.tsx
│   │   │   ├── _document.tsx
│   │   │   └── properties/
│   │   │       ├── index.tsx
│   │   │       └── [id].tsx
│   │   ├── styles/             # Styles
│   │   │   ├── globals.scss
│   │   │   └── Home.module.scss
│   │   ├── utils/              # Utilities
│   │   │   └── apiClient.ts
│   │   └── types/              # TypeScript types
│   │       └── Property.ts
│   ├── .env.local              # Environment variables
│   ├── next.config.js          # Next.js configuration
│   ├── package.json            # Project dependencies
│   ├── tsconfig.json           # TypeScript configuration
│   └── README.md               # Frontend README
└── RealEstateApp.sln           # Solution file
```

---

## **Setup Guide**

### **1. Prerequisites**

Before setting up the project, ensure you have the following installed:

- .NET 8 SDK ([Download here](https://dotnet.microsoft.com/))
- MongoDB ([Download here](https://www.mongodb.com/try/download/community))
- Node.js and npm ([Download here](https://nodejs.org/))
- Visual Studio or VS Code (for development)

### **2. Clone the Repository**

Clone the project to your local machine:

```bash
git clone <https://github.com/Skpow1234/MillionAssestment>
cd RealEstateApp
```

### **3. Backend Setup**

#### Restore Dependencies

Navigate to the root directory of the solution and run:

```bash
dotnet restore
```

#### Set Up MongoDB

1. **Start MongoDB**:
   Ensure your MongoDB instance is running. You can use the default connection string: `mongodb://localhost:27017`.

2. **Create a Database**:
   Open the MongoDB shell or any GUI (like MongoDB Compass) and create a database named `RealEstateApp`.

3. **Collections**:
   Inside the database, create the following collections:
   - `Properties`
   - `Owners`

#### Update `appsettings.json`

Update the `appsettings.json` file in the **RealEstateApp.Api** project to include your MongoDB connection details:

```json
{
  "ConnectionStrings": {
    "MongoDB": "mongodb://localhost:27017"
  },
  "DatabaseName": "RealEstateApp"
}
```

#### Build and Run the Project

Build the solution to ensure there are no errors:

```bash
dotnet build
```

Start the API by navigating to the **RealEstateApp.Api** folder and running:

```bash
dotnet run
```

By default, the API will be available at `https://localhost:5001`.

### **4. Frontend Setup**

#### Create and Navigate to the Frontend Directory

Navigate to the `RealEstateApp` directory and create the frontend project:

```bash
npx create-next-app@latest realestateapp-frontend --typescript
cd realestateapp-frontend
```

#### Install Additional Dependencies

Install the required dependencies:

```bash
npm install axios sass
```

#### Update Environment Variables

Create a `.env.local` file in the frontend directory and add:

```env
NEXT_PUBLIC_API_URL=http://localhost:5000/api
```

#### Run the Frontend

Start the development server:

```bash
npm run dev
```

The application will be available at `http://localhost:3000`.

---

## **Frontend Features**

- **Reusable Components**:
  - `Layout` and `Navbar` for consistent UI structure.
- **Pages**:
  - Home (`/`): Displays the welcome page.
  - Properties List (`/properties`): Fetches and displays all properties.
  - Property Details (`/properties/[id]`): Displays details for a specific property.
- **Axios API Client**:
  - Pre-configured client for interacting with the backend.

---

## **Testing the Application**

### **1. Backend Unit Tests**

Navigate to the **RealEstateApp.Tests** folder and execute:

```bash
dotnet test
```

### **2. Frontend Testing**

- **Basic Tests**:
  - Verify API calls in the browser console.
  - Test page navigation (`/`, `/properties`, `/properties/[id]`).

---

## **Available Endpoints**

### Backend API Endpoints

- **GET** `/api/properties`: Fetch all properties with optional filters.
- **GET** `/api/properties/{id}`: Fetch a property by its ID.
- **POST** `/api/properties`: Create a new property.
- **PUT** `/api/properties/{id}`: Update an existing property.
- **DELETE** `/api/properties/{id}`: Delete a property.

---

## **Contributing**

1. Fork the repository.
2. Create a feature branch: `git checkout -b feature-name`.
3. Commit your changes: `git commit -m "Add some feature"`.
4. Push to the branch: `git push origin feature-name`.
5. Open a pull request.
