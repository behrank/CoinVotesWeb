using System.Collections.Generic;
using System.Threading.Tasks;
using CoinVotesWeb.Models;

namespace CoinVotesWeb.Services
{
    public interface ISymbolService : IBaseService<Symbol>
    {
        Task<Symbol> GetBySymbolAsync(string symbol);
        Task<IEnumerable<Symbol>> GetActiveSymbolsAsync();
    }
} 