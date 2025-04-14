using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoinVotesWeb.Data;
using CoinVotesWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace CoinVotesWeb.Services
{
    public class UserService(AppDbContext context) : BaseService<User>(context), IUserService
    {
        private readonly List<User> _users;

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.Email == email);
        }

        public override async Task<(List<User> Items, int TotalCount)> GetPagedListAsync(int page, int pageSize, string sortBy = null, bool sortDescending = false)
        {
            // Default sort by CreatedAt if not specified
            if (string.IsNullOrEmpty(sortBy))
            {
                sortBy = "CreatedAt";
                sortDescending = true;
            }

            return await base.GetPagedListAsync(page, pageSize, sortBy, sortDescending);
        }

        public async Task<IEnumerable<User>> GetUsersAsync(int page, int pageSize)
        {
            return await Task.FromResult(_users
                .Skip((page - 1) * pageSize)
                .Take(pageSize));
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await Task.FromResult(_users.FirstOrDefault(u => u.ID == id));
        }
    }
} 