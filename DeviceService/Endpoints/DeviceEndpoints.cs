using DeviceService.Services;
using DeviceService.Models;

namespace DeviceService.Endpoints
{
    public class DeviceEndpoints
    {
        public void MapEndpoints(WebApplication app, DeviceAuthorizationService authorizationService, DeviceRegistrationService registrationService, DeviceRepository deviceRepository)
        {
            app.MapGet("/health", () => "Device service is running!");

            app.MapGet("/internal/devices/{deviceId}/authorization",
                (string deviceId) => {

                    bool isAuthorized = authorizationService.IsAuthorized(deviceId, deviceRepository);

                    AuthorizationResponse response = new AuthorizationResponse();
                    response.DeviceId = deviceId;
                    response.Authorized = isAuthorized;

                    return response;

                });

            app.MapPost("/device/register", (DeviceRegistrationRequest request) =>
            {
                DeviceRegistrationResponse response = registrationService.RegisterDevice(request, deviceRepository);

                if (response.Success == false)
                    {
                        return Results.Conflict(response);
                    }
                else
                {
                    return Results.Ok(response);
                }
            });

            app.MapGet("/device/{deviceId}", (string deviceId) =>
            {
                Device? device = deviceRepository.GetById(deviceId);

                if (device == null)
                {
                    return Results.NotFound();
                }
                else
                {
                    return Results.Ok(device);
                }

            });
        }
    }
}
