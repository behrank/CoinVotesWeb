using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoinVotesWeb.Data;
using CoinVotesWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace CoinVotesWeb.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly List<User> _users;

        public UserService(AppDbContext context) : base(context)
        {
            // Initialize with sample data
            _users = new List<User>
            {
                new User { ID = 1, Email = "user1@example.com", CreateDate = DateTime.Now.AddDays(-5), DeviceType = "Mobile" },
                new User { ID = 2, Email = "user2@example.com", CreateDate = DateTime.Now.AddDays(-3), DeviceType = "Desktop" },
                new User { ID = 3, Email = "user3@example.com", CreateDate = DateTime.Now.AddDays(-1), DeviceType = "Tablet" }
            };
        }

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