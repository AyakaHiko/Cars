using AutoMapper;
using Cars.API.Data.Entities;
using Cars.Shared.DTO;

namespace Cars.API.AutoMapperProfiles
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<Car, CarDto>().ReverseMap();
            CreateMap<Car, CarDetailsDto>()
                .ForMember(destinationMember => destinationMember.ManufacturerName,
                    opt => opt.MapFrom(source => source.Manufacturer!.Name))
                .ForMember(destinationMember=> destinationMember.ManufacturerCountry, 
                    opt => opt.MapFrom(source=> source.Manufacturer!.Country))
                .ReverseMap();

        }
    }
}
