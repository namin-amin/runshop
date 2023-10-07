using System.Threading.Tasks;
using runShop.data.Repos.baseRepo;
using runShop.Models.models;

namespace runShop.data.Repos.user;

public interface IUserRepo : IBaseRepo<User>
{
    Task<bool> IsVerifiedUser(User user);
}