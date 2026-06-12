# Invoice Processing Service

A full-stack invoice processing application built with ASP.NET Core 8, React (Vite), Entity Framework Core, PostgreSQL, JWT Authentication, Serilog, Docker, and GitHub Actions.

The application can run:

* Locally using PostgreSQL
* Using Docker Compose (API + PostgreSQL containers)
* In the cloud using Render and Neon PostgreSQL
* With a React frontend hosted on Render

---

## Tech Stack

* ASP.NET Core 8 Web API
* Entity Framework Core 8
* PostgreSQL
* Serilog
* Swagger / OpenAPI
* Docker
* Docker Compose
* GitHub Actions
* Render
* Neon PostgreSQL
* React (Vite)
* JWT Authentication
* BCrypt Password Hashing
* Bootstrap
* Axios
---

## Features

* Create invoices
* Retrieve all invoices
* Retrieve invoice by ID
* Business validation
* Repository Pattern
* Service Layer Pattern
* Entity Framework Core Code First
* Structured Logging with Serilog
* Dockerized Deployment
* Cloud Deployment on Render
* Continuous Integration with GitHub Actions
* JWT Authentication & Authorization
* BCrypt Password Hashing
* React Frontend
---

## Architecture

```text
React Frontend
      ↓
JWT Authentication
      ↓
ASP.NET Core Web API
      ↓
Service Layer
      ↓
Repository Layer
      ↓
Entity Framework Core
      ↓
PostgreSQL
```

---

## Project Structure

```text
InvoiceProcessingService
├── Controllers
├── Data
├── DTOs
├── Migrations
├── Models
├── Repositories
├── Services
├── frontend
│   ├── src
│   ├── public
│   ├── package.json
│   └── vite.config.js
├── Program.cs
├── Dockerfile
├── docker-compose.yml
├── appsettings.json
└── .github/workflows
```

---

## Run Locally (with PostgreSQL)

### Prerequisites

* .NET 8 SDK
* PostgreSQL

### 1. Configure the Database Connection

Update the connection string in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=InvoiceDb;Username=postgres;Password=your_password"
  }
}
```

### 2. Restore Dependencies

```bash
dotnet restore
```

### 3. Apply Database Migrations

```bash
dotnet ef database update
```

### 4. Run the Application

```bash
dotnet run
```

### 5. Open Swagger UI

```text
https://localhost:5001/swagger
```

---

## Run with Docker Compose

The Docker Compose setup provisions both:

* Invoice Processing API
* PostgreSQL Database

### Build and Start Containers

```bash
docker-compose up -d --build
```

### Access Swagger UI

Wait 10–15 seconds for PostgreSQL to initialize, then open:

```text
http://localhost:8080/swagger
```

### Verify Database (Optional)

Connect to the PostgreSQL container:

```bash
docker exec -it invoiceprocessingservice-postgres-1 psql -U postgres -d InvoiceDb
```

List available tables:

```sql
\dt
```

Expected tables:

```text
__EFMigrationsHistory
Invoices
```

Exit PostgreSQL:

```sql
\q
```

### View Container Logs

```bash
docker-compose logs -f
```

### Stop Containers

```bash
docker-compose down
```

> The same Docker image is used for local Docker Compose deployments and cloud deployment on Render, ensuring consistent behavior across environments.

---

## Cloud Deployment

### Backend (Render) 

The application is deployed on Render using Docker and is publicly accessible via Swagger:

```text
https://invoice-api-23mm.onrender.com/swagger
```

### Frontend (Render)

The React frontend is deployed as a Render Static Site and communicates with the ASP.NET Core API using JWT authentication.

```text
https://invoiceprocessingservice.onrender.com
```

### Neon PostgreSQL

The cloud deployment uses Neon PostgreSQL as the managed database service.

Connection details are provided through Render environment variables, allowing the same application codebase to run locally, in Docker, and in the cloud without modification.

### Deployment Workflow

```text
GitHub Push
      ↓
GitHub Actions Build
      ↓
Render Deployment
      ↓
Neon PostgreSQL
```


---


## CI/CD

### GitHub Actions

The pipeline automatically:

* Restores dependencies
* Builds the application
* Validates every push to main

### Deployment Flow

```text
GitHub Push
      ↓
GitHub Actions Build
      ↓
Render Deployment
      ↓
Neon PostgreSQL
```

---

### Authentication

The application uses JWT (JSON Web Tokens) for authentication and authorization.

Authentication Flow
```text
User Registration
      ↓
User Login
      ↓
JWT Token Generated
      ↓
Token Stored in Browser
      ↓
Protected API Access
```

Passwords are securely hashed using BCrypt before being stored in the database.

---
## Logging

Serilog provides structured logging for:

* Invoice creation
* Validation failures
* Startup events
* Runtime exceptions


