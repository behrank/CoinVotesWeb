using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoinVotesWeb.Data;
using CoinVotesWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace CoinVotesWeb.Services
{
    public class DeviceService : BaseService<Device>, IDeviceService
    {
        public DeviceService(AppDbContext context) : base(context)
        {
        }

        public async Task<Device> GetByDeviceIdAsync(string deviceId)
        {
            return await _dbSet.FirstOrDefaultAsync(d => d.DeviceId == deviceId);
        }

        public async Task<IEnumerable<Device>> GetDevicesByUserIdAsync(int userId)
        {
            return await _dbSet.Where(d => d.UserId == userId).ToListAsync();
        }

        public override async Task<(List<Device> Items, int TotalCount)> GetPagedListAsync(int page, int pageSize, string sortBy = null, bool sortDescending = false)
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