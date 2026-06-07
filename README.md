# Invoice Processing Service

A REST API for invoice processing built with **ASP.NET Core 8**, **Entity Framework Core**, **PostgreSQL**, **Serilog**, and **Docker**.

## 🚀 Tech Stack

- ASP.NET Core 8 Web API
- Entity Framework Core (Code‑First)
- PostgreSQL (Npgsql)
- Serilog (structured logging)
- Docker & Docker Compose
- GitHub Actions CI

## 📦 Features

- Create invoice with business validation (amount > 0)
- Retrieve all invoices / single invoice by ID
- Structured logging with Serilog
- Repository + Service pattern
- Swagger documentation
- Docker containerisation (API + PostgreSQL)
- GitHub Actions CI (build on every push)

## 🛠️ Run Locally (without Docker)

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [PostgreSQL](https://www.postgresql.org/download/) running locally

### Steps
1. Clone the repo  
2. Update connection string in `appsettings.json`
3. Run `dotnet ef database update`
4. Run `dotnet run`
5. Open Swagger: `https://localhost:5001/swagger`

## 🐳 Run with Docker Compose

```bash
docker-compose up -d