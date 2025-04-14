using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoinVotesWeb.Data;
using CoinVotesWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace CoinVotesWeb.Services
{
    public class PurchaseService : BaseService<Purchase>, IPurchaseService
    {
        public PurchaseService(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Purchase>> GetPurchasesByUserIdAsync(int userId)
        {
            return await _context.Purchases
                .Where(p => p.UserId == userId.ToString())
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<Purchase>> GetPurchasesBySignalIdAsync(int signalId)
        {
            return await _context.Purchases
                .Where(p => p.ID == signalId)
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();
        }

        public override async Task<(List<Purchase> Items, int TotalCount)> GetPagedListAsync(int page, int pageSize, string sortBy = null, bool sortDescending = false)
        {
            var query = _context.Purchases.AsQueryable();

            // Default sorting
            if (string.IsNullOrEmpty(sortBy))
            {
                sortBy = "CreatedAt";
                sortDescending = true;
            }
            
            var totalCount = await query.CountAsync();
            var items = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalCount);
        }
    }
} 