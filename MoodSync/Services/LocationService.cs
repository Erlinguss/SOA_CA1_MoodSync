using Newtonsoft.Json;
using MoodSync.Models;

namespace MoodSync.Services
{
    public class LocationService : ILocationService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public LocationService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["ApiKeys:GoogleMapsApiKey"]
               ?? throw new ArgumentNullException(nameof(_apiKey), "Google nearby API key is missing in the configuration.");

        }

        public async Task<NearbyPlacesData> GetNearbyPlacesAsync(double latitude, double longitude)
        {
            var url = $"https://maps.googleapis.com/maps/api/place/nearbysearch/json?location={latitude},{longitude}&radius=10000&key={_apiKey}";

            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var nearbyPlacesData = JsonConvert.DeserializeObject<NearbyPlacesData>(content);
                return nearbyPlacesData;
            }
            return null;
        }
    }
}
