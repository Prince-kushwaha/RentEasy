using Data_Access_Layer.Contexts;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Repositories.GenericRepository;

namespace Data_Access_Layer.Repositories.RentalRepository
{
    public class RentalRepository:Repository<RentalAgreement>,IRentalRepository
    {
        public RentalRepository(ApplicationDbContext applicationDbContext):base(applicationDbContext)
        {

        }
    }
}
