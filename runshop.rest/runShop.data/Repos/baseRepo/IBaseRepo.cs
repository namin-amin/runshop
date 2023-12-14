using runShop.Models.models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace runShop.data.Repos.baseRepo;

public interface IBaseRepo<T>
   where T : BaseModel
{
    Task<T?> Get(ulong id);
    Task<IEnumerable<T>> GetAll();
    Task<int> GetCount();
    Task<bool> IsExist(ulong id);
    Task<bool> Delete(ulong id);
    Task<bool> Update(T model);
    Task Create(T model);

}

