using System.ComponentModel.DataAnnotations;

namespace CarRentalWebApi.Models
{
    public class CarModel
    {
        public Guid? VehicleId { get; set; }
        [Required]
        public string Maker { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public double RentalPrice { get; set; }
    }
}
