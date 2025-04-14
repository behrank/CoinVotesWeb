using System.Collections.Generic;
using System.Threading.Tasks;
using CoinVotesWeb.Models;

namespace CoinVotesWeb.Services
{
    public interface IUserService : IBaseService<User>
    {
        Task<IEnumerable<User>> GetUsersAsync(int page, int pageSize);
        Task<User> GetUserByIdAsync(int id);
    }
} 