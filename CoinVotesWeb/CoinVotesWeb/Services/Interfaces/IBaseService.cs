using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoinVotesWeb.Services
{
    public interface IBaseService<T> where T : class
    {
        // Create
        Task<T> CreateAsync(T entity);
        
        // Read
        Task<T> GetByIdAsync(int id);
        Task<(List<T> Items, int TotalCount)> GetPagedListAsync(int page, int pageSize, string sortBy = null, bool sortDescending = false, string searchTerm = null);
        
        // Update
        Task<T> UpdateAsync(T entity);
        
        // Delete
        Task<bool> DeleteAsync(int id);
    }
} 