# FinFlow

A banking data platform consisting of a .NET minimal API backend (Postgres-backed) and a Python-based synthetic data generator used for seeding customers, accounts, and transactions during development and testing.

![.NET CI](https://github.com/<your-username>/FinFlow/actions/workflows/dotnet-ci.yml/badge.svg)
![Python CI](https://github.com/<your-username>/FinFlow/actions/workflows/python-ci.yml/badge.svg)
![License](https://img.shields.io/badge/license-MIT-blue.svg)

## Overview

FinFlow models a simplified core-banking domain — customers, accounts, and transactions — exposed through a REST API. The `DataGenerator` tool produces realistic fake data (via [Faker](https://faker.readthedocs.io/)) and posts it to the API, making it easy to populate a development database without writing data by hand.

## Repository Structure

```
FinFlow/
├── FinFlow/              # .NET minimal API (backend)
│   ├── Dtos/              # Request/response DTOs
│   ├── Endpoints/         # Minimal API endpoint definitions
│   └── ...
├── DataGenerator/        # Python fake-data generator / seeder
│   ├── src/
│   │   ├── customers.py
│   │   ├── accounts.py
│   │   └── transactions.py
│   ├── main.py
│   └── requirements.txt
├── .github/workflows/    # CI pipelines
├── LICENSE
├── CONTRIBUTING.md
└── README.md
```

## Tech Stack

| Layer          | Technology                          |
|----------------|--------------------------------------|
| API            | .NET (Minimal APIs, C#)             |
| ORM            | Entity Framework Core + Npgsql      |
| Database       | PostgreSQL                          |
| Data generator | Python 3.12, Faker, Requests        |
| CI             | GitHub Actions                      |

## Architecture

```
┌─────────────────────┐        HTTP/JSON        ┌──────────────────────┐
│   DataGenerator      │  ───────────────────▶   │     FinFlow API      │
│   (Python, Faker)    │                          │   (.NET Minimal API) │
└─────────────────────┘                          └──────────┬───────────┘
                                                              │
                                                              ▼
                                                   ┌──────────────────────┐
                                                   │     PostgreSQL        │
                                                   └──────────────────────┘
```

## Getting Started

### Prerequisites

- [.NET SDK 8+](https://dotnet.microsoft.com/download)
- [PostgreSQL](https://www.postgresql.org/download/)
- [Python 3.12+](https://www.python.org/downloads/)

### 1. Run the API

```bash
cd FinFlow
dotnet restore
dotnet run
```

By default the API listens on `http://localhost:5140` (adjust `launchSettings.json` if needed). Ensure your Postgres connection string is set in `appsettings.json` or via environment variables, then apply migrations:

```bash
dotnet ef database update
```

### 2. Run the data generator

```bash
cd DataGenerator
python -m venv .dataGenerator
source .dataGenerator/bin/activate      # Windows: .dataGenerator\Scripts\activate
pip install -r requirements.txt
python main.py
```

This creates a customer, an account linked to that customer, and a transaction linked to that account, printing the API's response for each.

## API Endpoints

| Method | Route              | Description              |
|--------|---------------------|---------------------------|
| GET    | `/customers`         | List customers            |
| GET    | `/customers/{id}`    | Get customer by ID        |
| POST   | `/customers`         | Create a customer          |
| GET    | `/accounts`           | List accounts             |
| GET    | `/accounts/{id}`      | Get account by ID         |
| POST   | `/accounts`           | Create an account          |
| PUT    | `/accounts/{id}`      | Update an account          |
| DELETE | `/accounts/{id}`      | Delete an account          |
| POST   | `/transactions`       | Create a transaction       |

> Note: Dates sent to the API must be UTC ISO 8601 strings ending in `Z` (e.g. `2026-07-20T11:03:09.183900Z`). PostgreSQL's `timestamptz` columns reject non-UTC `DateTime.Kind` values.

## Roadmap

- [ ] Add authentication/authorization
- [ ] Add pagination and filtering to list endpoints
- [ ] Dockerize API + Postgres for one-command local setup
- [ ] Expand data generator to support bulk seeding via CLI flags

## Contributing

Contributions are welcome — see [CONTRIBUTING.md](./CONTRIBUTING.md) for guidelines.

## License

Distributed under the MIT License. See [LICENSE](./LICENSE) for details.