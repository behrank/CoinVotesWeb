using System;
using System.Collections.Generic;

namespace CoinVotesWeb.Models;

public partial class SignalSubscription
{
    public int ID { get; set; }

    public int SymbolId { get; set; }

    public int UserId { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }
}
