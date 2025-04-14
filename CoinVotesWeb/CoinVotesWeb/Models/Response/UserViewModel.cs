namespace CoinVotesWeb.Models.Response;

public class UserViewModel
{
    public int Id { get; set; }
    public string Email { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Device { get; set; }
}