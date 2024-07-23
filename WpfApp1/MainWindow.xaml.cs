using Async.Api.Lib.Clients;
using Async.Api.Lib.Model;
using System.Windows;
using System.Windows.Interop;

namespace WpfApp1;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private List<string> _ids = new();

    private Task _init;
    private readonly WeatherClient _weatherClient = new WeatherClient();
    
    public MainWindow()
    {
        InitializeComponent();

        _init = LoadDataAsync(_weatherClient);
    }
    
    private async Task LoadDataAsync(WeatherClient weatherClient)
    {
        var data = Enumerable.Range(0, 100)
            .Select(e => new Weather(e.ToString(), e, $"Thread {e}"))
            .ToList();

        await weatherClient.SetAsync(data);

        _ids = data.Select(e => e.Id).ToList();
    }

    private void AsyncVoidButton_OnClick(object sender, RoutedEventArgs e)
    {
        var weatherClient = new WeatherClient();
        var weather = new Weather("Centurion", 20, "Unit test");
        weatherClient.SetWeatherTemperatureAsync(weather);

        Output.Text = "Weather set";
    }

    private void CallUsingTaskResultButton_OnClick(object sender, RoutedEventArgs e)
    {
        TaskResultOutput.Text = "Weather fetched using Task.Result";
        foreach (var id in _ids)
        {
            Console.WriteLine($"Fetching {id}");
            var weather = _weatherClient.GetByIdAsync(id).Result;
            
            TaskResultOutput.AppendText($"\n{weather?.Id} - {weather?.Temperature} - {weather?.SetBy}");
        }
    }

    private async void CallUsingAsyncButton_OnClick(object sender, RoutedEventArgs e)
    {
        var tasks = new List<Task<Weather?>>();

        foreach (var id in _ids)
        {
            Console.WriteLine($"Fetching {id}");
            tasks.Add(_weatherClient.GetByIdAsync(id));
        }
        
        var results = await Task.WhenAll(tasks);
        
        TaskResultOutput.Text = "Weather fetched async";
        foreach (var weather in results)
            TaskResultOutput.AppendText($"\n{weather?.Id} - {weather?.Temperature} - {weather?.SetBy}");
    }
    
    private async Task<IEnumerable<Weather?>> GetWeatherResultsAsync()
    {
        var results = new List<Task<Weather?>>();

        foreach (var id in _ids)
        {
            Console.WriteLine($"Fetching {id}");
            results.Add(_weatherClient.GetByIdAsync(id));
        }
        
        return await Task.WhenAll(results);
    }
}