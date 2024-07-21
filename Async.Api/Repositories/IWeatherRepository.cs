using Async.Api.Lib.Model;

namespace Async.Api.Repositories;

public interface IWeatherRepository
{
    Weather? GetWeatherById(string id);
    ICollection<Weather?> GetAll();
    void SetWeatherById(Weather weatherRecord);
}