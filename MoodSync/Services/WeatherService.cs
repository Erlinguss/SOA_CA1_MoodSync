using Microsoft.AspNetCore.Components.Routing;
using MoodSync.Models;
using Newtonsoft.Json;

public class WeatherService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey = " ";

    public WeatherService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<WeatherData> GetWeatherDataAsync(string location)
    {
        var url = $"https://api.openweathermap.org/data/2.5/weather?q={location}&appid={_apiKey}&units=metric";

        var response = await _httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var weatherData = JsonConvert.DeserializeObject<WeatherData>(content);

            return weatherData;
        }
        return null;
    }
}

