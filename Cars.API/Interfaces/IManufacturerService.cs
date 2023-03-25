using Cars.Shared.DTO;

namespace Cars.API.Interfaces
{
    public interface IManufacturerService
    {
        Task<IEnumerable<ManufacturerDetailsDto>> GetCarsDetails();

    }
}
