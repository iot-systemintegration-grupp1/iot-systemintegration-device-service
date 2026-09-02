namespace DeviceService.Services
{
    public class DeviceAuthorizationService
    {
        public bool IsAuthorized(string deviceId, List<string> authorizedDevices)
        {
            return authorizedDevices.Contains(deviceId);
        }
    }
}
