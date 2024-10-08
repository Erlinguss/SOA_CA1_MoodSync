using MoodSync.Models;
using Newtonsoft.Json;
using System;

namespace MoodSync.Components.Services
{
    public class LocationService
    {

        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "";

        public LocationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetLocation(string location)
        {
            var url = $"https://maps.googleapis.com/maps/api/geocode/json?address={location}&key={_apiKey}";

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var LocationData = JsonConvert.DeserializeObject<LocationService>(content);

                return LocationData;
            }
            return null;
        }
    }
}
