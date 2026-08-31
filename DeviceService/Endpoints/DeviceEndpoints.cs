using DeviceService.Services;

namespace DeviceService.Endpoints
{
    public class DeviceEndpoints
    {
        public void MapEndpoints(WebApplication app, DeviceAuthorizationService authorizationService, List<string> authorizedDevices)
        {
            app.MapGet("/health", () => "Device service is running!");

            app.MapGet("/internal/devices/{deviceId}/authorization",
                (string deviceId) => {

                    bool isAuthorized = authorizationService.IsAuthorized(deviceId, authorizedDevices);

                    var response = new { deviceId = deviceId, authorized = isAuthorized };

                    return response;

                });
        }
    }
}
