using Data_Access_Layer.Entities;
using Data_Access_Layer.Repositories.CarRepository;
using Data_Access_Layer.Repositories.RentalRepository;
using Data_Access_Layer.UnitOfWork;

namespace Business_Layer.Services.CarService
{
    public class CarInventoryService : ICarInventoryService
    {
        private readonly ICarInventoryRepository _carInventoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRentalRepository _rentalRepository;
        public CarInventoryService(ICarInventoryRepository carRepository, IUnitOfWork unitOfWork, IRentalRepository rentalRepository)
        {
            _carInventoryRepository = carRepository;
            _unitOfWork = unitOfWork;
            _rentalRepository = rentalRepository;
        }

        public async Task<bool> AddCar(Car car)
        {
            car.VehicleId = Guid.NewGuid();
            await _carInventoryRepository.AddAsync(car);
            await _unitOfWork.SaveAsyc();
            return true;
        }

        public async Task<bool> DeleteCar(Guid vehicleId)
        {
            await _carInventoryRepository.Delete((car) => car.VehicleId == vehicleId);
            await _unitOfWork.SaveAsyc();
            return true;
        }

        public async Task<IEnumerable<Car>> GetAllAvailableCar(string? maker, string? model, int minprice, int maxprice,string startDate,string endDate)
        {
            if (maker == null)
            {
                maker = "";
            }

            if (model == null) { model = ""; }

            var vehicles = (await _carInventoryRepository.Filter((car) => car.RentalPrice >= minprice && car.RentalPrice <= maxprice && car.Maker.Contains(maker) && car.Model.Contains(model))).ToList();
            var agreements = (await _rentalRepository.GetAll()).ToList();
            var result = new List<Car>();
            var startDateA = DateTime.Parse(startDate);
            var endDateA = DateTime.Parse(endDate);

            for (var i = 0; i < vehicles.Count(); i++)
            {
                bool isAvailable = true;
                for (var j = 0; j < agreements.Count(); j++)
                {
                    if (vehicles[i].VehicleId == agreements[j].VehicleId)
                    {

                        var startDateB = DateTime.Parse(agreements[j].StartDate);
                        var endDateB = DateTime.Parse(agreements[j].EndDate);

                        var isOverLapping = startDateA <= endDateB && endDateA >= startDateB;

                        if (isOverLapping == true)
                        {
                            isAvailable = false;
                        }
                    }
                }

                if (isAvailable)
                {
                    result.Add(vehicles[i]);
                }
            }

            return result;
        }

        public async Task<IEnumerable<Car>> GetAllCars()
        {
            return await _carInventoryRepository.GetAll();
        }

        public async Task<Car?> GetCarById(Guid vehicleId)
        {
            return await _carInventoryRepository.Find((car) => car.VehicleId == vehicleId);
        }

        public async Task<bool> IsPossibleToBookCar(Guid carId, string SDate, string EDate)
        {

            var startDateA= DateTime.Parse(SDate);
            var endDateA= DateTime.Parse(EDate);
            bool isAvailable = true;
            var agreements = (await _rentalRepository.GetAll()).ToList();
            for (var j = 0; j < agreements.Count(); j++)
            {
                if (carId == agreements[j].VehicleId)
                {

                    var startDateB = DateTime.Parse(agreements[j].StartDate);
                    var endDateB = DateTime.Parse(agreements[j].EndDate);

                    var isOverLapping = startDateA <= endDateB && endDateA >= startDateB;

                    if (isOverLapping == true)
                    {
                        isAvailable = false;
                    }
                }
            }

            return isAvailable;
        }

        public async Task<bool> UpdateCar(Car car)
        {
            _carInventoryRepository.Update(car);
            await _unitOfWork.SaveAsyc();
            return true;
        }
    }
}
