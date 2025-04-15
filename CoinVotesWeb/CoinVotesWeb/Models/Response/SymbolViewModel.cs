namespace CoinVotesWeb.Models.Response;

public class SymbolViewModel
{
    public int ID { get; set; }
    public string Name { get; set; } = "";
    public string SymbolUsdt { get; set; } = "";
    public string Code { get; set; } = "";
    public int OrderNo { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsActive { get; set; }
}