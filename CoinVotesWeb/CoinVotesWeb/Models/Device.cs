using System;
using System.Collections.Generic;

namespace CoinVotesWeb.Models;

public partial class Device
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

    public string FcmToken { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual User User { get; set; } = null!;
}
