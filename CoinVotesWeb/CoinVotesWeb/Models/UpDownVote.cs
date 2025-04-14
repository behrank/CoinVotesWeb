using System;
using System.Collections.Generic;

namespace CoinVotesWeb.Models;

public partial class UpDownVote
{
    public int ID { get; set; }

    public bool Value { get; set; }

    public int PollId { get; set; }

    public int UserId { get; set; }

    public DateTime CreatedAt { get; set; }

    public int? SymbolID { get; set; }

    public virtual Poll Poll { get; set; } = null!;

    public virtual Symbol? Symbol { get; set; }

    public virtual User User { get; set; } = null!;
}
