using AutoMapper;
using CarRentalWebApi.Models;
using Data_Access_Layer.Entities;

namespace CarRentalWebApi.Mapper
{
    public class CarMapper : Profile
    {
        public CarMapper()
        {
            CreateMap<Car, CarModel>().ReverseMap();
        }

    }
}
