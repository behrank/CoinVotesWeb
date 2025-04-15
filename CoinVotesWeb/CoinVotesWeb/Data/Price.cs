using System;
using System.Collections.Generic;

namespace CoinVotesWeb.Data;

public partial class Price
{
    public int ID { get; set; }

    public int SymbolId { get; set; }

    public string LastPrice { get; set; } = null!;

    public string PriceChange { get; set; } = null!;

    public string PriceChangePercent { get; set; } = null!;

    public string Symbol { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual Symbol SymbolNavigation { get; set; } = null!;
}
