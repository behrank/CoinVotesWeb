using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoinVotesWeb.Data;
using CoinVotesWeb.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CoinVotesWeb.Services
{
    public class UserService(AppDbContext context) : BaseService<User>(context), IUserService
    {
        private readonly List<User> _users;

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.Email == email);
        }

        public override async Task<(List<User> Items, int TotalCount)> GetPagedListAsync(int page, int pageSize, string sortBy = null, bool sortDescending = false, string searchTerm = null)
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
                query = query.Where(u => 
                    u.ID.ToString().Contains(searchTerm) ||
                    u.Email.ToLower().Contains(searchTerm) || 
                    u.FirstName.ToLower().Contains(searchTerm) || 
                    u.LastName.ToLower().Contains(searchTerm)
                );
            }

            // Apply sorting
            var parameter = Expression.Parameter(typeof(User), "x");
            var property = Expression.Property(parameter, sortBy);
            var lambda = Expression.Lambda(property, parameter);
            
            var methodName = sortDescending ? "OrderByDescending" : "OrderBy";
            var resultExp = Expression.Call(
                typeof(Queryable),
                methodName,
                new Type[] { typeof(User), property.Type },
                query.Expression,
                Expression.Quote(lambda)
            );
            
            query = query.Provider.CreateQuery<User>(resultExp);

            // Get total count
            var totalCount = await query.CountAsync();

            // Apply paging
            var items = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalCount);
        }

        public async Task<IEnumerable<User>> GetUsersAsync(int page, int pageSize)
        {
            var result = await GetPagedListAsync(page, pageSize);
            return result.Items;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.ID == id);
        }
    }
} 