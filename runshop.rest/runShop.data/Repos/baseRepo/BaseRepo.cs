using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using runShop.Models.models;

namespace runShop.data.Repos.baseRepo;
public class BaseRepo<T> : IBaseRepo<T>
    where T : BaseModel
{
    internal readonly DbSet<T> dbSet;

    public BaseRepo(AppDbContext appContext)
    {
        dbSet = appContext.Set<T>();
    }

    public async Task Create(T model)
    {
      await  dbSet.AddAsync(model);
    }

    public async Task<bool> Delete(ulong id)
    {
        var entity = await Get(id);
        if (entity is null)
        {
            return false;
        }
        dbSet.Remove(entity);
        return true;
    }

    public async Task<T?> Get(ulong id)
    {
        return await dbSet.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await dbSet.ToListAsync();
    }

    public async Task<int> GetCount()
    {
        return await dbSet.CountAsync();
    }

    public async Task<bool> IsExist(ulong id)
    {
        var entity = await dbSet.Where(x => x.Id == id).FirstOrDefaultAsync();
        if (entity is null)
        {
            return false;
        }
        return true;
    }

    public async Task<bool> Update(T model)
    {
        if (await IsExist(model.Id))
        {
            return false;
        }
        await dbSet.AddAsync(model);
        return true;

    }
}
