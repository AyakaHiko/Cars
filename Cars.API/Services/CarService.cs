using AutoMapper;
using Cars.API.Data.Entities;
using Cars.Shared.DTO;
using Repositories;

namespace Cars.API.Services;

public class CarService : ServiceDto<CarDto, CarDetailsDto, Car>
{

    public CarService(IMapper mapper, IRepository<Car> cityRepository)
    {
        _mapper = mapper;
        _repository = cityRepository;
    }
}