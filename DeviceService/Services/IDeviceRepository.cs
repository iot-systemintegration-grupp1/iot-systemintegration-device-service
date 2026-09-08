using DeviceService.Models;

namespace DeviceService.Services;

public interface IDeviceRepository
{
    Device? GetById(string deviceId);
    IEnumerable<Device> GetAll();
    void Add(Device device);
}

