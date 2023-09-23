using AutoMapper;
using Business_Layer.Services.CarService;
using Business_Layer.Services.RentalService;
using CarRentalWebApi.Models;
using Data_Access_Layer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CarRentalWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RentalAgreementController : ControllerBase
    {

        private readonly IRentalService _rentalService;
        private readonly IMapper _mapper;
        private readonly ICarInventoryService _carInventoryService;
        public RentalAgreementController(IRentalService rentalService, IMapper mapper,ICarInventoryService carInventoryService)
        {
            _rentalService = rentalService;
            _mapper = mapper;
            _carInventoryService = carInventoryService;

        }

        [HttpPost]
        [Authorize(Roles ="User")]
        public async Task<IActionResult> CreateRentalAgreement([FromBody] RentalAgreementModel rentalAgreementModel)
        {
            var rentalAgreement = _mapper.Map<RentalAgreement>(rentalAgreementModel);
            var isAvailable = await _carInventoryService.IsPossibleToBookCar(rentalAgreement.VehicleId,rentalAgreement.StartDate,rentalAgreement.EndDate);
            if(!isAvailable)
            {
                return BadRequest("Car is already book on these dates");
            }
            await _rentalService.CreateRentalAgreement(rentalAgreement);
            return Ok();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllRentalAgreement()
        {
            return Ok(await _rentalService.GetAllRentalAgreement());
        }

        [HttpGet]
        [Authorize(Roles ="User")]
        public async Task<IActionResult> GetMyRentalAgreement()
        {
            string email = User.FindFirst(ClaimTypes.Email)?.Value;
            return Ok(await _rentalService.GetAllRentalAgreementByUserId(email));
        }

        [HttpGet]
        [Authorize(Roles ="User")]
        [Route("{id}")]
        public async Task<IActionResult> GetMyRentalAgreement([FromRoute] int id)
        {
            string email = User.FindFirst(ClaimTypes.Email)?.Value;
            var result=await  _rentalService.GetRentalAgreementById(id);
            return Ok(result);
        }

        [HttpGet]
        [Authorize(Roles ="User")]
        [Route("{id}")]
        public async Task<IActionResult> RequestForReturn([FromRoute] int id )
        {
            await _rentalService.RequestForReturn(id);
            return Ok();
        }

        [HttpGet]
        [Authorize(Roles ="Admin")]
        [Route("{agreementId}")]
        public async Task<IActionResult> RentalAgreementDetails([FromRoute] int agreementId)
        {
            var resp=await _rentalService.GetRentalAgreementById(agreementId);
            return Ok(resp);
        }

        [HttpDelete]
        [Authorize(Roles ="Admin")]
        [Route("{agreementId}")]
        public async Task<IActionResult> DeleteRentalAgreement([FromRoute] int agreementId)
        {
            await _rentalService.DeleteRentalAgreement(agreementId);
            return Ok();
        }

        [HttpPut]
        [Authorize(Roles ="Admin")]
        [Route("{agreementId:int}")]
        public async Task<IActionResult> UpdateRentalAgreementStatus([FromRoute] string agreementId, [FromBody] RentalAgreementStatusUpdateModel model)
        {
            int id = int.Parse(agreementId);
            await _rentalService.UpdateRentalAgreementStatus(id,model.Status);
            return Ok();
        }
    }
}
