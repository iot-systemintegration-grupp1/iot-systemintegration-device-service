using DeviceService.Models;

namespace DeviceService.Services;

public class DeviceRepository : IDeviceRepository
{
    private readonly List<Device> _devices = new();

    public Device? GetById(string deviceId)
    {
        return _devices.FirstOrDefault(d => d.DeviceId == deviceId);
    }

    public IEnumerable<Device> GetAll()
    {
        return _devices;
    }

    public void Add(Device device)
    {
        if (string.IsNullOrWhiteSpace(device.DeviceId))
        {
            throw new ArgumentException("DeviceId is required.");
        }

        _devices.Add(device);
    }
}