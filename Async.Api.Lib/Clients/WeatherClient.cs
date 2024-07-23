using Async.Api.Lib.Model;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace Async.Api.Lib.Clients;

public class WeatherClient
{
    public void SetWeatherTemperature(Weather weather)
    {
        var client = new HttpClient();
        var task = client.PutAsync("http://localhost:5172/api/weather",
            new StringContent(JsonSerializer.Serialize(weather), Encoding.UTF8, "application/json"));

        task.Wait();
    }
    
    public async void SetWeatherTemperatureAsync(Weather weather)
    {
        var client = new HttpClient();
        var result = await client.PutAsync("http://localhost:5172/api/weather",
            new StringContent(JsonSerializer.Serialize(weather), Encoding.UTF8, "application/json"));

        result.EnsureSuccessStatusCode();
    }

    public async Task<Weather?> GetByIdAsync(string id)
    {
        var client = new HttpClient();
        var result = await client.GetFromJsonAsync<Weather>($"http://localhost:5172/api/weather/{id}").ConfigureAwait(false);

        return result;
    }
    
    public async Task SetAsync(Weather weather)
    {
        var client = new HttpClient();
        var result = await client.PostAsync("http://localhost:5172/api/weather",
            new StringContent(JsonSerializer.Serialize(weather), Encoding.UTF8, "application/json"));

        result.EnsureSuccessStatusCode();
    }
    
    public async Task SetAsync(ICollection<Weather> weather)
    {
        await Task.WhenAll(weather.Select(SetAsync));
    }
}