using AutoMapper;
using Cars.API.Data.Entities;
using Cars.Shared.DTO;
using Repositories;

namespace Cars.API.Services
{
    public class ManufacturerService:ServiceDto<ManufacturerDto, ManufacturerDetailsDto, Manufacturer>
    {
        public ManufacturerService(IMapper mapper,IRepository<Manufacturer> manufacturerRepository)
        {
            _mapper = mapper;
            _repository = manufacturerRepository;
        }
        
    }
}
