using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoinVotesWeb.Data;
using CoinVotesWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace CoinVotesWeb.Services
{
    public class SignalService : BaseService<Signal>, ISignalService
    {
        public SignalService(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Signal>> GetActiveSignalsAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<Signal>> GetSignalsBySymbolCodeAsync(string symbolCode)
        {
            return await _dbSet.Where(s => s.SymbolCode == symbolCode).ToListAsync();
        }

        public override async Task<(List<Signal> Items, int TotalCount)> GetPagedListAsync(int page, int pageSize, string sortBy = null, bool sortDescending = false, string filter = null)
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