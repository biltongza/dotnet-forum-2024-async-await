using Async.Api.Lib.Clients;
using Async.Api.Lib.Model;

namespace Dont.App;

public static class MixSyncAsyncClass
{
    public static async Task MixSyncAsync()
    {
        var weatherClient = new WeatherClient();
        var weather = new Weather("Centurion", 20, "Unit test");
        
        // blocking
        weatherClient.SetWeatherTemperature(weather);
        
        // non-blocking
        var result = await weatherClient.GetByIdAsync(weather.Id);
    }
}