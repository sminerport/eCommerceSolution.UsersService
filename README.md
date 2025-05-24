# eCommerce Users Microservice

This repository contains the **Users** service for the eCommerce microservice example.
It is built with **ASP.NET Core**, uses **Dapper** to interact with PostgreSQL and provides
APIs for user authentication and retrieval.

## Projects

| Folder | Description |
| ------ | ----------- |
| `eCommerce.API` | ASP.NET Core Web API exposing `/api/auth` and `/api/users` endpoints. Contains `Program.cs`, controllers, middleware and the service Dockerfile. |
| `eCommerce.Core` | Business logic layer. Includes domain models, DTOs, validators and service interfaces/implementations. |
| `eCommerce.Infrastructure` | Data access layer implemented with Dapper. Provides repositories and the `DapperDbContext`. |
| `UsersUnitTests` | Example xUnit test project. |
| `k8s` | Kubernetes manifests for the service in multiple environments (`dev`, `qa`, `uat`, `staging`, `prod`). |
| `azure-pipelines.yml` | Azure DevOps pipeline for building, testing and deploying the service. |

## Running locally

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/) (for `dotnet run` or unit tests)
- Docker (optional, to build the container image)
- PostgreSQL instance accessible using the variables below

### Environment variables

The service expects a PostgreSQL connection using the following variables (defaults are defined in the Dockerfile):

- `POSTGRES_HOST`
- `POSTGRES_PORT`
- `POSTGRES_USER`
- `POSTGRES_PASSWORD`
- `POSTGRES_DB`

You can also provide these through a connection string named `PostgresConnection`.

### Running with `dotnet`

```bash
cd eCommerce.API
dotnet run --urls=http://localhost:9090
```

The API will be available on `http://localhost:9090`.

### Running with Docker

```bash
docker build -t users-microservice -f eCommerce.API/Dockerfile .
docker run -p 9090:9090 \
  -e POSTGRES_HOST=<host> \
  -e POSTGRES_PORT=<port> \
  -e POSTGRES_USER=<user> \
  -e POSTGRES_PASSWORD=<password> \
  -e POSTGRES_DB=<db> \
  users-microservice
```

## Tests

Unit tests are located in `UsersUnitTests`. Run them with:

```bash
dotnet test
```

## Deployment

Kubernetes manifests are provided under the `k8s` directory. They reference the
Docker image built by the pipeline and configure the necessary ConfigMaps and Secrets.
Review the files in the appropriate environment folder before applying them with `kubectl`.

