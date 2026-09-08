namespace DeviceService.Models
{
    public class AuthorizationResponse()
    {
        public string DeviceId { get; set; } = string.Empty;
        public bool Authorized { get; set; } = false;

    }
}
