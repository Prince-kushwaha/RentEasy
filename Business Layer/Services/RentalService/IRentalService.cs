
using Data_Access_Layer.Entities;

namespace Business_Layer.Services.RentalService
{
    public interface IRentalService
    {
        Task CreateRentalAgreement(RentalAgreement rentalAgreement);

        Task<IEnumerable<RentalAgreement>> GetAllRentalAgreement();

        Task<IEnumerable<RentalAgreement>> GetAllRentalAgreementByUserId(string email);

        Task DeleteRentalAgreement(int id);

        Task<RentalAgreement> GetRentalAgreementById(int id);
        Task<RentalAgreement> RequestForReturn(int vehicleId);

        Task<bool> UpdateRentalAgreementStatus(int agreementId,string status);

    }
}
