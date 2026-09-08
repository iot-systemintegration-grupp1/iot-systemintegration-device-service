using DeviceService.Models;

namespace DeviceService.Services
{
    public class DeviceRegistrationService
    {
        public DeviceRegistrationResponse RegisterDevice(DeviceRegistrationRequest request, IDeviceRepository repository)
        {
            Device? existingDevice = repository.GetById(request.DeviceId);

            if (existingDevice is not null)
            {
                var duplicateResponse = new DeviceRegistrationResponse
                {
                    Success = false,
                    TimeRegistered = existingDevice.TimeRegistered
                };

                return duplicateResponse;
            }
            
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
