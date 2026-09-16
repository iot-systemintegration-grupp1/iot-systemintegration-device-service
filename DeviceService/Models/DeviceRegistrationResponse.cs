namespace DeviceService.Models
{
    public class DeviceRegistrationResponse
    {
        public bool Success { get; set; }

        public DateTime TimeRegistered { get; set; }

        public string? Message { get; set; }
    }
}
