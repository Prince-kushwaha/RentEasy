using Data_Access_Layer.Contexts;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Repositories.GenericRepository;

namespace Data_Access_Layer.Repositories.AccountRepository
{
    public class AccountRepository : Repository<User>, IAccountRepository
    {
        public AccountRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

       }
    }
}
