using AutoMapper;
using CarRentalWebApi.Models;
using Data_Access_Layer.Entities;

namespace CarRentalWebApi.Mapper
{
    public class RentalAgreementMapper:Profile
    {
        public RentalAgreementMapper()
        {
            CreateMap<RentalAgreement,RentalAgreementModel>().ReverseMap();
        }
    }
}
