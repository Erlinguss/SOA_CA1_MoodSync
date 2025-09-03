using Microsoft.AspNetCore.Components.Routing;
using MoodSync.Models;
using Newtonsoft.Json;


namespace MoodSync.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public WeatherService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["ApiKeys:OpenWeatherApiKey"]
             ?? throw new ArgumentNullException(nameof(_apiKey), " Weather API key is missing in the configuration.");
        }

        public async Task<WeatherData> GetWeatherAsync(string location)
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
}

