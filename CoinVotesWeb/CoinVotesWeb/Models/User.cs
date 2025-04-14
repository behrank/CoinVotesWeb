using System;
using System.Collections.Generic;

namespace CoinVotesWeb.Models;

public partial class User
{
    public int ID { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordSalt { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public int Gender { get; set; }

    public bool IsGenericUser { get; set; }

    public string RefreshToken { get; set; } = null!;

    public DateTime RefreshTokenExpiry { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<Device> Devices { get; set; } = new List<Device>();

    public virtual ICollection<UpDownVote> UpDownVotes { get; set; } = new List<UpDownVote>();
}
