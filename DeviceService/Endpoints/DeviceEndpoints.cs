using DeviceService.Services;
using DeviceService.Models;

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

                    AuthorizationResponse response = new AuthorizationResponse();
                    response.DeviceId = deviceId;
                    response.Authorized = isAuthorized;

                    return response;

                });
        }
    }
}
