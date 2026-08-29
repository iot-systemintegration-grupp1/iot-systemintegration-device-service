var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/health", () => "Device Service är igång!");
app.MapGet("/internal/devices/{deviceId}/authorization",
    (string deviceId) => {
        if (deviceId == "DEVICE-001")
        {
            return "The device is authorized!";
        }
        else
        {
            return "The device is not authorized!";
        }
    });




app.Run();
