using Async.Api.Lib.Clients;
using Async.Api.Lib.Model;

namespace Dont.App;

public static class TaskResult
{
    public static async Task GetByIdWithTaskResultAsync()
    {
        var weatherClient = new WeatherClient();

        var ids = await InitAsync(weatherClient);

        //FetchWithForeach(ids, weatherClient);

        await FetchWithTaskWhenAll(ids, weatherClient);
    }
    
    private static void FetchWithForeach(List<string> ids, WeatherClient weatherClient)
    {
        var results = new List<Weather?>();

        foreach (var id in ids)
        {
            Console.WriteLine($"Fetching {id}");
            results.Add(weatherClient.GetByIdAsync(id).Result);
        }
    }

    private static async Task FetchWithTaskWhenAll(List<string> ids, WeatherClient weatherClient)
    {
        var results = new List<Task<Weather?>>();

        foreach (var id in ids)
        {
            Console.WriteLine($"Fetching {id}");
            results.Add(weatherClient.GetByIdAsync(id));
        }
        
        await Task.WhenAll(results);
    }


    
    
    
    
    
    
    
    
    private static async Task<List<string>> InitAsync(WeatherClient weatherClient)
    {
        var data = Enumerable.Range(0, 100)
            .Select(e => new Weather(e.ToString(), e, $"Thread {e}"))
            .ToList();

        await weatherClient.SetAsync(data);

        return data.Select(e => e.Id).ToList();
    }
}