using System;
using System.Collections.Generic;

namespace CoinVotesWeb.Data;

public partial class Signal
{
    public int ID { get; set; }

    public string SymbolCode { get; set; } = null!;

    public double Probability { get; set; }

    public double LastPrice { get; set; }

    public DateTime EventTime { get; set; }

    public bool IsUp { get; set; }

    public DateTime CreatedAt { get; set; }

    public double EMA { get; set; }

    public double PriceDiff { get; set; }

    public double SMA { get; set; }

    public double LastVolume { get; set; }

    public double VolumeChange { get; set; }

    public double TopPriceChange { get; set; }

    public double TopRelativePriceChange { get; set; }

    public int TypeId { get; set; }

    public int TrackType { get; set; }

    public double AtrNormalizeDiff { get; set; }

    public double EmaSmaDiff { get; set; }
}
