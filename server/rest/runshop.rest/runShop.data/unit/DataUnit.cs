using runShop.data.Repos.user;
using System;
using System.Threading.Tasks;

namespace runShop.data.unit
{
    public class DataUnit : IUnit, IDisposable
    {
        private readonly AppDbContext dbContext;

        public IUserRepo userRepo { get; }

        public DataUnit(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.userRepo = new UserRepo(dbContext);
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }

        public async Task SaveChangesAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
