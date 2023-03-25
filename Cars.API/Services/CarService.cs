using AutoMapper;
using Cars.API.Data.Entities;
using Cars.API.Interfaces;
using Cars.Shared.DTO;

namespace Cars.API.Services;

public class CarService : ServiceDto<CarDto, CarDetailsDto, Car>
{

    public CarService(IMapper mapper, IRepository<Car> cityRepository)
    {
        _mapper = mapper;
        _repository = cityRepository;
    }
}