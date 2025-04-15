using System.Collections.Generic;
using System.Threading.Tasks;
using CoinVotesWeb.Data;

namespace CoinVotesWeb.Services
{
    public interface ISignalSubscriptionService : IBaseService<SignalSubscription>
    {
        // Add any SignalSubscription-specific methods here
        Task<IEnumerable<SignalSubscription>> GetSubscriptionsByUserIdAsync(int userId);
        Task<IEnumerable<SignalSubscription>> GetSubscriptionsBySignalIdAsync(int signalId);
    }
} 