using DeviceService.Services;

namespace DeviceService.Endpoints
{
    public class DeviceEndpoints
    {
        public void MapEndpoints(WebApplication app, DeviceAuthorizationService authorizationService, List<string> authorizedDevices)
        {
            app.MapGet("/health", () => "Device service is running!");
        }
    }
}
