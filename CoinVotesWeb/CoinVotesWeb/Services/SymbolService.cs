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
    public class SymbolService(AppDbContext context) : BaseService<Symbol>(context), ISymbolService
    {
        public async Task<Symbol> GetBySymbolAsync(string symbolCode)
        {
            return await _dbSet.FirstOrDefaultAsync(s => s.SymbolUsdt == symbolCode);
        }

        public async Task<IEnumerable<Symbol>> GetActiveSymbolsAsync()
        {
            return await _dbSet.Where(s => s.IsActive).ToListAsync();
        }

        public override async Task<(List<Symbol> Items, int TotalCount)> GetPagedListAsync(int page, int pageSize, string sortBy = null, bool sortDescending = false, string searchTerm = null)
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
                query = query.Where(s => 
                    s.ID.ToString().Contains(searchTerm) ||
                    s.SymbolUsdt.ToLower().Contains(searchTerm) || 
                    s.Name.ToLower().Contains(searchTerm) || 
                    s.Code.ToLower().Contains(searchTerm)
                );
            }

            // Apply sorting
            var parameter = Expression.Parameter(typeof(Symbol), "x");
            var property = Expression.Property(parameter, sortBy);
            var lambda = Expression.Lambda(property, parameter);
            
            var methodName = sortDescending ? "OrderByDescending" : "OrderBy";
            var resultExp = Expression.Call(
                typeof(Queryable),
                methodName,
                new Type[] { typeof(Symbol), property.Type },
                query.Expression,
                Expression.Quote(lambda)
            );
            
            query = query.Provider.CreateQuery<Symbol>(resultExp);

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