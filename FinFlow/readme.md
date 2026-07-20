# FinFlow API

A .NET minimal API backing the FinFlow banking data platform, using Entity Framework Core with Npgsql (PostgreSQL).

## Setup

1. Configure your Postgres connection string in `appsettings.Development.json` or via environment variable:
   ```bash
   export ConnectionStrings__DefaultConnection="Host=localhost;Database=finflow;Username=postgres;Password=yourpassword"
   ```
2. Apply migrations:
   ```bash
   dotnet ef database update
   ```
3. Run the API:
   ```bash
   dotnet run
   ```

## Project Structure

```
FinFlow/
├── Dtos/           # Create/Update DTOs per entity
├── Endpoints/      # Minimal API route definitions, grouped by resource
├── Program.cs
└── appsettings.json
```

## Conventions

- All `DateTime` fields map to Postgres `timestamp with time zone` columns and must be sent as UTC.
- DTOs are C# `record` types for immutability and concise equality semantics.
- Routes are grouped with `MapGroup` per resource (e.g. `/customers`, `/accounts`, `/transactions`).

See the root README(../README.md#api-endpoints) for the full endpoint reference.