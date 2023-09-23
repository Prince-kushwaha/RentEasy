using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data_Access_Layer.Entities
{
    public enum Status
    {
        CarIsRented,
        RequestForReturn,
        CarAsReturn,
        MarkforInspection
    }

    public class RentalAgreement
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public Status Status { get; set; }  = Status.CarIsRented;

        public string Maker { get; set; }

        public string Model { get; set; }

        public double RentalPrice { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public double TotalCost { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public Guid VehicleId { get; set; }
    }
}