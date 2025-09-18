using PetProjectAPI.Dal;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetProjectAPI.Bll;

public interface IDataService
{
    Task SaveDataAsync(DateTime id, string name, int value);
    Task<List<DataEntity>> ReadDataAsync();
}

public class DataService : IDataService
{
    private readonly IDataRepository _repository;
    public DataService(IDataRepository repository)
    {
        _repository = repository;
    }

    public async Task SaveDataAsync(DateTime id, string name, int value)
    {
        var entity = new DataEntity { Id = id, Name = name, Value = value };
        await _repository.SaveAsync(entity);
    }

    public async Task<List<DataEntity>> ReadDataAsync()
    {
        return await _repository.GetAllAsync();
    }
}
