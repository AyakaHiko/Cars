using AutoMapper;

namespace Repositories;

public abstract class ServiceDto<TDto, TDtoDetails, TEntity> : IService<TDto, TDtoDetails>
    where TDto : class
    where TDtoDetails : class
{
    protected  IMapper _mapper;
    protected  IRepository<TEntity> _repository;
    public async Task<IEnumerable<TDto?>> Get()
    {
        var entities = await _repository.Get();
        var result = _mapper.Map<IEnumerable<TDto>>(entities);
        return result;
    }

    public async Task<IEnumerable<TDtoDetails?>> GetDetails()
    {
        var entities = await _repository.GetDetails();

        var result = _mapper.Map<IEnumerable<TDtoDetails>>(entities);
        return result;
    }

    public async Task<TDto?> Get(int id)
    {
        var entity = await _repository.Get(id);
        if (entity is null)
        {
            return null;
        }
        var result = _mapper.Map<TDto>(entity);
        return result;
    }

    public async Task<TDtoDetails?> GetDetails(int id)
    {
        var entity = await _repository.GetDetails(id);
        if (entity is null)
        {
            return null;
        }

        var result = _mapper.Map<TDtoDetails>(entity);
        return result;
    }

    public async Task<TDto?> Post(TDto entity)
    {
        var mappedEntity = _mapper.Map<TEntity>(entity);
        var addedEntity = await _repository.Post(mappedEntity);

        var result = _mapper.Map<TDto>(addedEntity);
        return result;
    }

    public async Task<TDto?> Put(TDto entity)
    {
        var mappedEntity = _mapper.Map<TEntity>(entity);
        if (mappedEntity is null)
        {
            return null;
        }

        var updatedCity = await _repository.Put(mappedEntity);
        var result = _mapper.Map<TDto>(updatedCity);

        return result;
    }

    public async Task<TDto?> Delete(int id)
    {
        var mappedEntity = await _repository.Get(id);
        if (mappedEntity is null)
        {
            return null;
        }

        var deletedCity = await _repository.Delete(mappedEntity);
        var result = _mapper.Map<TDto>(deletedCity);

        return result;
    }

    public bool IsExists(int id)
    {
        return _repository.IsExists(id);
    }
}