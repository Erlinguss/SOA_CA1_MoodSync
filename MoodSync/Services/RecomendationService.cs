using MoodSync.Enums;
using MoodSync.Models;

namespace MoodSync.Services
{
    public class RecommendationService
    {
        private readonly IWeatherService _weatherService;
        private readonly ILocationService _locationService;

        public RecommendationService(IWeatherService weatherService, ILocationService locationService)
        {
            _weatherService = weatherService;
            _locationService = locationService;
        }

        public async Task<List<string>> GetRecommendationsAsync(string location, Mood mood)
        {
            var weatherData = await _weatherService.GetWeatherAsync(location);

            var geocodeData = await _locationService.GetCoordinatesAsync(location);

            if (geocodeData != null && geocodeData.Results.Count > 0)
            {
                var latitude = geocodeData.Results[0].Geometry.Location.Latitude;
                var longitude = geocodeData.Results[0].Geometry.Location.Longitude;

                var nearbyPlacesData = await _locationService.GetNearbyPlacesAsync(latitude, longitude);

                return FilterPlacesByMood(nearbyPlacesData, mood);
            }
            return new List<string> { "Unable to retrieve location data. Please try again." };
        }

        private List<string> FilterPlacesByMood(NearbyPlacesData nearbyPlaces, Mood mood)
        {
            var filteredRecommendations = new List<string>();

            foreach (var place in nearbyPlaces.Results)
            {
                if (IsPlaceSuitableForMood(place, mood))
                {
                    filteredRecommendations.Add($"{place.Name} - {place.Vicinity}");
                }
            }

            return filteredRecommendations;
        }

    }
}

