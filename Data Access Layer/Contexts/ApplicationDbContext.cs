using Data_Access_Layer.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data_Access_Layer.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Car> Cars { get; set; }

        public DbSet<RentalAgreement> RentalAgreements { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = 1,
                    Name = "Pawan",
                    PhoneNumber = "123456789",
                    Password = "Pawan123@",
                    Email = "pawan123@gmail.com",
                    Role = "User"
                },
                new User()
                {
                    Id = 2,
                    Name = "Suraj",
                    PhoneNumber = "123456789",
                    Password = "Suraj123@",
                    Email = "Suraj123@gmail.com",
                    Role = "User"
                }
                ,
                new User()
                {
                    Id=3,
                    Name="Admin",
                    PhoneNumber="12345671111",
                    Password="Admin111@",
                    Email="Admin1234@gmail.com",
                    Role="Admin"
                }
            );

            modelBuilder.Entity<Car>().HasData(
                new Car()
                {
                    VehicleId = Guid.NewGuid(),
                    Maker = "Tata",
                    Model = "Tiago",
                    RentalPrice = 1000
                },
                new Car()
                {
                    VehicleId = Guid.NewGuid(),
                    Maker = "Tata",
                    Model = "Altrox",
                    RentalPrice = 900
                },
                new Car()
                {
                    VehicleId = Guid.NewGuid(),
                    Maker = "Maruti Suzuki",
                    Model = "Ignis",
                    RentalPrice = 2000
                },
                new Car()
                {
                    VehicleId = Guid.NewGuid(),
                    Maker = "Maruti Suzuki",
                    Model = "Claz",
                    RentalPrice = 1200
                }); ; ;
        }
    }
}
