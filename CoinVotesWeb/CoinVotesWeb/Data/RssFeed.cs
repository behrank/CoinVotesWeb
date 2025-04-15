using System;
using System.Collections.Generic;

namespace CoinVotesWeb.Data;

public partial class RssFeed
{
    public int ID { get; set; }

    public DateTime PublishingDate { get; set; }

    public string Title { get; set; } = null!;

    public string Link { get; set; } = null!;

    public string Source { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public string ImageUrl { get; set; } = null!;
}
