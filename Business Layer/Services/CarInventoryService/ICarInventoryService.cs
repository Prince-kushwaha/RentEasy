using Data_Access_Layer.Entities;

namespace Business_Layer.Services.CarService
{
    public interface ICarInventoryService
    {
        Task<bool> AddCar(Car car);

        Task<IEnumerable<Car>> GetAllAvailableCar(string? maker,string? model,int minprice,int maxprice,string startDate,string endDate);

        Task<bool> DeleteCar(Guid vehicleId);

        Task<bool> UpdateCar(Car car);

        Task<Car> GetCarById(Guid carId);

        Task<bool> IsPossibleToBookCar(Guid carId,string startDate,string endDate);

        Task<IEnumerable<Car>> GetAllCars();
    }
}
