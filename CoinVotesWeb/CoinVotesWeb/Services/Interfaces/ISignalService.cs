using System.Collections.Generic;
using System.Threading.Tasks;
using CoinVotesWeb.Data;

namespace CoinVotesWeb.Services
{
    public interface ISignalService : IBaseService<Signal>
    {
        // Add any Signal-specific methods here
        Task<IEnumerable<Signal>> GetActiveSignalsAsync();
        Task<IEnumerable<Signal>> GetSignalsBySymbolCodeAsync(string symbolCode);
    }
} 