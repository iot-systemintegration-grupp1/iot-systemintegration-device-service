using DeviceService.Models;

namespace DeviceService.Services
{
    public class DeviceRegistrationService
    {
        public DeviceRegistrationResponse RegisterDevice(DeviceRegistrationRequest request, IDeviceRepository repository)
        {
            Device device = new Device();

            device.DeviceId = request.DeviceId;

            repository.Add(device);

            DeviceRegistrationResponse response = new DeviceRegistrationResponse();

            response.Success = true;

            response.TimeRegistered = device.TimeRegistered;

            return response;
        }
    }
}
