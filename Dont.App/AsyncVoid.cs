using Async.Api.Lib.Clients;
using Async.Api.Lib.Model;

namespace Dont.App;

public static class AsyncVoidClass
{
    public static void AsyncVoid()
    {
        var weatherClient = new WeatherClient();
        var weather = new Weather("Centurion", 20, "Unit test");
        weatherClient.SetWeatherTemperature2(weather);
    }
    
    public static void PlainVoid()
    {
        var weatherClient = new WeatherClient();
        var weather = new Weather("Centurion", 20, "Unit test");
        weatherClient.SetWeatherTemperature(weather);
    }
}