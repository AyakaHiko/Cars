using AutoMapper;
using Cars.API.Data.Entities;
using Cars.Shared.DTO;

namespace Cars.API.AutoMapperProfiles
{
    public class ManufacturerProfile: Profile
    {
        public ManufacturerProfile()
        {
            CreateMap<Manufacturer, ManufacturerDto>().ReverseMap();
            CreateMap<Manufacturer, ManufacturerDetailsDto>().ReverseMap();
        }

    }
}
