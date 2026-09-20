using DeviceService.Services;
using DeviceService.Models;

namespace DeviceService.Endpoints
{
    public class DeviceEndpoints
    {
        public void MapEndpoints(WebApplication app)
        {
            app.MapGet("/health", () => "Device service is running!");

            app.MapGet("/device/authenticate/{deviceId}",
                (string deviceId, DeviceAuthorizationService authorizationService, IDeviceRepository deviceRepository) => {

                    bool isAuthorized = authorizationService.IsAuthorized(deviceId, deviceRepository);

                    AuthorizationResponse response = new AuthorizationResponse();
                    response.DeviceId = deviceId;
                    response.Authorized = isAuthorized;

                    return response;

                });

            app.MapPost("/device/register", (DeviceRegistrationRequest request, DeviceRegistrationService registrationService, IDeviceRepository deviceRepository) =>
            {
                DeviceRegistrationResponse response = registrationService.RegisterDevice(request, deviceRepository);

                if (response.Success == false)
                    {
                        return Results.Json(response);
                    }
                else
                {
                    return Results.Ok(response);
                }
            });

            app.MapGet("/device/getby/{deviceId}", (string deviceId, IDeviceRepository deviceRepository) =>
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
