using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoinVotesWeb;
using CoinVotesWeb.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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

        public override async Task<(List<Device> Items, int TotalCount)> GetPagedListAsync(int page, int pageSize, string sortBy = null, bool sortDescending = false, string searchTerm = null)
        {
            // Default sort by CreatedAt if not specified
            if (string.IsNullOrEmpty(sortBy))
            {
                sortBy = "CreatedAt";
                sortDescending = true;
            }

            var query = _dbSet.AsQueryable();

            // Apply search filter if provided
            if (!string.IsNullOrEmpty(searchTerm))
            {
                searchTerm = searchTerm.ToLower();
                query = query.Where(d => 
                    d.ID.ToString().Contains(searchTerm) ||
                    d.DeviceId.ToLower().Contains(searchTerm) || 
                    d.DeviceType.ToLower().Contains(searchTerm) || 
                    d.DeviceModel.ToLower().Contains(searchTerm) ||
                    d.User.Email.ToLower().Contains(searchTerm)
                );
            }

            // Apply sorting
            var parameter = Expression.Parameter(typeof(Device), "x");
            var property = Expression.Property(parameter, sortBy);
            var lambda = Expression.Lambda(property, parameter);
            
            var methodName = sortDescending ? "OrderByDescending" : "OrderBy";
            var resultExp = Expression.Call(
                typeof(Queryable),
                methodName,
                new Type[] { typeof(Device), property.Type },
                query.Expression,
                Expression.Quote(lambda)
            );
            
            query = query.Provider.CreateQuery<Device>(resultExp);

            // Get total count
            var totalCount = await query.CountAsync();

            // Apply paging
            var items = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalCount);
        }
    }
} 