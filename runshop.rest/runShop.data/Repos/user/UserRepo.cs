using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using runShop.data.Repos.baseRepo;
using runShop.Models.models;

namespace runShop.data.Repos.user;
public class UserRepo : BaseRepo<User>, IUserRepo
{
    public UserRepo(AppDbContext appDbContext) : base(appDbContext)
    {
    }

    public async Task<bool> IsVerifiedUser(User user)
    {
        var validuser = await dbSet.FirstOrDefaultAsync(u =>
                  u.Email == user.Email && u.Password == user.Password
              );

        return validuser is not null;
    }
}


