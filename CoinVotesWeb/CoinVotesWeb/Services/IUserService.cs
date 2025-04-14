using System.Collections.Generic;
using System.Threading.Tasks;
using CoinVotesWeb.Models;

namespace CoinVotesWeb.Services
{
    public interface IUserService : IBaseService<User>
    {
        Task<IEnumerable<User>> GetUsersAsync(int page, int pageSize);
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetByEmailAsync(string email);
        Task<(List<User> Items, int TotalCount)> GetPagedListAsync(int page, int pageSize, string sortBy = null, bool sortDescending = false, string searchTerm = null);
    }
} 