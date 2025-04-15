using System.ComponentModel.DataAnnotations;

namespace CoinVotesWeb.Models.Request
{
    public class SymbolUpdateModel
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        public string SymbolUsdt { get; set; }

        [Required]
        [StringLength(10)]
        public string Code { get; set; }

        public int OrderNo { get; set; }

        public bool IsActive { get; set; }
    }
} 