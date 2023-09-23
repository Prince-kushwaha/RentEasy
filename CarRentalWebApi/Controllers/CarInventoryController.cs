using AutoMapper;
using Business_Layer.Services.CarService;
using CarRentalWebApi.Models;
using Data_Access_Layer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarInventoryController : ControllerBase
    {
        private readonly ICarInventoryService _carInventoryService;
        private readonly IMapper _mapper;
        public CarInventoryController(ICarInventoryService carInventoryService, IMapper mapper)
        {
            _carInventoryService = carInventoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAvailableCar([FromQuery] string? maker, [FromQuery] string? model, [FromQuery] int minprice, [FromQuery] int maxprice, [FromQuery] string startDate, [FromQuery] string endDate)
        {
            IEnumerable<Car> result = await _carInventoryService.GetAllAvailableCar(maker, model, minprice, maxprice,startDate,endDate);
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddCar([FromBody] CarModel carModel)
        {
            Car car = _mapper.Map<Car>(carModel);
            await _carInventoryService.AddCar(car);
            return Ok();
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateCar([FromBody] CarModel carModel)
        {
            Car car = _mapper.Map<Car>(carModel);
            await _carInventoryService.UpdateCar(car);
            return Ok();
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCar([FromRoute] Guid id)
        {
            await _carInventoryService.DeleteCar(id);
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCarDetail([FromRoute] Guid id)
        {
            Car car = await _carInventoryService.GetCarById(id);
            if (car == null)
            {
                return NotFound();
            }

            return Ok(car);
        }

        [HttpGet]
        public async Task<IActionResult> IsPossibleToBookCar([FromQuery] Guid vehicleId, [FromQuery] string startDate, [FromQuery] string endDate)
        {
            var result= await _carInventoryService.IsPossibleToBookCar(vehicleId,startDate,endDate);   
            return Ok(result);
        }

        [HttpGet]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> AllCars()
        {
            var resp=await _carInventoryService.GetAllCars();
            return Ok(resp);
        }
    }
}
