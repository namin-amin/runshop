using System.Threading.Tasks;
using runShop.data.Repos.user;

namespace runShop.data.unit
{
    public interface IUnit
    {
        public IUserRepo userRepo { get; }
        public Task SaveChangesAsync();
    }
}
