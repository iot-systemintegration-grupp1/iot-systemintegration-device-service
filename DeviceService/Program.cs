using DeviceService.Services;
using DeviceService.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

List<string> authorizedDevices = new List<string> { "DEVICE-001", "TEMP-001", "HUMIDITY-001"};

DeviceAuthorizationService authorizationService = new DeviceAuthorizationService();
DeviceEndpoints deviceEndpoints = new DeviceEndpoints ();

deviceEndpoints.MapEndpoints(app, authorizationService, authorizedDevices);

app.MapGet("/internal/devices/{deviceId}/authorization",
    (string deviceId) => {

        bool isAuthorized = authorizationService.IsAuthorized(deviceId, authorizedDevices);

        var response = new { deviceId = deviceId, authorized = isAuthorized };

        return response;
 
    });



app.Run();
