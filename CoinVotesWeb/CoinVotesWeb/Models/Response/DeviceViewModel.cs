namespace CoinVotesWeb.Models.Response;

public class DeviceViewModel
{
    public int ID { get; set; }
    public string DeviceId { get; set; } = null!;

    public string DeviceType { get; set; } = null!;
    public string DeviceModel { get; set; } = null!;
    public int UserId { get; set; }
    public string OsVersion { get; set; } = null!;
    public string DeviceLanguage { get; set; } = null!;
    public string DeviceRegion { get; set; } = null!;
    public bool IsNotificationPermissionGiven { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    
}