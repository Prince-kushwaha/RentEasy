namespace CarRentalWebApi.Models
{
    public class RentalAgreementModel
    {
        public string Maker { get; set; }

        public string Model { get; set; }

        public double RentalPrice { get; set; }

        public string StartDate { get; set; } 

        public string EndDate { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public double TotalCost { get; set; }
        public Guid VehicleId { get; set; }
    }
}
