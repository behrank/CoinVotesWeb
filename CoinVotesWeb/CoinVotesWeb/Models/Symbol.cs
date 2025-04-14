using System;
using System.Collections.Generic;

namespace CoinVotesWeb.Models;

public partial class Symbol
{
    public int ID { get; set; }

    public string Name { get; set; } = null!;

    public string SymbolUsdt { get; set; } = null!;

    public string Code { get; set; } = null!;

    public int OrderNo { get; set; }

    public DateTime CreatedAt { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<Price> Prices { get; set; } = new List<Price>();

    public virtual ICollection<UpDownVote> UpDownVotes { get; set; } = new List<UpDownVote>();
}
