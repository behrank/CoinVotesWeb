using System;
using System.Collections.Generic;

namespace CoinVotesWeb.Models;

public partial class Purchase
{
    public int ID { get; set; }

    public string UserId { get; set; } = null!;

    public string? ReceiptData { get; set; }

    public bool IsDefault { get; set; }

    public int AllowedSignalAmount { get; set; }

    public DateTime CreatedAt { get; set; }

    public long EventTime { get; set; }

    public string ProductId { get; set; } = null!;

    public string Store { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string Environment { get; set; } = null!;
}
