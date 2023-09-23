using Data_Access_Layer.Contexts;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Repositories.GenericRepository;

namespace Data_Access_Layer.Repositories.CarRepository
{
    public class CarInventoryRepository : Repository<Car>, ICarInventoryRepository
    {
        public CarInventoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
