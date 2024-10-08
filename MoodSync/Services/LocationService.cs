using Newtonsoft.Json;
using MoodSync.Models;

namespace MoodSync.Services
{
    public class LocationService : ILocationService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "AIzaSyAARniUO27XBpmFtefiEDN2e9twJs4Tb0U";

        public LocationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<NearbyPlacesData> GetNearbyPlacesAsync(double latitude, double longitude)
        {
            var url = $"https://maps.googleapis.com/maps/api/place/nearbysearch/json?location={latitude},{longitude}&radius=5000&key={_apiKey}";

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
