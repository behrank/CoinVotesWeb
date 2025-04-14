using System;
using System.Collections.Generic;

namespace CoinVotesWeb.Models;

public partial class Poll
{
    public int ID { get; set; }

    public int Symbol_Id { get; set; }

    public int PollType { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<UpDownVote> UpDownVotes { get; set; } = new List<UpDownVote>();
}
