using runShop.Models.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace runShop.services.user
{
    public interface IUserService
    {
        Task<User?> GetOneUserAsync(ulong id);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User?> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(ulong id);
    }
}
