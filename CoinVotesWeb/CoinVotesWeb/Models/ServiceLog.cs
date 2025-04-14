using System;
using System.Collections.Generic;

namespace CoinVotesWeb.Models;

public partial class ServiceLog
{
    public int ID { get; set; }

    public string ServiceName { get; set; } = null!;

    public string EventName { get; set; } = null!;

    public DateTime CreatedAt { get; set; }
}
