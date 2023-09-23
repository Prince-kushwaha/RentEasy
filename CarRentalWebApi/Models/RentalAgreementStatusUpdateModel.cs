using System.ComponentModel.DataAnnotations;

namespace CarRentalWebApi.Models
{
    public class RentalAgreementStatusUpdateModel
    {
        [Required]
        public string Status { get; set; }
    }
}
