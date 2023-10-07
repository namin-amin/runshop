using runShop.data.unit;
using runShop.Models.models;
using System.Collections.Generic;
using System.Threading.Tasks;
using runShop.services.auth;
using System;

namespace runShop.services.user;

public class UserService : IUserService
{
    private readonly IUnit dataUnit;
    private readonly IPassWordHash _passWordHash;

    public UserService(IUnit _dataUnit, IPassWordHash passWordHash)
    {
        this.dataUnit = _dataUnit;
        this._passWordHash = passWordHash;
    }


    public async Task<User?> CreateNewUser(User user)
    {
        var hashedPassword = _passWordHash.GetHashedPassword(user.Password);
        user.Password = hashedPassword;
        user.CreatedAt = DateTime.Now;
        user.UpdateAt = DateTime.Now;   
        await dataUnit.userRepo.Create(user);
        await dataUnit.SaveChangesAsync();
        return user;
    }

    public async Task<bool> DeleteUserAsync(ulong id)
    {
        var success = await dataUnit.userRepo.Delete(id);
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
