using Newtonsoft.Json;
using MoodSync.Models;

namespace MoodSync.Services
{
    public class GeocodingService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "AIzaSyAARniUO27XBpmFtefiEDN2e9twJs4Tb0U";

        public GeocodingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
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
