using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoinVotesWeb.Data;
using CoinVotesWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace CoinVotesWeb.Services
{
    public class SignalSubscriptionService : BaseService<SignalSubscription>, ISignalSubscriptionService
    {
        public SignalSubscriptionService(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<SignalSubscription>> GetSubscriptionsByUserIdAsync(int userId)
        {
            return await _dbSet.Where(s => s.UserId == userId).ToListAsync();
        }

        public async Task<IEnumerable<SignalSubscription>> GetSubscriptionsBySignalIdAsync(int signalId)
        {
            return await _dbSet.Where(s => s.ID == signalId).ToListAsync();
        }

        public override async Task<(List<SignalSubscription> Items, int TotalCount)> GetPagedListAsync(int page, int pageSize, string sortBy = null, bool sortDescending = false, string filter = null)
        {
            // Default sort by CreatedAt if not specified
            if (string.IsNullOrEmpty(sortBy))
            {
                sortBy = "CreatedAt";
                sortDescending = true;
            }

            return await base.GetPagedListAsync(page, pageSize, sortBy, sortDescending);
        }
    }
} 