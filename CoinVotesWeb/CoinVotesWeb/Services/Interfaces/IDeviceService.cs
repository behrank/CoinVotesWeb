using System.Collections.Generic;
using System.Threading.Tasks;
using CoinVotesWeb.Data;

namespace CoinVotesWeb.Services
{
    public interface IDeviceService : IBaseService<Device>
    {
        // Add any Device-specific methods here
        Task<Device> GetByDeviceIdAsync(string deviceId);
        Task<IEnumerable<Device>> GetDevicesByUserIdAsync(int userId);
    }
} 