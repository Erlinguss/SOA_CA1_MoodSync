using MoodSync.Models;

public interface IWeatherService
{
    Task<WeatherData> GetWeatherAsync(string location);
}

