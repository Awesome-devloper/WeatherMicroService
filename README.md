# WeatherMicroService

.NET 5 microservices solution (Weather / Registration / Login + Console app) with Docker Compose.

## Build (local)

```bash
dotnet restore "WeatherMicro.sln"
dotnet build "WeatherMicro.sln" -c Release
```

## Run with Docker Compose

```bash
docker compose up --build
```

### Exposed ports (from `docker-compose.override.yml`)

- **Registration API**: `http://localhost:8090`
- **Login API**: `http://localhost:8092`
- **Console app**: `http://localhost:8094`
- **Weather API**: `http://localhost:8096`
- **MongoDB**: `mongodb://localhost:27017`
- **RabbitMQ**:
  - AMQP: `amqp://localhost:5672`
  - Management UI: `http://localhost:15672` (default user/pass: `admin` / `admin`)

## CI

GitHub Actions workflow lives at `.github/workflows/ci.yml` and runs `dotnet restore/build/test` on pushes and PRs to `master`.
