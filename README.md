# Device Service

Device Service is part of the distributed IoT monitoring system developed for the **System Integration** course at Nackademin.

The service is responsible for registering devices, retrieving device information and checking whether a device is registered and therefore authorized.

## Tech Stack

- .NET 10 / ASP.NET Core Minimal API
- Entity Framework Core
- Microsoft SQL Server
- Azure Web App
- GitHub Actions

## API Endpoints

| Method | Endpoint | Description |
|---|---|---|
| `GET` | `/health` | Checks that the service is running |
| `POST` | `/device/register` | Registers a new device |
| `GET` | `/device/getby/{deviceId}` | Returns a device by ID |
| `GET` | `/device/authenticate/{deviceId}` | Checks whether a device is registered |

### Register a device

```json
{
  "deviceId": "TEMP-001"
}
```

A successfully registered device receives a UTC registration timestamp. Duplicate registrations return `success: false` together with a message explaining that the device is already registered.

## Architecture

The service follows a simple separation of responsibilities:

```text
Endpoints
   ↓
Services
   ↓
Repository
   ↓
SQL Server
```

`DeviceRepository` uses Entity Framework Core through `DeviceDbContext` to store and retrieve devices from the database.

In the group system, **Integration Service acts as the client** and calls Device Service through HTTP. Device Service does not call Integration Service.

## Database

The `Device` model currently contains:

- `DeviceId` – primary key
- `TimeRegistered` – UTC registration timestamp

Entity Framework Core migrations are included in the project.

A connection string named `DeviceDatabase` must be configured before running the service.

## Run locally

```bash
dotnet restore
dotnet run --project DeviceService
```

## Deployment

Pushes to the `master` branch trigger the GitHub Actions workflow, which builds the project and deploys it to the Azure Web App named `device-service`.

## Contributors

Developed by **Group 1** as part of the System Integration course.
