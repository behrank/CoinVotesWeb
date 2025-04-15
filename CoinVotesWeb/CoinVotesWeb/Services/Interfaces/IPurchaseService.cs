using System.Collections.Generic;
using System.Threading.Tasks;
using CoinVotesWeb.Models;

namespace CoinVotesWeb.Services
{
    public interface IPurchaseService : IBaseService<Purchase>
    {
        Task<IEnumerable<Purchase>> GetPurchasesByUserIdAsync(int userId);
        Task<IEnumerable<Purchase>> GetPurchasesBySignalIdAsync(int signalId);
    }
} 