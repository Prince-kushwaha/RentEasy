using System.ComponentModel.DataAnnotations;

namespace Data_Access_Layer.Entities
{
    public class Car
    {
        [Key]
        public Guid VehicleId { get; set; }

        public string Maker { get; set; }

        public string Model { get; set; }

        public double RentalPrice { get; set; }
    }
}

