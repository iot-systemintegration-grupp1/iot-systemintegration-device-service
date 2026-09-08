namespace DeviceService.Models;

public class Device
{
    public string DeviceId { get; set; } = string.Empty;
    public DateTime TimeRegistered { get; set; } = DateTime.UtcNow;

}