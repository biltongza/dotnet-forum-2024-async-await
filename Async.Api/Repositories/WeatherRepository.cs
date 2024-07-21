using Async.Api.Lib.Model;
using System.Collections.Concurrent;

namespace Async.Api.Repositories;

public class InMemoryWeatherRepository : IWeatherRepository
{
    private class CounterWrapper<T>
    {
        public T? Data;
        public long GetCounter = 0;
        public long OperationNumber = 0;
    }
    
    private ConcurrentDictionary<string, CounterWrapper<Weather>> _repo = new();

    public Weather? GetWeatherById(string id)
    {
        var result = _repo.GetOrAdd(id, new CounterWrapper<Weather>()
        {
            Data = null,
            GetCounter = 1,
            // OperationNumber = await CounterRepository.GetCounterValueAsync()
        });

        result.GetCounter++;

        return result.Data;
    }

    public ICollection<Weather?> GetAll()
    {
        return _repo.Values.Select(e => e.Data).ToList();
    }

    public void SetWeatherById(Weather weatherRecord)
    {
        _repo.TryAdd(weatherRecord.Id, new CounterWrapper<Weather>()
        {
            Data = weatherRecord,
            GetCounter = 0,
            // OperationNumber = await CounterRepository.GetCounterValueAsync()
        });
    }
}