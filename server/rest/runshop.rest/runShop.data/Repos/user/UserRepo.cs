using runShop.data.Repos.baseRepo;
using runShop.Models.models;

namespace runShop.data.Repos.user
{
    public class UserRepo : BaseRepo<User>, IUserRepo
    {
        public UserRepo(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}

