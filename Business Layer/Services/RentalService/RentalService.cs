using Business_Layer.Services.AccountService;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Repositories.RentalRepository;
using Data_Access_Layer.UnitOfWork;

namespace Business_Layer.Services.RentalService
{
    public class RentalService : IRentalService
    {
        private readonly IAccountService _accountService;
        private readonly IRentalRepository _rentalRepository;
        private readonly IUnitOfWork _unitOfWork;
        public RentalService(IAccountService accountService,IUnitOfWork unitOfWork,IRentalRepository rentalRepository)
        {
            _accountService = accountService;
            _rentalRepository = rentalRepository;
            _unitOfWork = unitOfWork;   
        }

        public async Task CreateRentalAgreement(RentalAgreement rentalAgreement)
        {
           var user= await _accountService.FindUserByEmail(rentalAgreement.Email);
           rentalAgreement.UserId = user.Id;
           await _rentalRepository.AddAsync(rentalAgreement);
           await _unitOfWork.SaveAsyc();
        }

        public async Task DeleteRentalAgreement(int id)
        {
            await _rentalRepository.Delete((agreement)=>agreement.Id == id);
            await _unitOfWork.SaveAsyc();
        }

        
        public async Task<IEnumerable<RentalAgreement>> GetAllRentalAgreement()
        {
            return await _rentalRepository.GetAll();
        }

        public async Task<IEnumerable<RentalAgreement>> GetAllRentalAgreementByUserId(string email)
        {
            var user=await _accountService.FindUserByEmail(email);
            var result=await _rentalRepository.Filter((agreement)=>agreement.UserId == user.Id);
            return result;
        }

        public async Task<RentalAgreement?> GetRentalAgreementById(int id)
        {
            return await _rentalRepository.Find((agreement) => agreement.Id == id);
        }

        public async Task<RentalAgreement> RequestForReturn(int agreementId)
        {
           var agreement= await _rentalRepository.Find((agreement) =>agreement.Id==agreementId);
           agreement.Status = Status.RequestForReturn;
           _rentalRepository.Update(agreement);
           await _unitOfWork.SaveAsyc();
           return agreement;
        }

        public async Task<bool> UpdateRentalAgreementStatus(int agreementId,string status)
        {
            var agreement = await _rentalRepository.Find((agreement) => agreement.Id == agreementId);

            if(status== "MarkforInspection")
            {
                agreement.Status = Status.MarkforInspection;
            } else if(status== "CarAsReturn")
            {
                agreement.Status=Status.CarAsReturn;
            } else
            {
                return false;
            }

             _rentalRepository.Update(agreement);
            await _unitOfWork.SaveAsyc();
            return true;
        }
    }
}
