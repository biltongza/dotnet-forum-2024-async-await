using Async.Api.Lib.Model;
using Async.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Async.Api.Controllers;

[Route("/api/weather")]
public class WeatherController: Controller
{
    private IWeatherRepository _weatherRepository;

    public WeatherController(IWeatherRepository weatherRepository)
    {
        _weatherRepository = weatherRepository;
    }

    [HttpPost]
    public ActionResult SetWeatherTemperature([FromBody]Weather temperature)
    {
        _weatherRepository.SetWeatherById(temperature);

        return Ok();
    }
    
    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult> GetWeatherTemperature(string id)
    {
        var result = _weatherRepository.GetWeatherById(id);
        await Task.Delay(100);

        return Ok(result);
    }
    
    [HttpGet]
    [Route("getall")]
    public ActionResult GetAll()
    {
        var result = _weatherRepository.GetAll();

        return Ok(result);
    }
}