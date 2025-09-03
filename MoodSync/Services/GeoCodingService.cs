using Newtonsoft.Json;
using MoodSync.Models;
using MoodSync.Interfaces;

namespace MoodSync.Services
{
    public class GeoCodingService : IGeoCodingService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public GeoCodingService(HttpClient httpClient,
                                IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["ApiKeys:GoogleMapsApiKey"]
                     ?? throw new ArgumentNullException(nameof(_apiKey), "Google Map API key is missing in the configuration.");

        }

        public async Task<LocationData> GetCoordinatesAsync(string location)
        {
            var url = $"https://maps.googleapis.com/maps/api/geocode/json?address={location}&key={_apiKey}";
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var geoCodingData = JsonConvert.DeserializeObject<LocationData>(content);
                return geoCodingData;
            }
            return null;
        }
    }
}
