using runShop.data.unit;
using runShop.Models.models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace runShop.services.user
{
    public class UserService : IUserService
    {
        private readonly IUnit dataUnit;

        public UserService(IUnit dataUnit) {
            this.dataUnit = dataUnit;
        }
        public  async Task<bool> DeleteUserAsync(ulong id)
        {
          var success = await  dataUnit.userRepo.Delete(id);
            if (success)
            {
                await dataUnit.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return dataUnit.userRepo.GetAll();
        }

        public Task<User?> GetOneUserAsync(ulong id) => dataUnit.userRepo.Get(id);

        public async Task<User?> UpdateUserAsync(User user)
        {
            if (await dataUnit.userRepo.Update(user))
            {
                await dataUnit.SaveChangesAsync();
                return user;
            }
            else return null;
        }
    }
}
