using DeviceService.Data;
using DeviceService.Models;
using Microsoft.EntityFrameworkCore;

namespace DeviceService.Services;

public class DeviceRepository : IDeviceRepository
{
    private readonly DeviceDbContext _context;

    public DeviceRepository(DeviceDbContext context)
    {
        _context = context;
    }

    public Device? GetById(string deviceId)
    {
        return _context.Devices.FirstOrDefault(d => d.DeviceId == deviceId);
    }

    public IEnumerable<Device> GetAll()
    {
        return _context.Devices.ToList();
    }

    public void Add(Device device)
    {
        if (string.IsNullOrWhiteSpace(device.DeviceId))
        {
            throw new ArgumentException("DeviceId is required.");
        }

        _context.Devices.Add(device);
        _context.SaveChanges();
    }
}