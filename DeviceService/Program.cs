var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

List<string> authorizedDevices = new List<string> { "DEVICE-001", "TEMP-001", "HUMIDITY-001"};

app.MapGet("/health", () => "Device Service är igång!");
app.MapGet("/internal/devices/{deviceId}/authorization",
    (string deviceId) => {

        bool isAuthorized = authorizedDevices.Contains(deviceId);

        var response = new { deviceId = deviceId, authorized = isAuthorized };

        return response;
 
    });



app.Run();
