using DeviceService.Models;

namespace DeviceService.Services
{
    public class DeviceAuthorizationService
    {
        public bool IsAuthorized(string deviceId, IDeviceRepository repository)
        {
            Device? device = repository.GetById(deviceId);
            

            if (device is not null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
